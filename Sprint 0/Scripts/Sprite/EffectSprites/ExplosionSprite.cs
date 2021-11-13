using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.EffectSprites
{
    public class ExplosionSprite : ISprite
    {
        private Texture2D spritesheet;
        private List<Rectangle> frames = SpriteRectangles.explosionFrames;
        private double animationDelaySeconds = ObjectConstants.itemAnimationDelaySeconds;
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private int frameIndex = ObjectConstants.firstFrame;
        private int scale = ObjectConstants.scale;

        public ExplosionSprite(Texture2D textures)
        {
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            startTimeSeconds += gt.ElapsedGameTime.TotalSeconds;
            if (startTimeSeconds > animationDelaySeconds)
            {
                frameIndex++;
                if (frameIndex == frames.Count)
                {
                    frameIndex = ObjectConstants.firstFrame;
                }
                startTimeSeconds = ObjectConstants.counterInitialVal_double;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frames[frameIndex].Width * scale, frames[frameIndex].Height * scale);
            sb.Draw(spritesheet, dest, frames[frameIndex], Color.White);
        }
    }
}
