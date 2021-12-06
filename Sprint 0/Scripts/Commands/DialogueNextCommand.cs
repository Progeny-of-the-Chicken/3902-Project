using Sprint_0.GameStateHandlers;

namespace Sprint_0.Scripts.Commands
{
    public class DialogueNextCommand: ICommand
    {
        public DialogueNextCommand()
        {
        }

        public void Execute()
        {
            GameStateManager.Instance.DialogueNext();
        }
    }
}
