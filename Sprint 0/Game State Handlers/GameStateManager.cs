using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.GameState.MainMenuState;
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
        GameOver,
        SuperHot
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

        private Link link;
        private Game1 game;
        private IGameStateHandler state;
        private bool inSuperHot;
        private bool isGameWon = false;
        public bool GameWon {
            get => isGameWon;
        }
                

        // Game State Handlers
        MainMenuStateHandler mainmenu;
        GameplayStateHandler gameplay;
        InventoryStateHandler inventory;
        RoomSwapStateHandler swapper;
        GameOverStateHandler gameOver;
        SuperHotStateHandler superHot;

        public GameStateManager()
        {
        }

        public void Init(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;

            mainmenu = new MainMenuStateHandler(game);

            state = mainmenu;
        }

        public void RestartGame()
        {
            System.Diagnostics.Debug.WriteLine("Restarting Game");

            game.roomNum = ObjectConstants.counterInitialVal_int;
            game.kc = new MainMenuStateController(game);
            Link.Instance.reset();
            Inventory.Instance.reset();
            RoomManager.Instance.reset();

            mainmenu = new MainMenuStateHandler(game);
            state = mainmenu;
            isGameWon = false;
        }

        public void GameOver()
        {
            if (this.state != gameOver)
            {
                SFXManager.Instance.StopMusic();
                gameOver = new GameOverStateHandler();
                game.kc = new GameOverStateController(game, Keyboard.GetState());
                this.state = gameOver;
            }
        }

        public void StartGameFromMainMenu(bool isSuperhot, bool isRandomized)
        {
            inSuperHot = isSuperhot;
            gameplay = new GameplayStateHandler(link, game);
            inventory = new InventoryStateHandler(game);
            gameOver = new GameOverStateHandler();
            superHot = new SuperHotStateHandler(link, game);
            StartGameplay();
        }

        public void StartGameplay()
        {
            SFXManager.Instance.PlayMusic();

            if (inSuperHot)
            {
                this.state = superHot;
                System.Diagnostics.Debug.WriteLine("Swapped to state: SuperHot");
            }
            else
            {
                this.state = gameplay;
                System.Diagnostics.Debug.WriteLine("Swapped to state: Gameplay");
            }
        }

        public void SwapRooms(string fromRoomID, string toRoomID, FacingDirection scrollingDirection)
        {
            this.swapper = new RoomSwapStateHandler(fromRoomID, toRoomID, scrollingDirection, this.link);
            this.state = swapper;
            System.Diagnostics.Debug.WriteLine("Swapped to state: Room Swap");
        }

        public void OpenInventory()
        {
            inventory = new InventoryStateHandler(game);
            this.state = inventory;
        }

        public void TogglePause()
        {
            state.TogglePause();
        }

        public void DialogueNext()
        {
            state.DialogueNext();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            state.Draw(sb, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        public void WonGame()
        {
            this.isGameWon = true;
        }
    }
}
