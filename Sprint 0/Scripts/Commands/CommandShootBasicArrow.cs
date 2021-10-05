using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandShootBasicArrow : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandShootBasicArrow(Game1 game)
        {
            this.game = game;
            this.link = game.link;
        }

        public void Execute()
        {
            game.itemSet.items.Add(ItemFactory.Instance.CreateArrow(link.ItemSpawnPosition, link.FacingDirection, false));
        }
    }
}
