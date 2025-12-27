import { Server } from 'socket.io';

const io = new Server(3000, {
    cors: {
        origin: "*",
        methods: ["GET", "POST"]
    }
});

io.on('connection', (socket) => {
    console.log(`User connected: ${socket.id}`);

    socket.on('disconnect', () => {
        console.log(`User disconnected: ${socket.id}`);
    });

    socket.on('message', (data) => {
        console.log(`Message received: ${data}`);
        // Handle incoming messages and broadcast to other clients
        socket.broadcast.emit('message', data);
    });

    // Additional event handlers can be added here
});

export default io;