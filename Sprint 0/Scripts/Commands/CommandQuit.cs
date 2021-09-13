using System;
using Sprint_0;

public class CommandQuit : ICommand
{
	private Game1 game;

	public CommandQuit(Game1 game) 
	{
		this.game = game;
	}

	public void Execute()
    {
		game.Quit();
    }
}
