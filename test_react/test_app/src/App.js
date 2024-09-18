import React, { useState } from 'react';

function App() {
    const [data, setData] = useState([]);
    const [error, setError] = useState(null);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7169/WeatherForecast');
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const result = await response.json();
            setData(result);
        } catch (error) {
            setError(error);
        }
    };

    return (
        <div>
            <button onClick={fetchData}>フェッチ</button>
            {error && <div>Error: {error.message}</div>}
            <ul>
                {data.map((item, index) => (
                    <li key={index}>
                        <div>日付: {item.date}</div>
                        <div>摂氏温度: {item.temperatureC}°C</div>
                        <div>華氏温度: {item.temperatureF}°F</div>
                        <div>概要: {item.summary}</div>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;