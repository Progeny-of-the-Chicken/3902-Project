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
        ISprite[] playAgainLetters1 = new ISprite[playAgainMessage1.Length];
        ISprite[] playAgainLetters2 = new ISprite[playAgainMessage2.Length];
        ISprite[] quitLetters = new ISprite[quitMessage.Length];

        private static string gameOverMessage = "gameover";
        private static string playAgainMessage1 = "press enter to";
        private static string playAgainMessage2 = "play again";
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
            int xStep = ObjectConstants.standardWidthHeight * 2;

            for (int i = 0; i < gameOverMessage.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef);
                gameOverLetters[i].Draw(sb, drawLocation);
            }

            for (int i = 0; i < playAgainMessage1.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef + 2 * lineSpace);
                playAgainLetters1[i].Draw(sb, drawLocation);
            }

            for (int i = 0; i < playAgainMessage2.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef + 3 * lineSpace);
                playAgainLetters2[i].Draw(sb, drawLocation);
            }

            for (int i = 0; i < quitMessage.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef + 5 * lineSpace);
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
            for (int i = 0; i < playAgainMessage1.Length; i++)
            {
                playAgainLetters1[i] = FontSpriteFactory.Instance.CreateLetterSprite(playAgainMessage1[i]);
            }

            for (int i = 0; i < playAgainMessage2.Length; i++)
            {
                playAgainLetters2[i] = FontSpriteFactory.Instance.CreateLetterSprite(playAgainMessage2[i]);
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
