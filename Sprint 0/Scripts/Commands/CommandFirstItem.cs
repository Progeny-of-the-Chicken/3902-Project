using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandFirstItem : ICommand
    {
        private Game1 game;

        public CommandFirstItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Link
            game.itemSet.items.Add(ItemFactory.Instance.CreateArrow(game.GetCenterScreen(), Arrow.Direction.RIGHT, true));
        }
    }
}
