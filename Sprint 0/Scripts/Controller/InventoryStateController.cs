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
		private bool paused = false;

		public InventoryStateController(Game1 game)
		{
			this.game = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
			setCommands();
		}

		public void Update()
		{
			KeyboardState keyboardState = Keyboard.GetState();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			if (!paused)
			{
				foreach (Keys key in pressedKeys)
				{
					// Execute bound command once every press
					if (controllerMappings.ContainsKey(key) && previousKeys.IsKeyUp(key))
					{
						controllerMappings[key].Execute();
					}
				}
			} else
            {
				// This checks specifically for the pause key because we don't want to
				// be able to fire any other commands than the pause command while paused.
				if (pauseKeyPressed(pressedKeys) && previousKeys.IsKeyUp(Keys.P))
				{
					controllerMappings[Keys.P].Execute();
				}
			}

			previousKeys = keyboardState;
		}

		public void SetPauseState(bool paused)
		{
			this.paused = paused;
		}


		//----- Helper methods for setting up key bindings -----//

		private void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		private void setCommands()
		{
			this.RegisterCommand(Keys.W, new CommandMoveSelectionUp(game));
			this.RegisterCommand(Keys.A, new CommandMoveSelectionLeft(game));
			this.RegisterCommand(Keys.S, new CommandMoveSelectionDown(game));
			this.RegisterCommand(Keys.D, new CommandMoveSelectionRight(game));
			this.RegisterCommand(Keys.B, new CommandSelectWeapon(game));
			this.RegisterCommand(Keys.R, new CommandReturnToGameState(game));
			this.RegisterCommand(Keys.Space, new CommandPauseGame(game));
			this.RegisterCommand(Keys.M, new ToggleMute());
			this.RegisterCommand(Keys.P, new PauseCommand());
		}

		private bool pauseKeyPressed(Keys[] pressedKeys)
		{
			for (int i = 0; i < pressedKeys.Length; i++)
			{
				if (pressedKeys[i] == Keys.P)
				{
					return true;
				}
			}

			return false;
		}
	}
}
