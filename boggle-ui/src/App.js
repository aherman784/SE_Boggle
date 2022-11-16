import { useState } from "react";
import { Gameplay } from "./Pages/Gameplay/Gameplay";
import './App.scss';

function App() {
  const [isGameStarted, setIsGameStarted] = useState(true);
  return (
    <div className="home-container">
      <div className="game-title">
        Boggle
      </div>
      {!isGameStarted ? 
      <>
      </> : 
      <Gameplay />}
    </div>
  );
}

export default App;
