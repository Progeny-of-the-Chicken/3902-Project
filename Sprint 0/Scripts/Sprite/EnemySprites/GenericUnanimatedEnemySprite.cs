using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.EnemySprites
{
    class GenericUnanimatedEnemySprite : ISprite
    {
        Rectangle frame;
        Texture2D sprite;

        public GenericUnanimatedEnemySprite(Rectangle frame, Texture2D spriteSheet)
        {
            this.frame = frame;
            sprite = spriteSheet;
        }
        public void Update(GameTime gameTime)
        {
            //unused
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(location.ToPoint(), (frame.Size.ToVector2() * ObjectConstants.scale).ToPoint());
            spriteBatch.Draw(sprite, destinationRectangle, frame, Color.White);
        }
    }
}
