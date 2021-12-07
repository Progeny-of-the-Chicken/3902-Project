using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandMoveSelectionRight : ICommand
    {

        public CommandMoveSelectionRight()
        {
        }

        public void Execute()
        {
            // TODO: loop this through game
            MainMenuManager.Instance.MoveSelection(FacingDirection.Right);
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}