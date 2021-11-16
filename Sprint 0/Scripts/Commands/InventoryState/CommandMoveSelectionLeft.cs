using Sprint_0.Scripts.GameState.InventoryState;

namespace Sprint_0.Scripts.Commands.InventoryState
{
    public class CommandMoveSelectionLeft : ICommand
    {
        private Game1 game;

        public CommandMoveSelectionLeft(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: loop this through game
            InventoryManager.Instance.MoveSelection(FacingDirection.Left);
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}