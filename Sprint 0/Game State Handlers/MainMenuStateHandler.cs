using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.GameState.MainMenuState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.GameStateHandlers
{
    public class MainMenuStateHandler: IGameStateHandler
    {
        private IMainMenuManager mainMenuManager;
        private bool paused = false;
        private ISprite[] pausedLetterSprites = new ISprite[ObjectConstants.pausedLetters.Length];
        private Game1 game;

        public MainMenuStateHandler(Game1 game)
        {
            this.game = game;
            mainMenuManager = MainMenuManager.Instance;
            mainMenuManager.Init();
            initializeLetterSprites();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            mainMenuManager.Draw(sb, gameTime);

            if (paused)
            {
                drawPausedLetters(sb);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!paused)
            {
                mainMenuManager.Update(gameTime);
            }
        }

        public void TogglePause()
        {
            paused = !paused;

            if (paused)
            {
                game.kc = new PausedKeyboardController(game, Keyboard.GetState());
                SFXManager.Instance.PauseMusic();
            } else
            {
                game.kc = new MainMenuStateController(game);
                SFXManager.Instance.PlayMusic();
            }
        }

        public void DialogueNext()
        {
            //Unused
        }

        //----- Helper Methods -----//


        private void drawPausedLetters(SpriteBatch sb)
        {
            int xRef = ObjectConstants.pauseDisplayStartingPointX;
            int yRef = ObjectConstants.pauseDisplayStartingPointY;
            int letterSpacing = 8;
            int xStep = ObjectConstants.standardWidthHeight * ObjectConstants.scale + letterSpacing;

            for (int i = 0; i < ObjectConstants.pausedLetters.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef);
                pausedLetterSprites[i].Draw(sb, drawLocation);
            }
        }

        private void initializeLetterSprites()
        {
            for (int i = 0; i < pausedLetterSprites.Length; i++)
            {
                pausedLetterSprites[i] = FontSpriteFactory.Instance.CreateLetterSprite(ObjectConstants.pausedLetters[i]);
            }
        }
    }
}
