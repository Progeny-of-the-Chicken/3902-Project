using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
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
			this.game = game;

			controllerMappings = new Dictionary<Keys, ICommand>();
			linkControllerMappings = new Dictionary<Keys, ICommand>();

			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			setCommands();
		}

		//Method to add new keybinds for commands
		public void RegisterCommand(Dictionary<Keys, ICommand> mappings, Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		//Add keybinds here
		private void setCommands()
		{
			this.RegisterCommand(controllerMappings, Keys.Q, new CommandQuit(game));
			this.RegisterCommand(controllerMappings, Keys.I, new CommandEnterInventory(game));

			this.RegisterCommand(linkControllerMappings, Keys.W, new LinkChangeDirectionUp(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.A, new LinkChangeDirectionLeft(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.S, new LinkChangeDirectionDown(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.D, new LinkChangeDirectionRight(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.N, new LinkUseSword(game.link, game));
			this.RegisterCommand(linkControllerMappings, Keys.B, new CommandUseSecondaryItem(game));
			this.RegisterCommand(linkControllerMappings, Keys.E, new LinkTakeDamage(game.link));
			this.RegisterCommand(controllerMappings, Keys.M, new ToggleMute());
		}

		//Update checks for keys pressed and calls the respective command
		public void Update()
		{
			KeyboardState keyboardState = Keyboard.GetState();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				executeCommandsForKey(key, controllerMappings);
				if(!game.link.IsSuspended)
				{
					executeCommandsForKey(key, linkControllerMappings);
				}
			}

			previousKeys = keyboardState;
		}


		/*---------------- Helper Methods ---------------*/

		private bool IsMovementKey(Keys key)
        {
			return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D;

		}

		private bool MovementKeyIsBeingHeldDown(Keys key, KeyboardState previousKeys)
        {
			if (IsMovementKey(key))
            {
				if(previousKeys.IsKeyDown(key))
                {
					return true;
                }
            }
			return false;
        }

		private void executeCommandsForKey(Keys key, Dictionary<Keys, ICommand> mappings)
        {
			if (mappings.ContainsKey(key) && (previousKeys.IsKeyUp(key) || MovementKeyIsBeingHeldDown(key, previousKeys)))
			{
				mappings[key].Execute();
			}
		}
	}
}
