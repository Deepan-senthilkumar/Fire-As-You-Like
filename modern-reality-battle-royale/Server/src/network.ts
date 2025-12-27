export function setupNetwork(io: any) {
    io.on('connection', (socket: any) => {
        socket.on('message', (data: any) => {
            socket.broadcast.emit('message', data);
        });
    });
}
