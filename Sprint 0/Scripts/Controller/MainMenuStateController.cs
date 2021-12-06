using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;
using Sprint_0.Scripts.Commands.MainMenuState;
using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Controller
{
	public class MainMenuStateController : IController
    {
		private Game1 game;
		private Dictionary<Keys, ICommand> controllerMappings;
		private KeyboardState previousKeys;

		public MainMenuStateController(Game1 game)
		{
			this.game = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
			setCommands();
			previousKeys = new KeyboardState();
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
			this.RegisterCommand(Keys.Q, new CommandQuit(game));
			this.RegisterCommand(Keys.W, new CommandMoveSelectionUp());
			this.RegisterCommand(Keys.A, new CommandMoveSelectionLeft());
			this.RegisterCommand(Keys.S, new CommandMoveSelectionDown());
			this.RegisterCommand(Keys.D, new CommandMoveSelectionRight());
			this.RegisterCommand(Keys.Enter, new CommandSelectOption());
			this.RegisterCommand(Keys.E, new CommandStartGame(game));
			this.RegisterCommand(Keys.M, new ToggleMute());
			this.RegisterCommand(Keys.P, new PauseCommand());
		}
	}
}
