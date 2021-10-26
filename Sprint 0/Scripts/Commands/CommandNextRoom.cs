using System;
using Sprint_0;

public class CommandNextRoom : ICommand
{
	private Game1 game;

	public CommandNextRoom(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.NextRoom();
	}
}