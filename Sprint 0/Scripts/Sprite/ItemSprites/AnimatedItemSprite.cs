using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ItemSprites
{
    public class AnimatedItemSprite : ISprite
    {
        private Texture2D spritesheet;
        private List<Rectangle> frames;
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private int frameIndex = ObjectConstants.firstFrame;
        private int scale = ObjectConstants.scale;

        public AnimatedItemSprite(Texture2D textures, List<Rectangle> sourceRecs)
        {
            spritesheet = textures;
            frames = sourceRecs;
        }

        public void Update(GameTime gt)
        {
            startTimeSeconds += gt.ElapsedGameTime.TotalSeconds;
            if (startTimeSeconds > ObjectConstants.itemAnimationDelaySeconds)
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
