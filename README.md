# Cheat Code Input System for Unity

The Cheat Code Input System is a simple script for Unity that allows you to implement cheat codes in your games. Players can enter specific key sequences to activate or deactivate cheats, providing additional features or gameplay enhancements.

## Features

- Define multiple cheat codes with unique key sequences
- Supports any key on the keyboard as part of the cheat code
- Uses PlayerPrefs to store cheat states persistently
- Utilizes UnityEvents to customize behavior on cheat activation or deactivation

## Usage

1. Attach the `CheatsInput` script to a GameObject in your Unity scene.
2. In the Inspector, define the cheat codes by adding elements to the `Cheat Codes` array.
   - Specify the cheat key (PlayerPrefs key) for each cheat code.
   - Define the key sequence by adding KeyCode values to the `Sequence` array.
   - Customize the behavior by assigning UnityEvents to the `On Cheat Activated` and `On Cheat Deactivated` events.
4. Build and run your game.
5. Players can now enter the specified key sequences during gameplay to activate or deactivate cheats.
6. I personally don't like to perform any unneccesary processing during gameplay time for performance reasons, so I reccomend adding the cheat code input to your main menu scene although it can be used during gameplay if desired.
   
## License

This project is licensed under the [MIT License](LICENSE).

## Contributing

Contributions are welcome! Please feel free to open an issue or submit a pull request.

## Acknowledgments

This cheat code input system is inspired by the popular cheat code mechanics in classic video games.

---

**Note**: This is a simple cheat code input system meant to demonstrate the basic concept. Make sure to adapt it to your specific game requirements and add any necessary error handling or security measures.
