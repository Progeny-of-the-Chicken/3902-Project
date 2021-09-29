using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class AnimatedTreasure : IItem
    {
        private Texture2D treasureSpritesheet;
        private List<Rectangle> sourceRecs;
        private Rectangle destinationRec;
        private int frameIndex;
        private double lastFrameTime;
        private bool delete;

        public AnimatedTreasure(Texture2D spritesheet, List<Rectangle> textureLocation, Vector2 spawnLoc)
        {
            treasureSpritesheet = spritesheet;
            sourceRecs = new List<Rectangle>(textureLocation);
            // Set position as center of sprite
            destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRecs[0].Width / 2), (int)spawnLoc.Y - (sourceRecs[0].Height / 2),
                2 * sourceRecs[0].Width, 2 * sourceRecs[0].Height
            );
            delete = false;

            frameIndex = 0;
            lastFrameTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Animation control
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFrameTime > ItemSettings.animationDelay)
            {
                if (frameIndex == (sourceRecs.Capacity - 1))
                {
                    frameIndex = 0;
                }
                else
                {
                    frameIndex++;
                }
                lastFrameTime = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(treasureSpritesheet, destinationRec, sourceRecs[frameIndex], Color.White);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
