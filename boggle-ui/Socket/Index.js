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
io.on("connection", (socket) => {
  console.log('a user connected');

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
        io.emit("player-score", {UserId: playerWord.PlayerId, Score: score});
      }
    });
  });

  socket.on("start-game", () => {
    // send request to start game
    // get board that is created
    console.log("game started")
    io.emit("game-started", []);
    let secondsLeft = 180;
    let interval = setInterval(() => {
      secondsLeft -= 1;
      console.log(secondsLeft);
      if (secondsLeft <= 0) {
        console.log("game ended");
        clearInterval(interval);
      }
    }, 1000);
  });

  socket.on('disconnect', () => {
    console.log('a user disconnected');
  });
});

http.listen(80, () => {
  console.log("listening on *:80");
});