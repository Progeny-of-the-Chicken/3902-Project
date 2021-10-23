using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class BoomerangSprite : ISprite
    {
        private Texture2D spritesheet;
        private List<Rectangle> frames;
        private double animationDelaySeconds = ObjectConstants.itemAnimationDelaySeconds;
        private double startTimeSeconds = 0.0;
        private int frameIndex = 0;
        private double rotation = 0.0;
        private Vector2 rotationOffset = new Vector2(4, 4);
        private int scale = ObjectConstants.scale;

        public BoomerangSprite(Texture2D textures, bool magical)
        {
            spritesheet = textures;
            frames = new List<Rectangle>();
            if (!magical)
            {
                frames = SpriteRectangles.basicBoomerangFrames;
            }
            else
            {
                frames = SpriteRectangles.magicalBoomerangFrames;
            }
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
                    // Alternate between base sprites and reversed sprites
                    if (rotation == 0.0)
                    {
                        rotation = Math.PI;
                    }
                    else
                    {
                        rotation = 0.0;
                    }
                }
                startTimeSeconds = 0.0;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frames[frameIndex].Width * scale, frames[frameIndex].Height * scale);
            sb.Draw(spritesheet, dest, frames[frameIndex], Color.White, (float)rotation, rotationOffset, SpriteEffects.None, 0);
        }
    }
}
