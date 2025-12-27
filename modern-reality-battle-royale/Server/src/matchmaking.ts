import { Player } from './player';
import { Lobby } from './lobby';

class Matchmaking {
    private lobbies: Lobby[] = [];

    public createLobby(maxPlayers: number): Lobby {
        const newLobby = new Lobby(maxPlayers);
        this.lobbies.push(newLobby);
        return newLobby;
    }

    public joinLobby(player: Player, lobbyId: string): boolean {
        const lobby = this.lobbies.find(l => l.id === lobbyId);
        if (lobby && lobby.addPlayer(player)) {
            return true;
        }
        return false;
    }

    public leaveLobby(player: Player, lobbyId: string): boolean {
        const lobby = this.lobbies.find(l => l.id === lobbyId);
        if (lobby && lobby.removePlayer(player)) {
            return true;
        }
        return false;
    }

    public getLobbies(): Lobby[] {
        return this.lobbies;
    }
}

export default Matchmaking;