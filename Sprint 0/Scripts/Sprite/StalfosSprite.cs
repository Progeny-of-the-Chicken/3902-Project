using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Enemy
{
    public class StalfosSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private int scale;

        private SpriteEffects effect = SpriteEffects.None;
        private float flipsPerSec = 4;
        private float timeSinceFlip = 0;
        public StalfosSprite(Rectangle rectangle, int scale, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            this.scale = scale;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFlip += (float) gt.ElapsedGameTime.TotalSeconds;
            if(timeSinceFlip >= 1 / flipsPerSec)
            {
                //Will alternate between normal and flipped sprite
                if (effect == SpriteEffects.None)
                {
                    effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    effect = SpriteEffects.None;
                }
                timeSinceFlip = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width * scale, sourceRectangle.Height * scale);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2), effect, 0);
        }
    }
}
