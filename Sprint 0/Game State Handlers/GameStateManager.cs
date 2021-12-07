using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public enum GameState
    {
        Menu,
        MainMenu,
        Gameplay,
        Inventory,
        RoomSwap,
        GameOver
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
        MainMenuStateHandler mainmenu;
        GameplayStateHandler gameplay;
        InventoryStateHandler inventory;
        RoomSwapStateHandler swapper;
        GameOverStateHandler gameOver;

        public GameStateManager()
        {
            // Set initial game state
            this._state = GameState.MainMenu;
        }

        public void Init(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;

            mainmenu = new MainMenuStateHandler(game);
        }

        public void RestartGame()
        {
            System.Diagnostics.Debug.WriteLine("Restarting Game");
            StartGameplay();
            game.roomNum = ObjectConstants.counterInitialVal_int;
            game.kc = new KeyboardController(game, Keyboard.GetState());
            Link.Instance.reset();
            Inventory.Instance.reset();
            RoomManager.Instance.reset();
            
        }

        public void GameOver()
        {
            this._state = GameState.GameOver;
            gameOver = new GameOverStateHandler();
            game.kc = new GameOverStateController(game, Keyboard.GetState());
        }

        public void StartGameFromMainMenu(bool isSuperhot, bool isRandomized)
        {
            RoomManager.Instance.Init(Link.Instance, isRandomized);
            StartGameplay();
        }

        public void StartGameplay()
        {
            gameplay = new GameplayStateHandler(link, game);
            inventory = new InventoryStateHandler(game);
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
            // Put rest of inventory initialization logic here
        }

        public void TogglePause()
        {
            switch (_state)
            {
                case GameState.Gameplay:
                    gameplay.TogglePause();
                    break;
                case GameState.MainMenu:
                    mainmenu.TogglePause();
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

        public void DialogueNext()
        {
            switch (_state)
            {
                case GameState.Gameplay:
                    gameplay.DialogueNext();
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
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
                case GameState.MainMenu:
                    mainmenu.Draw(sb, gameTime);
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
                    inventory.Draw(sb, gameTime);
                    break;
                case GameState.RoomSwap:
                    swapper.Draw(sb, gameTime);
                    break;
                case GameState.GameOver:
                    gameOver.Draw(sb, gameTime);
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
                case GameState.MainMenu:
                    mainmenu.Update(gameTime);
                    break;
                case GameState.Menu:
                    break;
                case GameState.Inventory:
                    inventory.Update(gameTime);
                    break;
                case GameState.RoomSwap:
                    swapper.Update(gameTime);
                    break;
                case GameState.GameOver:
                    gameOver.Update(gameTime);
                    break;
                default:
                    break;
            }
        }
    }
}
