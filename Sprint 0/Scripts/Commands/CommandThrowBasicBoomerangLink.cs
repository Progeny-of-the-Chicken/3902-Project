using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBasicBoomerangLink : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandThrowBasicBoomerangLink(Game1 game)
        {
            this.game = game;
            this.link = game.link;
        }

        public void Execute()
        {
            game.itemSet.items.Add(ItemFactory.Instance.CreateBoomerang(link.ItemSpawnPosition, link.FacingDirection, false));
        }
    }
}
