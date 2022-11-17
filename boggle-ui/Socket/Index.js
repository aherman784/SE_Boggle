const app = require("express")();
const http = require("http").Server(app);
const io = require("socket.io")(http, {
  cors: {
    origin: ['http://localhost:8080', 'http://localhost:8080/', 'http://10.69.46.215:8080', 'http://10.69.46.215:8080/'],
    credentials: true
  }
});

io.on("connection", (socket) => {
  console.log('a user connected');
  socket.on("new-message", function(data) {
    io.emit("message", data);
  });
  socket.on('disconnect', () => {
    console.log('a user disconnected');
  })
});

http.listen(80, function() {
  console.log("listening on *:80");
});