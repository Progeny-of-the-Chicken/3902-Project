using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;

public class KeyboardController : IController
{
	//Dictionary Linking keys to commands
	private Dictionary<Keys, ICommand> controllerMappings;
	private Dictionary<Keys, ICommand> linkControllerMappings;
	private Game1 game;

	//Previous Keys pressed to limit multiple presses
	KeyboardState previousKeys;

	//Constructor
	public KeyboardController(Game1 game)
    {
		controllerMappings = new Dictionary<Keys, ICommand>();
		linkControllerMappings = new Dictionary<Keys, ICommand>();
		this.game = game;
		Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
		setCommands();
    }

	//Method to add new keybinds for commands
	public void RegisterCommand(Dictionary<Keys, ICommand> dictionary, Keys key, ICommand command)
    {
		dictionary.Add(key, command);
    }

	//Add keybinds here
	private void setCommands()
    {
		//Just for sprint 2
		this.RegisterCommand(controllerMappings, Keys.T, new BlockReverseCycle(game));
		this.RegisterCommand(controllerMappings, Keys.Y, new BlockForwardCycle(game));

		this.RegisterCommand(linkControllerMappings, Keys.W, new Sprint_0.Scripts.Commands.LinkChangeDirectionUp(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.A, new Sprint_0.Scripts.Commands.LinkChangeDirectionLeft(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.S, new Sprint_0.Scripts.Commands.LinkChangeDirectionDown(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.D, new Sprint_0.Scripts.Commands.LinkChangeDirectionRight(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.N, new Sprint_0.Scripts.Commands.LinkUseSword(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.Z, new Sprint_0.Scripts.Commands.LinkUseSword(game.link));
		this.RegisterCommand(linkControllerMappings, Keys.E, new Sprint_0.Scripts.Commands.LinkTakeDamage(game.link));
	}

	//Update checks for keys pressed and calls the respective command
	public void Update()
    {
		KeyboardState keyboardState = Keyboard.GetState();
		Keys[] pressedKeys = keyboardState.GetPressedKeys();

		foreach (Keys key in pressedKeys)
        {
			// Make sure key has mapping and previous key is up before executing it
			if (controllerMappings.ContainsKey(key) && previousKeys.IsKeyUp(key))
				controllerMappings[key].Execute();

			if (linkControllerMappings.ContainsKey(key) && previousKeys.IsKeyUp(key) && !game.link.IsMoving())
            {
				linkControllerMappings[key].Execute();
			}
				
        }

		previousKeys = keyboardState;
    }
}
