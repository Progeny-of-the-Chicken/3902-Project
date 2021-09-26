using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint_0;
using Sprint_0.Scripts.Enemy;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Commands;

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
		RegisterCommand(Keys.O, new PrevEnemy(game));
		RegisterCommand(Keys.P, new NextEnemy(game));
	}

	//Update checks for keys pressed and calls the respective command
	public void Update()
	{
		KeyboardState keyboardState = Keyboard.GetState();
		Keys[] pressedKeys = keyboardState.GetPressedKeys();

		foreach (Keys key in pressedKeys)
		{
			// Make sure key has mapping
			if (!controllerMappings.ContainsKey(key))
				return;


			if (previousKeys.IsKeyUp(key))
			{
				controllerMappings[key].Execute(); //Currently throws errors if you press buttons not in the dictionary
			}
		}

		previousKeys = keyboardState;
	}
}
