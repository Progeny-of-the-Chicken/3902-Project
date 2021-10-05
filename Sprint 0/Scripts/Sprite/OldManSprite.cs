using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    class OldManSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private float scale;
        public OldManSprite(Rectangle sourceRectangle, float scale, Texture2D spriteSheet)
        {
            this.sourceRectangle = sourceRectangle;
            this.scale = scale;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            //not used
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
