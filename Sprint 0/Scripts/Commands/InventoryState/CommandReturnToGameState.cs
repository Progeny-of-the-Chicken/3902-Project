using Sprint_0.Scripts.Controller;

namespace Sprint_0.Scripts.Commands.InventoryState
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
            game.gameStateMachine.SetState(GameStateHandlers.GameState.Gameplay);
            // TODO: Make this change in the game state handler
            game.kc = new KeyboardController(game);
        }
    }
}
