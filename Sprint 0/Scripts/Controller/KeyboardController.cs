using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	public class KeyboardController
    {
		//Dictionary Linking keys to commands
		private Dictionary<Keys, ICommand> controllerMappings;
		private Dictionary<Keys, ICommand> linkControllerMappings;
		private int debounceCounter;

		private Game1 game;

		//Previous Keys pressed to limit multiple presses
		KeyboardState previousKeys;

		//Constructor
		public KeyboardController(Game1 game)
		{
			this.game = game;

			controllerMappings = new Dictionary<Keys, ICommand>();
			linkControllerMappings = new Dictionary<Keys, ICommand>();

			debounceCounter = 0;

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
				executeCommandsForKey(key, controllerMappings);
				executeCommandsForKey(key, linkControllerMappings);
			}

			previousKeys = keyboardState;
			debounceCounter--;
			debounceCounter %= 29;
		}


		/*---------------- Helper Methods ---------------*/

		private bool IsMovementKey(Keys key)
        {
			return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D;

		}

		private bool MovementKeyIsBeingHeldDown(Keys key, KeyboardState previousKeys)
        {
			if (IsMovementKey(key) && debounceCounter == 0)
            {
				if(previousKeys.IsKeyDown(key))
                {
					debounceCounter = 29;
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
