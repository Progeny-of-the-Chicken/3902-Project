using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint_0;
using Sprint_0.Scripts.Enemy;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	public class KeyboardController
    {
		//Dictionary Linking keys to commands
		private Dictionary<Keys, ICommand> controllerMappings;
		private Game1 game;
		private CommandNextItem nextItem;
		private CommandLastItem lastItem;
		private CommandShootArrow useFirstItem;
		private CommandThrowBoomerangLink useSecondItem;
		private CommandCastFireSpell useThirdItem;
		private CommandPlaceBomb useFourthItem;

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
			this.RegisterCommand(Keys.O, new PrevEnemy(game));
			this.RegisterCommand(Keys.P, new NextEnemy(game));
			this.RegisterCommand(Keys.D1, new CommandShootArrow(game));
			this.RegisterCommand(Keys.D2, new CommandThrowBoomerangLink(game));
			this.RegisterCommand(Keys.D3, new CommandCastFireSpell(game));
			this.RegisterCommand(Keys.D4, new CommandPlaceBomb(game));
			this.RegisterCommand(Keys.U, new CommandNextItem(game));
			this.RegisterCommand(Keys.I, new CommandLastItem(game));
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
}
