using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState;

namespace Sprint_0.GameStateHandlers
{
    public class GameOverStateHandler: IGameStateHandler
    {
        GameOverScreen screen;
        DialogueBox db;

        public GameOverStateHandler()
        {
            screen = new GameOverScreen();
            db = new DialogueBox(this);

            string[] deathDialogue = {
                "Game over.                    " +
                "Press Enter to Play again     " +
                "Press Q to quit" };
            string[] victoryDialogue = {
                "Congratulations! You've       " +
                "defeated Aquamentus and       " +
                "collected the triforce piece! " +
                "You have brought peace once   " +
                "again to the dungeon.         " +
                "                              " +
                "                              " +
                "Press Enter to Play again     " +
                "Press Q to quit"
                };

            if (GameStateManager.Instance.GameWon)
            {
                db.AddDialogue(victoryDialogue);
            } else
            {
                db.AddDialogue(deathDialogue);
            }
           
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            screen.Draw(sb);
            db.Draw(sb);
        }

        public void Update(GameTime gameTime)
        {
            screen.Update();
            db.Update();
        }

        public void TogglePause()
        {
            //Unused
        }

        public void DialogueNext()
        {
            db.Next();
        }

        public void SetSuspended(bool sus)
        {
            //Unused
        }
    }
}
