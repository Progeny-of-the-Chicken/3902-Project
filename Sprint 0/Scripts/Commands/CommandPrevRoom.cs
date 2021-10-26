using System;
using Sprint_0;

public class CommandPrevRoom : ICommand
{
	private Game1 game;

	public CommandPrevRoom(Game1 game) 
	{
		this.game = game;
	}

	public void Execute()
    {
		game.PrevRoom();
    }
}
