using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    class MagicProjectileSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle[] frames;
        private int scale;

        private float framesPerSecond = 15;
        private float timeSinceFrame = 0;
        private int currentFrame = 0;
        public MagicProjectileSprite(Rectangle[] frames, int scale, Texture2D sprite)
        {
            this.frames = frames;
            this.scale = scale;
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= 1 / framesPerSecond)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                timeSinceFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frames[currentFrame].Width * scale, frames[currentFrame].Height * scale);
            spriteBatch.Draw(sprite, destinationRectangle, frames[currentFrame], Color.White);
        }
    }
}
