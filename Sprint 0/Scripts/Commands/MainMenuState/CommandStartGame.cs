using Microsoft.Xna.Framework.Input;
using Sprint_0.GameStateHandlers;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState.MainMenuState;

namespace Sprint_0.Scripts.Commands.MainMenuState
{
    public class CommandStartGame : ICommand
    {
        private Game1 game;

        public CommandStartGame(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            GameStateManager.Instance.StartGameFromMainMenu(MainMenuManager.Instance.GetIfSuperhot(), MainMenuManager.Instance.GetIfRandomized());
            game.kc = new KeyboardController(game, Keyboard.GetState());
        }
    }
}