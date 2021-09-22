using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;

public class MouseController : IController
{
	MouseState ms;
	CommandQuit cq;
	private Game1 game;

	public MouseController(Game1 game)
	{
		this.game = game;
		cq = new CommandQuit(this.game);
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
			
		}
	}
}
