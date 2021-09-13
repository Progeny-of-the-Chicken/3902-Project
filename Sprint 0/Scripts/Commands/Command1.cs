using System;
using Sprint_0;

public class Command1 : ICommand
{
	private Game1 game;

	public Command1(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.SetSprite(new Sprite1(game.GetCenterScreen()));
	}
}
