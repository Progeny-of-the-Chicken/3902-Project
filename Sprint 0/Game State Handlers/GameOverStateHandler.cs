using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState;

namespace Sprint_0.GameStateHandlers
{
    public class GameOverStateHandler: IGameStateHandler
    {
        GameOverScreen screen;

        public GameOverStateHandler()
        {
            screen = new GameOverScreen();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            screen.Draw(sb);
        }

        public void Update(GameTime gameTime)
        {
            screen.Update();
        }
    }
}
