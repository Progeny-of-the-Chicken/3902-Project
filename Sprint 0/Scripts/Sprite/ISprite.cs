using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public interface ISprite
    {
        void Draw(SpriteBatch sb, Vector2 location);
        void Update(GameTime gt);
    }
}