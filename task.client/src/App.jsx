import { useEffect, useState } from 'react';
import './App.css';
import { Link } from 'react-router-dom';

function App() {
    const [books, setBooks] = useState([]);
    const [filteredBooks, setFilteredBooks] = useState([]);
    const [searchParams, setSearchParams] = useState({ name: '', year: '', type: '' });
    const [selectedBook, setSelectedBook] = useState(null);
    const [showReservationPopup, setShowReservationPopup] = useState(false);

    useEffect(() => {
        fetchBookData();
    }, []);

    useEffect(() => {
        const filtered = books.filter(book => {
            const matchesName = book.name.toLowerCase().includes(searchParams.name.toLowerCase());
            const matchesYear = searchParams.year ? book.year === Number(searchParams.year) : true;
            const matchesType = searchParams.type ? book.type === searchParams.type : true;
            return matchesName && matchesYear && matchesType;
        });
        setFilteredBooks(filtered);
    }, [searchParams, books]);

    const contents = books.length === 0
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : filteredBooks.length === 0
            ? <p><em>No books found. Try a different search.</em></p>
            : <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Picture</th>
                        <th>Name</th>
                        <th>Year</th>
                        <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredBooks.map(book =>
                        <tr key={book.id} onClick={() => handleBookClick(book)} style={{ cursor: 'pointer' }}>
                            <td><img src={book.pictureUrl} alt={book.name} width="50" /></td>
                            <td>{book.name}</td>
                            <td>{book.year}</td>
                            <td>{book.type}</td>
                        </tr>
                    )}
                </tbody>
            </table>;

    return (
        <div>
            <h1 id="tableLabel">Library Books</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <div>
                <input type="text" placeholder="Search by name" onChange={(e) => updateSearchParams('name', e.target.value)} />
                <input type="number" placeholder="Search by year" onChange={(e) => updateSearchParams('year', e.target.value)} />
                <select onChange={(e) => updateSearchParams('type', e.target.value)}>
                    <option value="">All Types</option>
                    <option value="Book">Book</option>
                    <option value="Audiobook">Audiobook</option>
                </select>
            </div>
            <button>
                <Link to="/reservations">View My Reservations</Link>
            </button>
            {contents}

            {showReservationPopup && selectedBook && (
                <ReservationPopup book={selectedBook} onClose={() => setShowReservationPopup(false)} />
            )}
        </div>
    );

    async function fetchBookData() {
        try {
            const response = await fetch('/api/books');
            const data = await response.json();
            setBooks(data);
            setFilteredBooks(data);
        } catch (error) {
            console.error("Error fetching book data:", error);
        }
    }

    function updateSearchParams(field, value) {
        setSearchParams(prevParams => ({ ...prevParams, [field]: value }));
    }

    function handleBookClick(book) {
        setSelectedBook(book);
        setShowReservationPopup(true);
    }
}

function ReservationPopup({ book, onClose }) {
    const [days, setDays] = useState(1);
    const [type, setType] = useState(book.type);
    const [quickPickUp, setQuickPickUp] = useState(false);

    const handleReserve = async () => {
        try {
            const reservation = { bookName: book.name, type, days, quickPickUp };
            await fetch('/api/reservations', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(reservation)
            });
            onClose();
        } catch (error) {
            console.error("Error creating reservation:", error);
        }
    };

    return (
        <div className="popup">
            <div className="popup-content">
                <h2>Reserve {book.name}</h2>
                <div>
                    <label>Type:</label>
                    <select value={type} onChange={(e) => setType(e.target.value)}>
                        <option value="Book">Book</option>
                        <option value="Audiobook">Audiobook</option>
                    </select>
                </div>
                <div>
                    <label>Days:</label>
                    <input type="number" min="1" value={days} onChange={(e) => setDays(parseInt(e.target.value, 10))} />
                </div>
                <div>
                    <label>Quick Pick-Up (5):</label>
                    <input type="checkbox" checked={quickPickUp} onChange={(e) => setQuickPickUp(e.target.checked)} />
                </div>
                <button onClick={handleReserve}>Confirm Reservation</button>
                <button onClick={onClose}>Cancel</button>
            </div>
        </div>
    );
}

export default App;
