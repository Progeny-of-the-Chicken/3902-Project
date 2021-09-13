using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;

public class MouseController : IController
{
	MouseState ms;
	CommandQuit cq;
	Command1 c1;
	Command2 c2;
	Command3 c3;
	Command4 c4;
	private Game1 game;

	public MouseController(Game1 game)
	{
		this.game = game;
		cq = new CommandQuit(this.game);
		c1 = new Command1(this.game);
		c2 = new Command2(this.game);
		c3 = new Command3(this.game);
		c4 = new Command4(this.game);
		ms = Mouse.GetState();
	}

	public void Update()
	{
		ms = Mouse.GetState();
		if (ms.RightButton == ButtonState.Pressed)
		{
			cq.Execute();
		}
		else if (ms.LeftButton == ButtonState.Pressed)
		{
			if (ms.Y < game.GetCenterScreen().Y)
			{
				if (ms.X < game.GetCenterScreen().X)
				{
					c1.Execute();
				}
				else
				{
					c2.Execute();
				}
			}
			else
			{
				if (ms.X < game.GetCenterScreen().X)
				{
					c3.Execute();
				}
				else
				{
					c4.Execute();
				}
			}
		}
	}
}
