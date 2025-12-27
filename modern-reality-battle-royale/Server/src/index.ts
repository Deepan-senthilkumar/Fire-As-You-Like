import express, { Request, Response } from 'express';
import http from 'http';
import { Server } from 'socket.io';
import { initializeGame } from './game';
import { setupMatchmaking } from './matchmaking';
import { setupNetwork } from './network';

const app = express();
const server = http.createServer(app);
const io = new Server(server);

const PORT = process.env.PORT || 3000;

app.get('/', (req: Request, res: Response) => {
    res.send('Welcome to the Modern Reality Battle Royale Server!');
});

initializeGame(io);
setupMatchmaking(io);
setupNetwork(io);

server.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});
