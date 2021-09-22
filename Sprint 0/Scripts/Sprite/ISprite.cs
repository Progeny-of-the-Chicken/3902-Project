using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public interface ISprite
    {
        // void LoadContent(ContentManager cm);
        void Update();
        void Draw(SpriteBatch sb, GameTime gt);
    }
}