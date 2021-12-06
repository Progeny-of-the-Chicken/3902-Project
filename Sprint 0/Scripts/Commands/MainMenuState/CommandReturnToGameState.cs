using Microsoft.Xna.Framework.Input;
using Sprint_0.GameStateHandlers;
using Sprint_0.Scripts.Controller;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandReturnToGameState : ICommand
    {
        private Game1 game;

        public CommandReturnToGameState(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            GameStateManager.Instance.StartGameplay();
            game.kc = new KeyboardController(game, Keyboard.GetState());
        }
    }
}