import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';
import App from './App.jsx';
import Reservations from './components/Reservations';

const root = createRoot(document.getElementById('root'));
root.render(
    <StrictMode>
        <Router>
            <Routes>
                <Route path="/" element={<App />} />
                <Route path="/reservations" element={<Reservations />} />
            </Routes>
        </Router>
    </StrictMode>,
);
