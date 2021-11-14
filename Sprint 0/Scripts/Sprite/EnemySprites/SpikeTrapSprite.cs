using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    class SpikeTrapSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle sourceRectangle;

        private SpriteEffects effect = SpriteEffects.None;
        public SpikeTrapSprite(Rectangle rectangle, Texture2D spriteSheet)
        {
            sourceRectangle = rectangle;
            sprite = spriteSheet;
        }
        public void Update(GameTime gt)
        {
            //not needed
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(sourceRectangle.Width * ObjectConstants.scale), (int)(sourceRectangle.Height * ObjectConstants.scale));
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, ObjectConstants.zeroRotation, Vector2.Zero, effect, ObjectConstants.noLayerDepth);
            //TODO:This can be a simpiler draw method, all the additional arguments are unused.
        }
    }
}

