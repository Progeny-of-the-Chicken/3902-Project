using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandCastFireSpell : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandCastFireSpell(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            game.itemSet.items.Add(ItemFactory.Instance.CreateFireSpell(link.ItemSpawnPosition, link.FacingDirection));
            link.UseItem();
        }
    }
}
