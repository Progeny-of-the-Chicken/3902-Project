using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandCastFireSpell : ICommand
    {
        private Game1 game;

        public CommandCastFireSpell(Game1 game)
        {
            // TODO: Add ILink as parameter
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Link
            game.itemSet.items.Add(ItemFactory.Instance.CreateFireSpell(game.GetCenterScreen(), FacingDirection.Right));
        }
    }
}
