// import axios from 'Axios';

const app = require("express")();
const http = require("http").Server(app);
const io = require("socket.io")(http, {
  cors: {
    origin: ['http://localhost:8080', 'http://localhost:8080/', 'http://192.168.1.44:8080', 'http://192.168.1.44:8080/'],
    credentials: true
  }
});

io.on("connection", (socket) => {
  console.log('a user connected');

  /* retrieve word guessed 
  send to backend to check if it is valid
  get score as return value
  send score to all users for leaderboard
  */
  socket.on("word-guess", (word) => {
    // send guess to backend
    console.log("Word guessed:", word);
    io.emit("player-score", {UserId: Math.floor(Math.random() * 3.99 + 1), Score: Math.floor(Math.random() * 20)});
  });

  socket.on("start-game", () => {
    // send request to start game
    // get board that is created
    io.emit("game-started", []);
    setTimeout(() => {
      console.log("game ended");
    }, 180000)
  });

  socket.on('disconnect', () => {
    console.log('a user disconnected');
  });
});

http.listen(80, () => {
  console.log("listening on *:80");
});