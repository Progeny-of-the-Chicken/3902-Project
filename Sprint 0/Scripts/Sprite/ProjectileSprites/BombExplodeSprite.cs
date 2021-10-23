using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class BombExplodeSprite : ISprite
    {
        private Texture2D spritesheet;
        private List<Rectangle> frames = SpriteRectangles.bombExplodeFrames;
        private double animationDelaySeconds = ObjectConstants.itemAnimationDelaySeconds;
        private double startTimeSeconds = 0.0;
        private int frameIndex = 0;
        private int scale = ObjectConstants.scale;

        public BombExplodeSprite(Texture2D textures)
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
                    frameIndex = 0;
                }
                startTimeSeconds = 0.0;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frames[frameIndex].Width * scale, frames[frameIndex].Height * scale);
            sb.Draw(spritesheet, dest, frames[frameIndex], Color.White);
        }
    }
}
