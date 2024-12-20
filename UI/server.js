const express = require('express');
const app = express();
const path = require('path');
const http = require('http');
const server = http.createServer(app);

app.use(express.static('public'));
app.use('/node_modules', express.static(path.join(__dirname, 'node_modules')));

app.get('/', (req, res) => {
    res.sendFile(__dirname + '/views/index.html');
});

server.listen(3001, () => {
    console.log('listening on *:3001');
});