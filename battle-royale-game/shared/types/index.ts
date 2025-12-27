export interface Player {
    id: string;
    name: string;
    health: number;
    position: { x: number; y: number; z: number };
    score: number;
}

export interface Match {
    id: string;
    players: Player[];
    state: 'waiting' | 'in-progress' | 'finished';
    startTime: Date;
    endTime?: Date;
}

export interface GameEvent {
    type: string;
    payload: any;
}

export interface NetworkMessage {
    event: string;
    data: any;
}