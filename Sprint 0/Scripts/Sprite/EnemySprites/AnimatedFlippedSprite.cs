using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.EnemySprites
{
    class AnimatedFlippedSprite : ISprite
    {
        Rectangle[] frames;
        Texture2D sprite;

        float timeSinceFrame = ObjectConstants.counterInitialVal_float;
        int currentFrame = ObjectConstants.firstFrame;
        private double scale;
        public AnimatedFlippedSprite(Rectangle[] frames, Texture2D spriteSheet, double scale)
        {
            this.frames = frames;
            sprite = spriteSheet;
            this.scale = scale;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= ObjectConstants.oneSecond_double / ObjectConstants.DefaultEnemyFramesPerSecond)
            {
                currentFrame = (currentFrame + ObjectConstants.nextInArray) % frames.Length;
                timeSinceFrame = ObjectConstants.counterInitialVal_float;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(location.ToPoint(), (new Vector2((int)(frames[ObjectConstants.firstFrame].Size.ToVector2().X * scale), (int)(frames[ObjectConstants.firstFrame].Size.ToVector2().Y * scale))).ToPoint());
            spriteBatch.Draw(sprite, destinationRectangle, frames[currentFrame], Color.White, ObjectConstants.zeroRotation, ObjectConstants.zeroVector, SpriteEffects.FlipHorizontally, ObjectConstants.zero);
        }
    }
}
