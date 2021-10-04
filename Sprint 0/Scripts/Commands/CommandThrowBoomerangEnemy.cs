using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBoomerangEnemy
    {
        private Game1 game;

        public CommandThrowBoomerangEnemy(Game1 game)
        {
            // TODO: Add IEnemy as parameter
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of IEnemy
            game.itemSet.items.Add(ItemFactory.Instance.CreateBoomerang(game.GetCenterScreen(), FacingDirection.Right, false));
        }
    }
}
