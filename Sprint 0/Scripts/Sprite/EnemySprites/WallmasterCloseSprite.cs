using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Sprite
{
    class WallmasterCloseSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private float scale;

        private SpriteEffects effect = SpriteEffects.None;
        private float framesPerSecond = 4;
        private float timeSinceFrame = 0;
        public WallmasterCloseSprite(Rectangle rectangle, float scale, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            this.scale = scale;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            //not needed
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, effect, 0);

        }
    }
}


