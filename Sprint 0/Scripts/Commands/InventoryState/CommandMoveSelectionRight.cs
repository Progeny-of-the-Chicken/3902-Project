using Sprint_0.Scripts.GameState.InventoryState;

namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandMoveSelectionRight : ICommand
    {
        private Game1 game;

        public CommandMoveSelectionRight(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: loop this through game
            InventoryManager.Instance.MoveSelection(FacingDirection.Right);
            InventoryManager.Instance.SelectWeapon();
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}