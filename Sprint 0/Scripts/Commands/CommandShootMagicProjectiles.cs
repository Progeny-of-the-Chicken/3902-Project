using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandShootMagicProjectiles
    {
        private Game1 game;

        public CommandShootMagicProjectiles(Game1 game)
        {
            // TODO: Add IEnemy as parameter
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Aquamentus
            foreach (IItem magicProjectile in ItemFactory.Instance.CreateThreeMagicProjectiles(game.GetCenterScreen(), FacingDirection.Right))
            {
                game.itemSet.items.Add(magicProjectile);
            }
        }
    }
}
