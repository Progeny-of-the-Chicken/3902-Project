using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class Boomerang : IItem
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private Texture2D projectileSpritesheet;
        private List<Rectangle> sourceRecs;
        private Direction pointing;
        private int frameIndex;
        private double lastFrameTime;
        private float rotation;

        private SpriteAxis activeAxis;
        private bool startTimeInitialized;
        private double startT;
        private double t;
        private double boomerangSpeed;
        private double boomerangAccel;
        private int boomerangMaxDistance;

        public Boomerang(Texture2D spritesheet, List<Rectangle> textureLocation, Vector2 spawnLoc, Direction dir, bool magical)
        {
            projectileSpritesheet = spritesheet;
            sourceRecs = new List<Rectangle>(textureLocation);
            Rectangle destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRecs[0].Width / 2), (int)spawnLoc.Y - (sourceRecs[0].Height / 2),
                2 * sourceRecs[0].Width, 2 * sourceRecs[0].Height
            );
            pointing = dir;

            frameIndex = 0;
            lastFrameTime = 0;
            rotation = 0;
            startTimeInitialized = false;

            // Boomerang stats
            boomerangAccel = ItemSettings.boomerangAccel;
            boomerangSpeed = ItemSettings.boomerangSpeed;
            boomerangMaxDistance = ItemSettings.arrowDistance;
            if (magical)
            {
                boomerangMaxDistance = (int)(boomerangMaxDistance * ItemSettings.magicalBoomerangSpeedCoef);
            }

            // TODO: Clean up orientation logic
            switch (pointing)
            {
                case Direction.UP:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    boomerangSpeed *= -1;
                    boomerangAccel *= -1;
                    break;
                case Direction.LEFT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    boomerangSpeed *= -1;
                    boomerangAccel *= -1;
                    break;
                case Direction.DOWN:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    break;
                case Direction.RIGHT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    break;
                default:
                    break;
            }
        }

    public bool Update(GameTime gameTime)
        {
            // Animation control
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFrameTime > ItemSettings.animationDelay)
            {
                if (frameIndex == (sourceRecs.Count - 1))
                {
                    frameIndex = 0;
                    if (rotation == 0)
                    {
                        rotation = (float) Math.PI;
                    }
                    else
                    {
                        rotation = 0;
                    }
                }
                else
                {
                    frameIndex++;
                }
                lastFrameTime = gameTime.TotalGameTime.TotalMilliseconds;
            }

            // Movement control
            bool delete = false;
            if (!startTimeInitialized)
            {
                startT = gameTime.TotalGameTime.TotalMilliseconds;
            }
            t = (gameTime.TotalGameTime.TotalMilliseconds - startT);
            activeAxis.currentPos += (int) boomerangSpeed;
            return delete;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(projectileSpritesheet, activeAxis.spriteRec, sourceRecs[frameIndex], Color.White,
                rotation, new Vector2(activeAxis.spriteRec.Width / 4, activeAxis.spriteRec.Height / 4), SpriteEffects.None, 0);
        }
    }
}
