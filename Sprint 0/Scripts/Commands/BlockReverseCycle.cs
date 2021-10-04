using System;
using Sprint_0;

public class BlockReverseCycle : ICommand
{
	private Game1 game;

	public BlockReverseCycle(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		game.PrevBlock();
	}
}
