using Sprint_0.Scripts.GameState.InventoryState;

namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandMoveSelectionDown : ICommand
    {
        private Game1 game;

        public CommandMoveSelectionDown(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: loop this through game
            InventoryManager.Instance.MoveSelection(FacingDirection.Down);
            InventoryManager.Instance.SelectWeapon();
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}