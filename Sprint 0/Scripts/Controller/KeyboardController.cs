using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;
using System.Diagnostics;

namespace Sprint_0.Scripts.Controller
{
	public class KeyboardController
    {
		//Dictionary Linking keys to commands
		private Dictionary<Keys, ICommand> controllerMappings;
		private Dictionary<Keys, ICommand> linkControllerMappings;

		private Game1 game;

		//Previous Keys pressed to limit multiple presses
		KeyboardState previousKeys;

		KeyboardState keyboardState;

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
			mappings.Add(key, command);
		}

		//Add keybinds here
		private void setCommands()
		{
			//Just for sprint 2
			this.RegisterCommand(controllerMappings, Keys.T, new BlockReverseCycle(game));
			this.RegisterCommand(controllerMappings, Keys.Y, new BlockForwardCycle(game));
			this.RegisterCommand(controllerMappings, Keys.O, new PrevEnemy(game));
			this.RegisterCommand(controllerMappings, Keys.P, new NextEnemy(game));
			this.RegisterCommand(controllerMappings, Keys.D1, new CommandShootArrow(game));
			this.RegisterCommand(controllerMappings, Keys.D2, new CommandThrowBoomerangLink(game));
			this.RegisterCommand(controllerMappings, Keys.D3, new CommandCastFireSpell(game));
			this.RegisterCommand(controllerMappings, Keys.D4, new CommandPlaceBomb(game));
			this.RegisterCommand(controllerMappings, Keys.U, new CommandNextItem(game));
			this.RegisterCommand(controllerMappings, Keys.I, new CommandLastItem(game));
			this.RegisterCommand(controllerMappings, Keys.N, new Sprint_0.Scripts.Commands.LinkUseSword(game.link));
			this.RegisterCommand(controllerMappings, Keys.Z, new Sprint_0.Scripts.Commands.LinkUseSword(game.link));
			this.RegisterCommand(controllerMappings, Keys.E, new Sprint_0.Scripts.Commands.LinkTakeDamage(game.link));

			// Link movement commands
			this.RegisterCommand(linkControllerMappings, Keys.W, new Sprint_0.Scripts.Commands.LinkChangeDirectionUp(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.A, new Sprint_0.Scripts.Commands.LinkChangeDirectionLeft(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.S, new Sprint_0.Scripts.Commands.LinkChangeDirectionDown(game.link));
			this.RegisterCommand(linkControllerMappings, Keys.D, new Sprint_0.Scripts.Commands.LinkChangeDirectionRight(game.link));
		}

		//Update checks for keys pressed and calls the respective command
		public void Update()
		{
			keyboardState = Keyboard.GetState();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				executeCommandsForKey(key, controllerMappings);
				executeMovementCommandsForKey(key, linkControllerMappings);
			}

			previousKeys = keyboardState;
		}


		/*---------------- Helper Methods ---------------*/

		private void executeCommandsForKey(Keys key, Dictionary<Keys, ICommand> mappings)
        {
			// Make sure key has mapping
			if (!mappings.ContainsKey(key))
				return;


			if (previousKeys.IsKeyUp(key))
			{
				mappings[key].Execute();
			}
		}

		private void executeMovementCommandsForKey(Keys key, Dictionary<Keys, ICommand> mappings)
        {
			// Make sure key has mapping
			if (!mappings.ContainsKey(key))
            {
				return;
			}

			mappings[key].Execute();
		}
	}
}
