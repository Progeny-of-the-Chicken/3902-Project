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

            string[] dia = { "Game over.                    Press Enter to Play again     Press Q to quit" };

            db.AddDialogue(dia);
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
