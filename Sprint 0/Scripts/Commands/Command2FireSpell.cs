using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class Command2FireSpell : ICommand
    {
        private Game1 game;

        public Command2FireSpell(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			// TODO: Move item factory dependency to player sprite class
			game.ic.items.Add(ItemSpriteFactory.Instance.CreateFireSpell(game.GetCenterScreen(), FireSpell.Direction.UP));
		}
	}
}
