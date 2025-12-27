# Battle Royale Game

## Overview
This project is a battle royale game inspired by popular titles like Free Fire and PUBG. It features a multiplayer environment where players compete against each other to be the last one standing.

## Project Structure
The project is divided into three main components: client, server, and shared resources.

### Client
The client-side of the game is built using Unity and includes:
- **Assets**: Contains all game assets including scenes, scripts, prefabs, UI, and shaders.
- **ProjectSettings**: Unity project settings files.

### Server
The server-side is built using TypeScript and includes:
- **src**: Contains the main server logic, including controllers, game management, and networking.
- **package.json**: Lists dependencies and scripts for the server.
- **tsconfig.json**: TypeScript configuration file.

### Shared
This directory contains shared resources between the client and server, including:
- **proto**: Protocol buffer definitions for communication.
- **types**: Shared types and interfaces.

### Documentation
- **docs/design.md**: Design documentation outlining gameplay mechanics and vision.
- **README.md**: General documentation for the entire project.

## Getting Started
To get started with the project, follow these steps:

1. **Clone the repository**:
   ```
   git clone <repository-url>
   ```

2. **Set up the client**:
   - Open the `client` directory in Unity.
   - Import the necessary assets and configure the project settings.

3. **Set up the server**:
   - Navigate to the `server` directory.
   - Install dependencies using npm:
     ```
     npm install
     ```
   - Start the server:
     ```
     npm start
     ```

4. **Run the game**:
   - Launch the client and connect to the server to start playing.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for details.