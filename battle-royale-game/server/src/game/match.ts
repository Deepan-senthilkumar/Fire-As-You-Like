export class Match {
    private players: Map<string, Player>;
    private state: string;
    private matchId: string;

    constructor(matchId: string) {
        this.matchId = matchId;
        this.players = new Map();
        this.state = 'waiting'; // initial state
    }

    public addPlayer(player: Player): void {
        if (this.state === 'waiting') {
            this.players.set(player.id, player);
        }
    }

    public removePlayer(playerId: string): void {
        this.players.delete(playerId);
    }

    public startMatch(): void {
        if (this.players.size > 1) {
            this.state = 'in_progress';
            // Additional logic to start the match
        }
    }

    public endMatch(): void {
        this.state = 'finished';
        // Additional logic to handle end of match
    }

    public getMatchState(): string {
        return this.state;
    }

    public getPlayers(): Player[] {
        return Array.from(this.players.values());
    }
}

class Player {
    public id: string;
    public name: string;

    constructor(id: string, name: string) {
        this.id = id;
        this.name = name;
    }
}