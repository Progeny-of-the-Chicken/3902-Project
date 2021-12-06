using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandSelectOption : ICommand
    {
        public CommandSelectOption()
        {
        }

        public void Execute()
        {
            MainMenuManager.Instance.SelectOption();
        }
    }
}