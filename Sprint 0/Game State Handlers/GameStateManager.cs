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
        Inventory,
        RoomSwap
    }

    public class GameStateManager
    {
        private static GameStateManager instance = new GameStateManager();

        public static GameStateManager Instance
        {
            get
            {
                return instance;
            }
        }

        private GameState _state;
        private Link link;
        private Game1 game;

        public GameState state { get => _state; }

        // Game State Handlers
        GameplayStateHandler gameplay;
        InventoryStateHandler inventory;
        RoomSwapStateHandler swapper;

        public GameStateManager()
        {
            // Set initial game state
            this._state = GameState.Gameplay;
        }

        public void Init(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;

            gameplay = new GameplayStateHandler(link, game);
        }

        public void StartGameplay()
        {
            this._state = GameState.Gameplay;
            System.Diagnostics.Debug.WriteLine("Swapped to state: Gameplay");
        }

        public void SwapRooms(string fromRoomID, string toRoomID, FacingDirection scrollingDirection)
        {
            this._state = GameState.RoomSwap;
            this.swapper = new RoomSwapStateHandler(fromRoomID, toRoomID, scrollingDirection, this.link);

            System.Diagnostics.Debug.WriteLine("Swapped to state: Room Swap");
        }

        public void OpenInventory()
        {
            this._state = GameState.Inventory;
            inventory = new InventoryStateHandler(game);
            // Put rest of inventory initialization logic here
        }

        public void TogglePause()
        {
            switch (_state)
            {
                case GameState.Gameplay:
                    gameplay.TogglePause();
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
                    inventory.TogglePause();
                    break;
                case GameState.RoomSwap:
                    break;
                default:
                    break;
            }
        }

        public void OpenMenu()
        {
            this._state = GameState.Menu;

            // Put rest of menu open logic here
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
                case GameState.RoomSwap:
                    swapper.Draw(sb, gameTime);
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
                case GameState.RoomSwap:
                    swapper.Update(gameTime);
                    break;
                default:
                    break;
            }
        }
    }
}
