using Sprint_0.GameStateHandlers;
using Sprint_0.Scripts.Controller;

namespace Sprint_0.Scripts.Commands
{
    public class CommandEnterInventory : ICommand
    {
        private Game1 game;

        public CommandEnterInventory(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            GameStateManager.Instance.OpenInventory();
            // TODO: Make the controller change from the game state machine
            game.kc = new InventoryStateController(game);
        }
    }
}
