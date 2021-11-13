namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandReturnToGameState : ICommand
    {
        private Game1 game;

        public CommandReturnToGameState(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Implement state transition here
        }
    }
}
