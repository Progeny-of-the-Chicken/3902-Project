using System;
using Sprint_0;

public class BlockForwardCycle : ICommand
{
	private Game1 game;

	public BlockForwardCycle(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.NextBlock();
	}
}
