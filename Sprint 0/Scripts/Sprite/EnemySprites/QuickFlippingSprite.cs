using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Sprites.EnemySprites
{
    class QuickFlippingSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private SpriteEffects effect = SpriteEffects.None;
        private float framesPerSecond = ObjectConstants.QuickEnemyFramesPerSecond;

        private float timeSinceFrame = ObjectConstants.counterInitialVal_float;
        public QuickFlippingSprite(Rectangle rectangle, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            timeSinceFrame += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceFrame >= ObjectConstants.oneSecond_double / framesPerSecond)
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
                timeSinceFrame = ObjectConstants.counterInitialVal_float;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(location.ToPoint(), (sourceRectangle.Size.ToVector2() * ObjectConstants.scale).ToPoint());
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, ObjectConstants.zeroRotation, Vector2.Zero, effect, ObjectConstants.noLayerDepth);
        }
    }
}