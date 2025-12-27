export class MatchController {
    private matches: Map<string, Match>;

    constructor() {
        this.matches = new Map();
    }

    public startMatch(matchId: string): void {
        if (!this.matches.has(matchId)) {
            const match = new Match(matchId);
            this.matches.set(matchId, match);
            match.start();
        }
    }

    public endMatch(matchId: string): void {
        const match = this.matches.get(matchId);
        if (match) {
            match.end();
            this.matches.delete(matchId);
        }
    }

    public getMatchStatus(matchId: string): string | null {
        const match = this.matches.get(matchId);
        return match ? match.getStatus() : null;
    }

    public addPlayerToMatch(matchId: string, playerId: string): void {
        const match = this.matches.get(matchId);
        if (match) {
            match.addPlayer(playerId);
        }
    }

    public removePlayerFromMatch(matchId: string, playerId: string): void {
        const match = this.matches.get(matchId);
        if (match) {
            match.removePlayer(playerId);
        }
    }
}