using System;
using Sprint_0.GameStateHandlers;

namespace Sprint_0.Scripts.Commands
{
    public class RestartGameCommand: ICommand
    {
        public RestartGameCommand()
        {
        }

        public void Execute()
        {
            System.Diagnostics.Debug.WriteLine("Restarting");
            GameStateManager.Instance.RestartGame();
        }
    }
}
