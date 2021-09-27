using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class Arrow : IItem
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private Texture2D projectileSpritesheet;
        private Rectangle sourceRec;
        private Direction pointing;

        private SpriteAxis activeAxis;
        private double arrowSpeed;
        private int arrowMaxDistance;
        private SpriteEffects flip;

        public Arrow(Texture2D spritesheet, Rectangle textureLocation, Vector2 spawnLoc, Direction dir, bool silver)
        {
            projectileSpritesheet = spritesheet;
            sourceRec = textureLocation;
            Rectangle destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRec.Width / 2), (int)spawnLoc.Y - (sourceRec.Height / 2),
                2 * sourceRec.Width, 2 * sourceRec.Height
            );
            pointing = dir;

            // Arrow stats
            arrowSpeed = ItemSettings.arrowSpeed;
            arrowMaxDistance = ItemSettings.arrowDistance;
            if (silver)
            {
                arrowMaxDistance = (int) (arrowMaxDistance * ItemSettings.silverArrowSpeedCoef);
            }

            // TODO: Clean up orientation logic
            switch (pointing)
            {
                case Direction.UP:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    arrowSpeed *= -1;
                    break;
                case Direction.LEFT:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.HORIZONTAL);
                    flip = SpriteEffects.FlipHorizontally;
                    arrowSpeed *= -1;
                    break;
                case Direction.DOWN:
                    activeAxis = new SpriteAxis(destinationRec, SpriteAxis.Orientation.VERTICAL);
                    flip = SpriteEffects.FlipVertically;
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
            bool delete = false;
            activeAxis.currentPos += (int) arrowSpeed;
            if (Math.Abs(activeAxis.currentPos - activeAxis.startPos) > arrowMaxDistance)
            {
                // TODO: Find a way to spawn puff in Item controller
                ItemSpriteFactory.Instance.CreateArrowPuff(new Vector2(activeAxis.spriteRec.X, activeAxis.spriteRec.Y));
                delete = true;
            }
            return delete;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(projectileSpritesheet, activeAxis.spriteRec, sourceRec, Color.White, 0, new Vector2(0, 0), flip, 0);
        }
    }
}
