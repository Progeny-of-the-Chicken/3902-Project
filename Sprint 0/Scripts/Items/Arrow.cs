using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class Arrow : IItem
    {
        public enum Direction { RIGHT, UP, LEFT, DOWN }

        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;

        private double speedPerSecond = 150.0;
        private int maxDistance = 200;
        private double silverArrowSpeedCoef = 2.0;
        private bool pop = false;
        private double popDurationSeconds = 0.2;

        public Arrow(Vector2 spawnLoc, Direction dir, bool silver)
        {
            startPos = currentPos = spawnLoc;
            if (silver)
            {
                maxDistance = (int) (maxDistance * silverArrowSpeedCoef);
            }

            switch (dir)
            {
                case Direction.RIGHT:
                    directionVector = new Vector2(1, 0);
                    sprite = ItemSpriteFactory.Instance.CreateArrowSprite(ArrowSprite.Orientation.RIGHT, silver);
                    break;
                case Direction.UP:
                    directionVector = new Vector2(0, 1);
                    sprite = ItemSpriteFactory.Instance.CreateArrowSprite(ArrowSprite.Orientation.UP, silver);
                    break;
                case Direction.LEFT:
                    directionVector = new Vector2(-1, 0);
                    sprite = ItemSpriteFactory.Instance.CreateArrowSprite(ArrowSprite.Orientation.LEFT, silver);
                    break;
                case Direction.DOWN:
                    directionVector = new Vector2(0, -1);
                    sprite = ItemSpriteFactory.Instance.CreateArrowSprite(ArrowSprite.Orientation.DOWN, silver);
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            if (!pop)
            {
                currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
                // Delete based on distance
                if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
                {
                    pop = true;
                    sprite = ItemSpriteFactory.Instance.CreateArrowPopSprite();
                }
            }
            else
            {
                popDurationSeconds -= gt.ElapsedGameTime.TotalSeconds;
                if (popDurationSeconds <= 0.0)
                {
                    delete = true;
                }
            }
            
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
