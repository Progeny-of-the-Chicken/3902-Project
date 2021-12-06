using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandMoveSelectionUp : ICommand
    {

        public CommandMoveSelectionUp()
        {
        }

        public void Execute()
        {
            // TODO: loop this through game
            MainMenuManager.Instance.MoveSelection(FacingDirection.Up);
            SFXManager.Instance.PlayPickUpRupee();
        }
    }
}