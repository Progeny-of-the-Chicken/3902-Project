using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandShootArrow : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandShootArrow(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            game.itemSet.items.Add(ItemFactory.Instance.CreateArrow(link.ItemSpawnPosition, link.FacingDirection, true));
            link.UseItem();
        }
    }
}
