# Battle Royale Game Client

## Overview
This project is a multiplayer battle royale game, inspired by popular titles like Free Fire and PUBG. The client-side of the game is built using Unity and includes various components such as player controls, networking, and user interface elements.

## Project Structure
The client-side project is organized as follows:

- **Assets**: Contains all game assets including scenes, scripts, prefabs, UI elements, and shaders.
  - **Scenes**: Main scene of the game.
  - **Scripts**: Contains the logic for game management, player control, and networking.
  - **Prefabs**: Player character prefab.
  - **UI**: User interface scripts.
  - **Shaders**: Custom shaders for visual effects.
  
- **ProjectSettings**: Unity project settings files.

## Setup Instructions
1. **Clone the Repository**: 
   ```
   git clone <repository-url>
   cd battle-royale-game/client
   ```

2. **Open in Unity**: Open the project in Unity Hub and select the `client` directory.

3. **Build Settings**: Ensure the correct platform is selected in the Build Settings.

4. **Run the Game**: Press the play button in Unity to start the game.

## Gameplay Details
- Players will be dropped into a large map where they must scavenge for weapons and resources.
- The last player or team standing wins the match.
- Players can interact with the environment and other players through various controls.

## Networking
The game utilizes a client-server architecture for multiplayer functionality. The `NetworkManager` handles connections and player synchronization.

## Contribution
Feel free to contribute to the project by submitting issues or pull requests. For any questions, please contact the project maintainers.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.