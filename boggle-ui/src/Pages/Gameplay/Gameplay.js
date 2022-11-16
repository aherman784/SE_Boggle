import { useState } from 'react';
import './Gameplay.scss';

export function Gameplay() {
    const [boardLetters, setBoardLetters] = useState([
        ['A', 'B', 'C', 'D'],
        ['E', 'F', 'G', 'H'],
        ['I', 'J', 'K', 'L'],
        ['M', 'N', 'O', 'P']
    ]);
    const [players, setPlayers] = useState([
        {Username: 'Logan', Score: 11},
        {Username: 'Hunter', Score: 17},
        {Username: 'Matthew', Score: 8},
        {Username: 'Alex', Score: 14},

    ]);
    return(
        <div className="gameplay-container">
            <div className='grid-and-leaderboard'>
                <div className='grid-container'>
                    {boardLetters.map(row => (
                        row.map(letter => (
                            <div className='grid-item'>{letter}</div>
                        ))
                    ))}
                </div>
                <div className='leaderboard-container'>
                    <div className='leaderboard-header'>Leaderboard:</div>
                    {players.sort((a, b) => b.Score - a.Score).map(player => (
                        <div className='leaderboard-player-container'>
                            <div className='leaderboard-player-score'>{player.Score}</div>
                            &nbsp;
                            <div className='leaderboard-player-name'>{player.Username}</div>
                        </div>
                    ))}
                </div>
            </div>
            <div className='word-bank'>
                
            </div>
        </div>
    );
}