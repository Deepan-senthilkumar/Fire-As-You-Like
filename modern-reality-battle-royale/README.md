# Modern Reality Battle Royale

## Overview
Modern Reality Battle Royale is an engaging multiplayer battle royale game that combines fast-paced action with strategic gameplay. Players are dropped into a vast arena where they must compete against each other to be the last one standing. The game features a variety of weapons, player mechanics, and dynamic environments to enhance the gaming experience.

## Features
- **Core Game Logic**: Robust scripts for game management and initialization.
- **Player Mechanics**: Detailed scripts for player movement, health management, and actions.
- **Weapon System**: Comprehensive weapon behaviors including shooting mechanics and weapon switching.
- **User Interface**: Intuitive UI elements for menus, HUD, and score displays.
- **Networking**: Efficient client-server communication for real-time gameplay.
- **Custom Assets**: A variety of prefabs, shaders, audio files, and materials to enrich the game world.

## Getting Started
To set up the project locally, follow these steps:

1. **Clone the Repository**:
   ```
   git clone <repository-url>
   cd modern-reality-battle-royale
   ```

2. **Install Dependencies**:
   Navigate to the `Server` directory and install the necessary packages:
   ```
   cd Server
   npm install
   ```

3. **Run the Server**:
   Start the server by running:
   ```
   npm start
   ```

4. **Open the Game**:
   Open the `Main.unity` scene in Unity to start developing and testing the game.

## Deployment & CI
- Server Dockerfile and local run script available at `server/Dockerfile` and `scripts/run-server-docker.ps1`.
- GitHub Actions workflow builds and pushes server image to GHCR: `.github/workflows/docker-image.yml`.
- Kubernetes manifests and Agones example are available under `infra/`.


## Documentation
For more detailed information on the design and networking architecture, please refer to the following documents in the `Docs` directory:
- [DESIGN.md](Docs/DESIGN.md)
- [NETWORKING.md](Docs/NETWORKING.md)

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.