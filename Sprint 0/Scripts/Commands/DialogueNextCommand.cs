using Sprint_0.GameStateHandlers;

namespace Sprint_0.Scripts.Commands
{
    public class DialogueNext
    {
        public DialogueNext()
        {
        }

        public void Execute()
        {
            GameStateManager.Instance.DialogueNext();
        }
    }
}
