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

		//Constructor
		public MouseController(Game1 game)
		{
			this.game = game;

			oldState = Mouse.GetState();
		}

		//Update checks for keys pressed and calls the respective command
		public void Update()
		{
			newState = Mouse.GetState();

			if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
			{
				// Execute on left click
            } else if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
				// Execute on right click
            }

			oldState = newState;
		}
	}
}

