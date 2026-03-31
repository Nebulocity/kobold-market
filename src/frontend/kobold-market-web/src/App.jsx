import { useEffect, useState } from "react";
import "./App.css";

function App() {
    const [status, setStatus] = useState("Loading...");

    useEffect(() => {
        fetch("http://localhost:5286/health")
            .then((response) => response.json())
            .then((data) => {
                setStatus(data.status);
            })
            .catch(() => {
                setStatus("Backend unavailable");
            });
    }, []);

    return (
        <main>
            <h1>Kobold Market</h1>
            <p>D&D campaign manager, miniature marketplace, and activity tracker.</p>
            <p>Backend status: {status}</p>
        </main>
    );
}

export default App;