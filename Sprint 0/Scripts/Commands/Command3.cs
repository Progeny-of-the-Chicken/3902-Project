using System;
using Sprint_0;

public class Command3 : ICommand
{
	private Game1 game;

	public Command3(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.SetSprite(new Sprite3(game.GetCenterScreen()));
	}
}
