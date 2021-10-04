using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBoomerangLink : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandThrowBoomerangLink(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            game.itemSet.items.Add(ItemFactory.Instance.CreateBoomerang(link.ItemSpawnPosition, link.FacingDirection, true));
            link.UseItem();
        }
    }
}
