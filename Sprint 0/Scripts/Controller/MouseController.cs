using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using Microsoft.Xna.Framework;

public class MouseController : IController
{
	MouseState ms;
	private Game1 game;

	public MouseController(Game1 game)
	{
		this.game = game;
	}

	public void Update()
	{
		ms = Mouse.GetState();
	}
}
