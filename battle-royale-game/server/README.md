# Battle Royale Game Server Documentation

## Overview
This document provides an overview of the server-side architecture and setup for the Battle Royale game project. The server is responsible for managing game state, player connections, and communication between clients.

## Project Structure
The server code is organized as follows:

- **src/**: Contains the main source code for the server.
  - **index.ts**: Entry point for the server application.
  - **controllers/**: Contains controllers that handle game logic.
    - **matchController.ts**: Manages match-related operations.
  - **game/**: Contains game-related classes and logic.
    - **match.ts**: Represents a game match and its state.
  - **networking/**: Handles WebSocket connections and messaging.
    - **ws.ts**: Manages WebSocket communication.
  - **utils/**: Contains utility functions and helpers.

## Setup Instructions
1. **Install Dependencies**: Run `npm install` in the server directory to install the required packages.
2. **Compile TypeScript**: Use `tsc` to compile the TypeScript files into JavaScript.
3. **Start the Server**: Run `node dist/index.js` to start the server.

## API Details
The server exposes various endpoints for client communication. Refer to the individual controller files for specific API details and usage.

## Contribution
For contributions, please follow the project's coding standards and guidelines. Ensure to test your changes thoroughly before submitting a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.