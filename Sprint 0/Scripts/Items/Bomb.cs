using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class Bomb : IItem
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private Texture2D projectileSpritesheet;
        private List<Rectangle> sourceRecs;
        private Direction placement;
        private int displacement;
        private SpriteAxis activeAxis;

        private bool startTimeInitialized;
        private double startTime;
        private bool linger;
        private int frameIndex;
        private double lastFrameTime;

        private bool delete;

        public Bomb(Texture2D spritesheet, List<Rectangle> textureLocation, Vector2 spawnLoc, Direction dir)
        {
            projectileSpritesheet = spritesheet;
            sourceRecs = textureLocation;
            Rectangle destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRecs[0].Width / 2), (int)spawnLoc.Y - (sourceRecs[0].Height / 2),
                2 * sourceRecs[0].Width, 2 * sourceRecs[0].Height
            );
            delete = false;
            displacement = ItemSettings.bombDisplacement;

            placement = dir;
            linger = true;
            startTimeInitialized = false;
            startTime = 0.0;
            frameIndex = 0;

            // TODO: Clean up orientation logic
            switch (placement)
            {
                case Direction.UP:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    break;
                case Direction.LEFT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    displacement *= -1;
                    break;
                case Direction.DOWN:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    displacement *= -1;
                    break;
                case Direction.RIGHT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    break;
                default:
                    break;
            }
            activeAxis.currentPos += displacement;

            delete = false;
        }

        public void Update(GameTime gameTime)
        {
            // Animation control
            if (!startTimeInitialized)
            {
                startTime = gameTime.TotalGameTime.TotalSeconds;
                startTimeInitialized = true;
            }

            if (linger)
            {
                if (gameTime.TotalGameTime.TotalSeconds - startTime > ItemSettings.fuseDuration)
                {
                    linger = false;
                    lastFrameTime = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }
            else
            {
                if (gameTime.TotalGameTime.TotalMilliseconds - lastFrameTime > ItemSettings.animationDelay)
                {
                    frameIndex++;
                    if (frameIndex == (sourceRecs.Capacity - 1))
                    {
                        delete = true;
                    }
                    lastFrameTime = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(projectileSpritesheet, activeAxis.spriteRec, sourceRecs[frameIndex], Color.White);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
