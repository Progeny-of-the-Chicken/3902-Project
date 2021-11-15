using Sprint_0.Scripts.GameState.InventoryState;

namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandSelectWeapon : ICommand
    {
        private Game1 game;

        public CommandSelectWeapon(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            InventoryManager.Instance.SelectWeapon();
        }
    }
}