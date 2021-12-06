using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public interface IGameStateHandler
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, GameTime gameTime);
        void TogglePause();
    }
}
