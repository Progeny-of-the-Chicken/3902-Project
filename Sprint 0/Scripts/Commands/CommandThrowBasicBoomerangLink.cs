using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBasicBoomerangLink : ICommand
    {
        private Game1 game;

        public CommandThrowBasicBoomerangLink(Game1 game)
        {
            // TODO: Add ILink as parameter
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Replace position and direction with those of Link
            game.itemSet.items.Add(ItemFactory.Instance.CreateBoomerang(game.GetCenterScreen(), FacingDirection.Right, false));
        }
    }
}
