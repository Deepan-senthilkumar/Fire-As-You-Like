export function setupMatchmaking(io: any) {
    io.of('/match').on('connection', (socket: any) => {
        socket.on('match:create', (payload: any) => {
            socket.emit('match:created', { ok: true });
        });
        socket.on('match:join', (payload: any) => {
            socket.emit('match:joined', { ok: true });
        });
    });
}
