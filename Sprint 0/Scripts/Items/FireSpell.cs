using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class FireSpell : IItem
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private Texture2D projectileSpritesheet;
        private Rectangle sourceRec;

        private double lastFrameTime;
        private double startLingerTime;
        private Direction pointing;
        private SpriteEffects flip;

        private SpriteAxis activeAxis;
        private double fireSpeed;
        private int fireMaxDistance;
        private bool linger;

        private bool delete;

        public FireSpell(Texture2D spritesheet, Rectangle textureLocation, Vector2 spawnLoc, Direction dir)
        {
            projectileSpritesheet = spritesheet;
            sourceRec = textureLocation;
            Rectangle destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRec.Width / 2), (int)spawnLoc.Y - (sourceRec.Height / 2),
                2 * sourceRec.Width, 2 * sourceRec.Height
            );
            delete = false;

            pointing = dir;
            flip = SpriteEffects.None;
            lastFrameTime = 0;
            linger = false;

            // Fire stats
            fireSpeed = ItemSettings.fireSpeed;
            fireMaxDistance = ItemSettings.fireDistance;

            // TODO: Clean up orientation logic
            switch (pointing)
            {
                case Direction.UP:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    fireSpeed *= -1;
                    break;
                case Direction.LEFT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    fireSpeed *= -1;
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

        public void Update(GameTime gameTime)
        {
            // Animation control
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFrameTime > ItemSettings.animationDelay)
            {
                if (flip == SpriteEffects.None)
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    flip = SpriteEffects.None;
                }
                lastFrameTime = gameTime.TotalGameTime.TotalMilliseconds;
            }

            // Movement control
            if (!linger)
            {
                activeAxis.currentPos += (int) fireSpeed;
                if (Math.Abs(activeAxis.currentPos - activeAxis.startPos) > fireMaxDistance)
                {
                    startLingerTime = gameTime.TotalGameTime.TotalSeconds;
                    linger = true;
                }
            }
            else
            {
                if (gameTime.TotalGameTime.TotalSeconds - startLingerTime > ItemSettings.lingerDuration)
                {
                    delete = true;
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(projectileSpritesheet, activeAxis.spriteRec, sourceRec, Color.White, 0, new Vector2(0, 0), flip, 0);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
