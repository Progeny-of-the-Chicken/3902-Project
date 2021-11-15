using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	public class PausedKeyboardController : IController
	{
		private Game1 game;
		private Dictionary<Keys, ICommand> controllerMappings;
		private KeyboardState previousKeys;

		public PausedKeyboardController(Game1 game, KeyboardState prevState)
		{
			this.game = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
			setCommands();
			previousKeys = prevState;
		}

		public void Update()
		{
			KeyboardState keyboardState = Keyboard.GetState();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				// Execute bound command once every press
				if (controllerMappings.ContainsKey(key) && previousKeys.IsKeyUp(key))
				{
					controllerMappings[key].Execute();
				}
			}

			previousKeys = keyboardState;
		}


		//----- Helper methods for setting up key bindings -----//

		private void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		private void setCommands()
		{
			this.RegisterCommand(Keys.M, new ToggleMute());
			this.RegisterCommand(Keys.P, new PauseCommand());
		}
	}
}
