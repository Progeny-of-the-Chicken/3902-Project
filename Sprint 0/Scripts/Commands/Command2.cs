using System;
using Sprint_0;

public class Command2 : ICommand
{
	private Game1 game;

	public Command2(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.SetSprite(new Sprite2(game.GetCenterScreen()));
	}
}
