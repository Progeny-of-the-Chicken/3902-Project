using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThirdItem : ICommand
    {
        private Game1 game;

        public CommandThirdItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Link
            game.itemSet.items.Add(ItemFactory.Instance.CreateFireSpell(game.GetCenterScreen(), FireSpell.Direction.RIGHT));
        }
    }
}
