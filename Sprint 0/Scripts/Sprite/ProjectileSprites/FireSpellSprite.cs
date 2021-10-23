using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class FireSpellSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.fireSpellFrame;
        private double animationDelaySeconds = ObjectConstants.itemAnimationDelaySeconds;
        private double startTimeSeconds = 0.0;
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
                startTimeSeconds = 0.0;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White, 0, new Vector2(0, 0), flip, 0);
        }
    }
}