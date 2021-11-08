using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public interface GameStateHandler
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, GameTime gameTime);
    }
}
