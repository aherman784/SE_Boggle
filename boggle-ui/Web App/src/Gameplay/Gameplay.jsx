import { useEffect, useState } from 'react';
import './Gameplay.scss';
import io from 'socket.io-client';

const host = window.location;
console.log(host);
const socket = io.connect('http://10.69.46.215:80', {
  withCredentials: true
});

export function Gameplay() {
    const [isGameStarted, setIsGameStarted] = useState(true);
    const [wordInput, setWordInput] = useState('');
    const [boardLetters, setBoardLetters] = useState([
        ['A', 'B', 'C', 'D'],
        ['E', 'F', 'G', 'H'],
        ['I', 'J', 'K', 'L'],
        ['M', 'N', 'O', 'P'],
    ]);
    const [players, setPlayers] = useState([
        {Id: 1, Username: 'Logan', Score: 11},
        {Id: 2, Username: 'Hunter', Score: 17},
        {Id: 3, Username: 'Matthew', Score: 8},
        {Id: 4, Username: 'Alex', Score: 14},
    ]);
    const [wordsGuessed, setWordsGuessed] = useState([
        'aa',
        'aaa',
        'aachen',
        'aardvark',
        'aardvarks',
        'aaron',
        'ab',
        'aba',
        'ababa',
        'abaci',
        'aback',
        'abactor',
        'abactors',
        'abacus',
        'abacuses',
        'abaft',
        'abalone',
        'abandon',
        'abandoned',
        'abandonee',
        'abandonees',
        'abandoning',
        'abandonment',
        'abandons',
        'abase',
        'abased',
        'abasement',
        
    ]);

    useEffect(() => {
        socket.on('message', (message) => {
        //   console.log(message);
        setWordInput(message);
        });
        // socket.emit('new-message', 'test message');
      }, []);

      useEffect(() => {
        socket.emit('new-message', wordInput);
      }, [wordInput]);

    return(
        <div className="gameplay-container">
            <div className="game-title">
                Boggle
            </div>
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
                <div className='word-bank-header'>
                    <div className='word-guess-search'>
                        <input className='word-guess-input' value={wordInput} onChange={(e) => setWordInput(e.target.value)}></input>
                        <button className='word-guess-enter'>Enter</button>
                    </div>
                    <div className='player-score'>Score: 11</div>
                </div> 
                <div className='word-bank-words'>
                    {wordsGuessed.map(word => (
                        <div className='word-bank-word'>{word}</div>
                    ))}
                </div>
            </div>
        </div>
    );
}