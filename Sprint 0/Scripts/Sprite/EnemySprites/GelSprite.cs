using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Sprite
{
    public class GelSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle[] frames;
        private float scale;

        private float framesPerSecond = 4;
        private float timeSinceFrame = 0;
        private int currentFrame = 0;
        public GelSprite(Rectangle[] frames, float scale, Texture2D spriteSheet)
        {
            this.frames = frames;
            this.scale = scale;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= 1 / framesPerSecond)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                timeSinceFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(frames[currentFrame].Width * scale), (int)(frames[currentFrame].Height * scale));
            spriteBatch.Draw(sprite, destinationRectangle, frames[currentFrame], Color.White);
        }

    }
}
