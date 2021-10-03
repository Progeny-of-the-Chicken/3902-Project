using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    public interface ISprite
    {
        void Update(GameTime gt);

        void Draw(SpriteBatch sb, Vector2 location);
    }
}