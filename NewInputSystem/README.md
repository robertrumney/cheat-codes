# Cheat Code System for Unity (New Input System)

## Overview
This repository contains a Cheat Code System specifically designed for Unity projects that are utilizing the new Unity Input System. The system allows developers to define cheat codes through sequences of key presses. When a user correctly inputs a designated sequence, a corresponding cheat is activated or deactivated.

## Features
- **Cheat Code Definition**: Define cheat codes with sequences of keys.
- **Event Handling**: Assign UnityEvents to be invoked when cheats are activated or deactivated.
- **Persistence**: Option to save the state of cheats (activated/deactivated) between game sessions.
- **New Unity Input System Compatibility**: Fully compatible with Unity's newer, more versatile input system.

## Differences from the Previous Version
The main difference between this version of the Cheat Code System and the previous one lies in the input handling mechanism:

- **Old Version**: Used Unity's traditional input system (`Input.GetKeyDown`), checking each frame for key presses.
- **New Version**: Utilizes the new Unity Input System, providing a more flexible and robust input handling solution. This version directly reads raw key inputs without the need for an Input Actions asset, simplifying the process and reducing setup overhead.

## How to Use
1. **Attach the Script**: Attach the `CheatCodes.cs` script to any active GameObject in your scene.
2. **Define Cheat Codes**: In the Inspector, define your cheat codes by specifying the key sequences and corresponding events.
3. **Key Type**: Ensure your cheat sequences are using values from the `Key` enumeration (e.g., `Key.A`, `Key.Space`) to match the keys you want for your cheat codes.
4. **Test Your Cheats**: Run your game and test each cheat code to ensure the input detection and cheat activation/deactivation work as expected.

## Contributing
Contributions to the Cheat Code System are welcome! If you have suggestions or improvements, feel free to fork this repository and submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE.md) - see the LICENSE file for details.
