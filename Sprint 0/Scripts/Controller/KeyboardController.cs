using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;

public class KeyboardController : IController
{
	//Dictionary Linking keys to commands
	private Dictionary<Keys, ICommand> controllerMappings;
	private Game1 game;

	//Previous Keys pressed to limit multiple presses
	KeyboardState previousKeys;

	//Constructor
	public KeyboardController(Game1 game)
    {
		controllerMappings = new Dictionary<Keys, ICommand>();
		this.game = game;
		Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
		setCommands();
    }

	//Method to add new keybinds for commands
	public void RegisterCommand(Keys key, ICommand command)
    {
		controllerMappings.Add(key, command);
    }

	//Add keybinds here
	private void setCommands()
    {
		//Just for sprint 2
		this.RegisterCommand(Keys.T, new BlockReverseCycle(game));
		this.RegisterCommand(Keys.Y, new BlockForwardCycle(game));
    }

	//Update checks for keys pressed and calls the respective command
	public void Update()
    {
		KeyboardState keyboardState = Keyboard.GetState();
		Keys[] pressedKeys = keyboardState.GetPressedKeys();

		foreach (Keys key in pressedKeys)
        {
			if (previousKeys.IsKeyUp(key))
			{
				controllerMappings[key].Execute(); //Currently throws errors if you press buttons not in the dictionary
			}
        }

		previousKeys = keyboardState;
    }
}
