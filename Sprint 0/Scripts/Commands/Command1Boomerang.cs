using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class Command1Boomerang : ICommand
    {
        private Game1 game;

        public Command1Boomerang(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Move item factory dependency to player sprite class
            game.itemSet.items.Add(ItemSpriteFactory.Instance.CreateBoomerang(game.GetCenterScreen(), Boomerang.Direction.UP, false));
        }
    }
}
