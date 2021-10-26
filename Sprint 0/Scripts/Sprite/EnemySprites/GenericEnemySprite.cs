using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Sprite.EnemySprites
{
    class GenericEnemySprite : ISprite
    {
        Rectangle[] frames;
        Texture2D sprite;

        float timeSinceFrame = 0;
        int currentFrame = 0;
        public GenericEnemySprite(Rectangle[] frames, Texture2D spriteSheet)
        {
            this.frames = frames;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= 1 / ObjectConstants.DefaultEnemyFramesPerSecond)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                timeSinceFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(location.ToPoint(), (frames[currentFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            spriteBatch.Draw(sprite, destinationRectangle, frames[currentFrame], Color.White);
        }
    }
}
