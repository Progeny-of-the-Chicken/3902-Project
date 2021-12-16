using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.GameState.InventoryState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.GameStateHandlers
{
    public class InventoryStateHandler: IGameStateHandler
    {
        private IInventoryManager inventoryManager;
        private HUD headsUpDisplay;
        private bool paused = false;
        private ISprite[] pausedLetterSprites = new ISprite[ObjectConstants.pausedLetters.Length];
        private Game1 game;

        public InventoryStateHandler(Game1 game)
        {
            this.game = game;
            headsUpDisplay = new HUD(ObjectConstants.HUDYOffsetInInventory);
            inventoryManager = InventoryManager.Instance;
            inventoryManager.Init();
            initializeLetterSprites();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            inventoryManager.Draw(sb, gameTime);
            headsUpDisplay.Draw(sb);

            if (paused)
            {
                drawPausedLetters(sb);
            }
        }

        public void Update(GameTime gameTime)
        {
            headsUpDisplay.Update();
            if (!paused)
            {
                inventoryManager.Update(gameTime);
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
                game.kc = new InventoryStateController(game);
                SFXManager.Instance.PlayMusic();
            }
        }

        public void DialogueNext() { /*Unused*/ }
        public void ClearDialogue() { /*Unused*/ }
        public void SetSuspended(bool sus) { /*Unused*/ }

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
