using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandMoveSelectionDown : ICommand
    {

        public CommandMoveSelectionDown()
        {
        }

        public void Execute()
        {
            // TODO: loop this through game
            MainMenuManager.Instance.MoveSelection(FacingDirection.Down);
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}