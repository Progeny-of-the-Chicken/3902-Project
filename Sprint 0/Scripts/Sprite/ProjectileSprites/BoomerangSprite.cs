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
        private double animationDelaySeconds = 0.1;
        private double startTimeSeconds = 0.0;
        private int frameIndex = 0;
        private double rotation = 0.0;
        private Vector2 rotationOffset = new Vector2(4, 4);
        private int scale = 2;

        public BoomerangSprite(Texture2D textures, bool magical)
        {
            spritesheet = textures;
            frames = new List<Rectangle>();
            if (!magical)
            {
                frames.Add(new Rectangle(64, 189, 8, 8));
                frames.Add(new Rectangle(73, 189, 8, 8));
                frames.Add(new Rectangle(82, 189, 8, 8));
                frames.Add(new Rectangle(91, 189, 8, 8));
            }
            else
            {
                frames.Add(new Rectangle(100, 189, 8, 8));
                frames.Add(new Rectangle(109, 189, 8, 8));
                frames.Add(new Rectangle(118, 189, 8, 8));
                frames.Add(new Rectangle(127, 189, 8, 8));
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
