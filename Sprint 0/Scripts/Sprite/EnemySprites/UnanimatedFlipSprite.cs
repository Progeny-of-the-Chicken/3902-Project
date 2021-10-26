using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Sprites.EnemySprites
{
    class UnanimatedFlipSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        SpriteEffects effect = SpriteEffects.None;

        private float timeSinceFrame = 0;
        public UnanimatedFlipSprite(Rectangle rectangle, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= 1 / ObjectConstants.DefaultEnemyFramesPerSecond)
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
                timeSinceFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(location.ToPoint(), (sourceRectangle.Size.ToVector2() * ObjectConstants.scale).ToPoint());
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, effect, 0);
        }
    }
}

