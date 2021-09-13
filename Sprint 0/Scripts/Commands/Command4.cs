using System;
using Sprint_0;

public class Command4 : ICommand
{
	private Game1 game;

	public Command4(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.SetSprite(new Sprite4(game.GetCenterScreen()));
	}
}
