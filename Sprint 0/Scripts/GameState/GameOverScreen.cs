using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.GameState
{
    public class GameOverScreen
    {
        ISprite background;
        ISprite[] gameOverLetters = new ISprite[gameOverMessage.Length];
        ISprite[] playAgainLetters;
        ISprite[] quitLetters;
        private static string gameOverMessage = "Gameover";
        private static string playAgainMessage = "Press Enter to play again";
        private static string quitMessage = "Press Q to quit";

        public GameOverScreen()
        {
            background = GameStateSpriteFactory.Instance.CreateBlackBackground();
            //initializeGameOverLetterSprites();
        }

        public void Update()
        {
            // No animation
        }

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb, new Vector2(0, 0));
            //drawLetters(sb);
        }

        // ----- Helper Methods ----- //

        private void drawLetters(SpriteBatch sb)
        {
            int xRef = ObjectConstants.pauseDisplayStartingPointX;
            int yRef = ObjectConstants.pauseDisplayStartingPointY;
            int letterSpacing = 8;
            int xStep = ObjectConstants.standardWidthHeight * ObjectConstants.scale + letterSpacing;

            for (int i = 0; i < ObjectConstants.pausedLetters.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef);
                gameOverLetters[i].Draw(sb, drawLocation);
            }
        }

        private void initializeGameOverLetterSprites()
        {
            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                gameOverLetters[i] = FontSpriteFactory.Instance.CreateLetterSprite(ObjectConstants.pausedLetters[i]);
            }
        }

        private void initializePlayAgainLettersLetterSprites()
        {
            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                gameOverLetters[i] = FontSpriteFactory.Instance.CreateLetterSprite(ObjectConstants.pausedLetters[i]);
            }
        }
    }
}
