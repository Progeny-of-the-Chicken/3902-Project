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
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private int frameIndex = ObjectConstants.firstFrame;
        private double rotation = ObjectConstants.zeroRotation;
        private Vector2 rotationOffset = ObjectConstants.boomerangRotationOffset;
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
                    frameIndex = ObjectConstants.firstFrame;
                    // Alternate between base sprites and reversed sprites
                    if (rotation == ObjectConstants.zeroRotation)
                    {
                        rotation = ObjectConstants.degreeRotationCW180_s;
                    }
                    else
                    {
                        rotation = ObjectConstants.zeroRotation;
                    }
                }
                startTimeSeconds = ObjectConstants.counterInitialVal_double;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frames[frameIndex].Width * scale, frames[frameIndex].Height * scale);
            sb.Draw(spritesheet, dest, frames[frameIndex], Color.White, (float)rotation, rotationOffset, SpriteEffects.None, ObjectConstants.noLayerDepth);
        }
    }
}
