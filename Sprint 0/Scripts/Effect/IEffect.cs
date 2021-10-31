using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Effect
{
    public interface IEffect
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        bool CheckDelete();
    }
}
