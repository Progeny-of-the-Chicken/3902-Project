using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandShootBasicArrow : ICommand
    {
        private Game1 game;

        public CommandShootBasicArrow(Game1 game)
        {
            // TODO: Add ILink as parameter
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Link
            game.itemSet.items.Add(ItemFactory.Instance.CreateArrow(game.GetCenterScreen(), FacingDirection.Right, false));
        }
    }
}
