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
        ISprite[] playAgainLetters = new ISprite[playAgainMessage.Length];
        ISprite[] quitLetters = new ISprite[quitMessage.Length];

        private static string gameOverMessage = "gameover";
        private static string playAgainMessage = "press enter to play again";
        private static string quitMessage = "press q to quit";

        public GameOverScreen()
        {
            background = GameStateSpriteFactory.Instance.CreateBlackBackground();
            initializeGameOverLetterSprites();
            initializePlayAgainLettersLetterSprites();
            initializeQuitLettersLetterSprites();
        }

        public void Update()
        {
            // No animation
        }

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb, new Vector2(0, 0));
            drawLetters(sb);
        }

        // ----- Helper Methods ----- //

        private void drawLetters(SpriteBatch sb)
        {
            int xRef = 10;
            int yRef = 50;
            int lineSpace = 24;
            int letterSpacing = 2;
            int xStep = ObjectConstants.standardWidthHeight * ObjectConstants.scale + letterSpacing;

            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef);
                gameOverLetters[i].Draw(sb, drawLocation);
            }

            for (int i = 0; i < playAgainMessage.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef + lineSpace);
                //playAgainLetters[i].Draw(sb, drawLocation);
            }

            for (int i = 0; i < quitMessage.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef + 2 * lineSpace);
                quitLetters[i].Draw(sb, drawLocation);
            }
        }

        private void initializeGameOverLetterSprites()
        {
            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                gameOverLetters[i] = FontSpriteFactory.Instance.CreateLetterSprite(gameOverMessage[i]);
            }
        }

        private void initializePlayAgainLettersLetterSprites()
        {
            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                playAgainLetters[i] = FontSpriteFactory.Instance.CreateLetterSprite(playAgainMessage[i]);
            }
        }

        private void initializeQuitLettersLetterSprites()
        {
            for (int i = 0; i < quitMessage.Length; i++)
            {
                quitLetters[i] = FontSpriteFactory.Instance.CreateLetterSprite(quitMessage[i]);
            }
        }
    }
}
