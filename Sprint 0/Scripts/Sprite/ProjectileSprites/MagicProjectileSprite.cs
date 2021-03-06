using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    class MagicProjectileSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle[] frames;
        private float timeSinceFrame = ObjectConstants.counterInitialVal_float;
        private int currentFrame = ObjectConstants.firstFrame;
        public MagicProjectileSprite(Rectangle[] frames, Texture2D sprite)
        {
            this.frames = frames;
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= ObjectConstants.oneSecond_float / ObjectConstants.defaultCounterLength)
            {
                currentFrame = (currentFrame + ObjectConstants.nextInArray) % frames.Length;
                timeSinceFrame = ObjectConstants.counterInitialVal_float;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(frames[currentFrame].Width * ObjectConstants.scale), (int)(frames[currentFrame].Height * ObjectConstants.scale));
            spriteBatch.Draw(sprite, destinationRectangle, frames[currentFrame], Color.White);
        }
    }
}
