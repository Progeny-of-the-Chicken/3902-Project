namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandPauseGame : ICommand
    {
        private Game1 game;

        public CommandPauseGame(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Implement change to pause state here, maybe reuse for game state
        }
    }
}
