using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class AnimatedTreasureSprite : IItem
    {
        private Texture2D treasureSpritesheet;
        private List<Rectangle> sourceRecs;
        private Rectangle destinationRec;
        private double animationDelaySeconds = 0.1;
        private int frameIndex = 0;
        private double lastFrameTime = 0;
        private bool delete = false;

        public AnimatedTreasureSprite(Texture2D spritesheet, List<Rectangle> textureLocation, Vector2 spawnLoc)
        {
            treasureSpritesheet = spritesheet;
            sourceRecs = new List<Rectangle>(textureLocation);
            // Set position as center of sprite
            destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRecs[0].Width / 2), (int)spawnLoc.Y - (sourceRecs[0].Height / 2),
                2 * sourceRecs[0].Width, 2 * sourceRecs[0].Height
            );
        }

        public void Update(GameTime gameTime)
        {
            // Animation control
            if (gameTime.TotalGameTime.TotalSeconds - lastFrameTime > animationDelaySeconds)
            {
                frameIndex++;
                if (frameIndex == sourceRecs.Count)
                {
                    frameIndex = 0;
                }
                lastFrameTime = gameTime.TotalGameTime.TotalSeconds;
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
