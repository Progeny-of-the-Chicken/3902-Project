﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    class GoriyaBackSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private int scale;

        private SpriteEffects effect = SpriteEffects.None;
        private float framesPerSecond = 4;
        private float timeSinceFrame = 0;
        public GoriyaBackSprite(Rectangle rectangle, int scale, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            this.scale = scale;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= 1 / framesPerSecond)
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
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width * scale, sourceRectangle.Height * scale);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, effect, 0);

        }
    }
}
