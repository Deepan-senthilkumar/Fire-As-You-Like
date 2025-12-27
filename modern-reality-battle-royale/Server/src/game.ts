export function initializeGame(io: any) {
    io.of('/game').on('connection', (socket: any) => {
        socket.on('player:join', (data: any) => {
            socket.emit('game:welcome', { ok: true });
        });
        socket.on('disconnect', () => {});
    });
}
