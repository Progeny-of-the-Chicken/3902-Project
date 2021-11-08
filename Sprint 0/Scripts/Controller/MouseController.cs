using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	//This entire controller is just for sprint 3
	public class MouseController
    {
		private Game1 game;

		MouseState newState = Mouse.GetState();
		MouseState oldState;
		CommandNextRoom cnr;
		CommandPrevRoom cpr;

		//Constructor
		public MouseController(Game1 game)
		{
			this.game = game;
			cnr = new CommandNextRoom(game);
			cpr = new CommandPrevRoom(game);

			oldState = Mouse.GetState();
		}

		//Update checks for keys pressed and calls the respective command
		public void Update()
		{
			newState = Mouse.GetState();

			if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
			{
				cnr.Execute();
            } else if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
				cpr.Execute();
            }

			oldState = newState;
		}
	}
}

