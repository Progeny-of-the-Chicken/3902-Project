using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandMoveSelectionLeft : ICommand
    {

        public CommandMoveSelectionLeft()
        {
        }

        public void Execute()
        {
            // TODO: loop this through game
            MainMenuManager.Instance.MoveSelection(FacingDirection.Left);
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}