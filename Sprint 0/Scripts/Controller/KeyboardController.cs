using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint_0;

public class KeyboardController : IController
{
	KeyboardState ks;
	CommandQuit cq;
	Command1 c1;
	Command2 c2;
	Command3 c3;
	Command4 c4;
	private Game1 game;

	public KeyboardController(Game1 game)
	{
		this.game = game;
		cq = new CommandQuit(this.game);
		c1 = new Command1(this.game);
		c2 = new Command2(this.game);
		c3 = new Command3(this.game);
		c4 = new Command4(this.game);
		ks = Keyboard.GetState();
	}

	public void Update()
    {
		ks = Keyboard.GetState();
		if (ks.IsKeyDown(Keys.D0) || ks.IsKeyDown(Keys.NumPad0))
        {
			cq.Execute();
        } else if (ks.IsKeyDown(Keys.D1) || ks.IsKeyDown(Keys.NumPad1))
		{
			c1.Execute();
		}
		else if (ks.IsKeyDown(Keys.D2) || ks.IsKeyDown(Keys.NumPad2))
		{
			c2.Execute();
		}
		else if (ks.IsKeyDown(Keys.D3) || ks.IsKeyDown(Keys.NumPad3))
		{
			c3.Execute();
		}
		else if (ks.IsKeyDown(Keys.D4) || ks.IsKeyDown(Keys.NumPad4))
		{
			c4.Execute();
		}
	}
}
