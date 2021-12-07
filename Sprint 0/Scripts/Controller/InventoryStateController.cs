using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;
using Sprint_0.Scripts.Commands.InventoryState;

namespace Sprint_0.Scripts.Controller
{
	public class InventoryStateController : IController
    {
		private Game1 game;
		private Dictionary<Keys, ICommand> controllerMappings;
		private KeyboardState previousKeys;

		public InventoryStateController(Game1 game)
		{
			this.game = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
			setCommands();
			//Start with E pressed so the state doesn't immediately switch back
			Keys[] startKeys = { Keys.E };
			previousKeys = new KeyboardState(startKeys);
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
			this.RegisterCommand(Keys.W, new CommandMoveSelectionUp(game));
			this.RegisterCommand(Keys.A, new CommandMoveSelectionLeft(game));
			this.RegisterCommand(Keys.S, new CommandMoveSelectionDown(game));
			this.RegisterCommand(Keys.D, new CommandMoveSelectionRight(game));
			this.RegisterCommand(Keys.E, new CommandReturnToGameState(game));
			this.RegisterCommand(Keys.M, new ToggleMute());
			this.RegisterCommand(Keys.P, new PauseCommand());
		}
	}
}
