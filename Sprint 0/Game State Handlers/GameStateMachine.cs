using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts;

namespace Sprint_0.GameStateHandlers
{
    public enum GameState
    {
        Menu,
        Gameplay,
        Inventory
    }

    public class GameStateMachine
    {
        private GameState _state;
        private Link link;
        public GameState state { get => _state; }

        // Game State Handlers
        GameplayStateHandler gameplay;
        InventoryStateHandler inventory;

        public GameStateMachine(Link link)
        {
            // Set initial game state
            this._state = GameState.Gameplay;
            this.link = link;

            loadHandlers();
        }

        public void SetState(GameState newState)
        {
            this._state = newState;
            if (newState == GameState.Inventory)
            {
                inventory = new InventoryStateHandler();
            }
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            switch (_state)
            {
                case GameState.Gameplay:
                    gameplay.Draw(sb, gameTime);
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
                    inventory.Draw(sb, gameTime);
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (_state)
            {
                case GameState.Gameplay:
                    gameplay.Update(gameTime);
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
                    inventory.Update(gameTime);
                    break;
                default:
                    break;
            }
        }

        /*--------------- Helper Methods ---------------*/


        private void loadHandlers()
        {
            this.gameplay = new GameplayStateHandler(this.link);
            inventory = new InventoryStateHandler();
        }
    }
}
