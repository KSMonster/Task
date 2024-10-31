import { useEffect, useState } from 'react';

function Reservations() {
    const [reservations, setReservations] = useState([]);
    const userId = 1;

    useEffect(() => {
        fetchReservations();
    }, []);

    async function fetchReservations() {
        try {
            const response = await fetch(`/api/reservations/user/${userId}`);
            const data = await response.json();
            setReservations(data);
        } catch (error) {
            console.error("Error fetching reservations:", error);
        }
    }

    const contents = reservations.length === 0
        ? <p><em>No reservations found.</em></p>
        : (
            <table>
                <thead>
                    <tr>
                        <th>Book Name</th>
                        <th>Type</th>
                        <th>Days</th>
                        <th>Quick Pick-Up</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {reservations.map(reservation => (
                        <tr key={reservation.id}>
                            <td>{reservation.bookName}</td>
                            <td>{reservation.type}</td>
                            <td>{reservation.days}</td>
                            <td>{reservation.quickPickUp ? 'Yes' : 'No'}</td>
                            <td>{reservation.price.toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );

    return (
        <div>
            <h1>My Reservations</h1>
            {contents}
        </div>
    );
}

export default Reservations;
