const axios = require('axios');
const app = require("express")();
const http = require("http").Server(app);
const io = require("socket.io")(http, {
  cors: {
    origin: ['http://localhost:8080', 'http://localhost:8080/'],
    credentials: true
  }
});
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;
let players = [];
let isGameStarted = false;
io.on("connection", (socket) => {
  console.log('a user connected');

  socket.on("player-joined", (playerInfo) => {
    players.push(playerInfo);
    io.emit("update-player-info", players);
  })

  socket.on("is-game-started", () => {
    io.emit("is-game-started", isGameStarted);
  });

  socket.on("is-game-in-session", (playerInfo) => {
    io.emit("game-in-session-status", {status: isGameStarted, player: playerInfo});
  })

  /* retrieve word guessed 
  send to backend to check if it is valid
  get score as return value
  send score to all users for leaderboard
  */
  socket.on("word-guess", (playerWord) => {
    // send guess to backend
    console.log("Word guessed:", playerWord.Word);
    axios.post(`https://localhost:7147/api/WordClient?wordGuessed=${playerWord.Word}&playerId=${playerWord.PlayerId}`).then((isValid) => {
      if (isValid) {
        let score;
        if (playerWord.Word.length < 5) {
          score = 1;
        } else if (playerWord.Word.length < 6) {
          score = 2;
        } else if (playerWord.Word.length < 7) {
          score = 3;
        } else if (playerWord.Word.length < 8) {
          score = 4;
        } else {
          score = 11;
        }
        for (let player of players) {
          if (player.Id === playerWord.PlayerId) {
            player.Score = score;
            break;
          }
        }
        io.emit("update-player-info", players);
      }
    });
  });

  socket.on("start-game", () => {
    // send request to start game
    // get board that is created.
    axios.delete('https://localhost:7147/api/WordClient').then(() => {
      axios.delete('https://localhost:7147/api/PlayerClient').then(() => {
        axios.post('https://localhost:7147/api/PlayerClient', players).then(() => {
          axios.get('https://localhost:7147/api/BoardClient').then((board) => {
            console.log(board.data);
            const boardArray = [];
            io.emit("update-player-info", players);
            iBoard = [];
            for (let i = 0; i < board.data.length; i++) {
              iBoard.push(board.data[i]);
              if (iBoard.length === 4) {
                boardArray.push(iBoard);
                iBoard = [];
              }
            }
            console.log(boardArray);
            io.emit("game-started", boardArray);
            let secondsLeft = 60;
            isGameStarted = true;
            io.emit("is-game-started", true);
            let interval = setInterval(() => {
              secondsLeft -= 1;
              console.log(secondsLeft);
              io.emit("time-left", secondsLeft);
              if (secondsLeft <= 0) {
                isGameStarted = false;
                console.log("game ended");
                io.emit("is-game-started", false);
                clearInterval(interval);
              }
            }, 1000);
          });
        })
      });
    });
  });

  socket.on('disconnect', () => {
    console.log('a user disconnected');
  });
});

http.listen(80, () => {
  console.log("listening on *:80");
});