using System;
using Sprint_0.GameStateHandlers;

namespace Sprint_0.Scripts.Commands
{
    public class PauseCommand: ICommand
    {
        public PauseCommand()
        {
        }

        public void Execute()
        {
            GameStateManager.Instance.TogglePause();
        }
    }
}
