using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class FireSpellSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.fireSpellFrame;
        private double animationDelaySeconds = ObjectConstants.itemAnimationDelaySeconds;
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private SpriteEffects flip = SpriteEffects.None;
        private int scale = ObjectConstants.scale;

        public FireSpellSprite(Texture2D textures)
        {
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            startTimeSeconds += gt.ElapsedGameTime.TotalSeconds;
            if (startTimeSeconds > animationDelaySeconds)
            {
                if (flip == SpriteEffects.None)
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    flip = SpriteEffects.None;
                }
                startTimeSeconds = ObjectConstants.counterInitialVal_double;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White, ObjectConstants.zeroRotation, ObjectConstants.zeroVector, flip, ObjectConstants.noLayerDepth);
        }
    }
}