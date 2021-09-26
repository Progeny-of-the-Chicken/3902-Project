using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint_0;
using Sprint_0.Scripts.Enemy;
using Microsoft.Xna.Framework.Graphics;

public class KeyboardController : IController
{
	KeyboardState ks;
	private Game1 game;

	public KeyboardController(Game1 game)
	{
		this.game = game;
	}

	public void Update(GameTime gt)
    {
		ks = Keyboard.GetState();
	}
}
