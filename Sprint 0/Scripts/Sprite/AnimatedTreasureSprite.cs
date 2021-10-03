using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    public class AnimatedTreasureSprite : ISprite
    {
        private Texture2D spritesheet;
        private List<Rectangle> frames;
        private double animationDelaySeconds = 0.1;
        private double startTimeSeconds = 0.0;
        private int frameIndex = 0;
        private int scale = 2;

        public AnimatedTreasureSprite(Texture2D textures, List<Rectangle> sourceRecs)
        {
            spritesheet = textures;
            frames = sourceRecs;
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
