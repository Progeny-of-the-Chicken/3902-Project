using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
	public class Command4Bomb : ICommand
	{
		private Game1 game;

		public Command4Bomb(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			// TODO: Move item factory dependency to player sprite class
			game.ic.items.Add(ItemSpriteFactory.Instance.CreateBomb(game.GetCenterScreen(), Bomb.Direction.DOWN));
		}
	}
}