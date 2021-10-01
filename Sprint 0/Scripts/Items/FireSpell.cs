using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class FireSpell : IItem
    {
        public enum Direction { RIGHT, UP, LEFT, DOWN }

        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;

        private bool linger = false;
        private double speedPerSecond = 150.0;
        private int maxDistance = 200;
        private double startLingerTime = 0;
        private double lingerDuration = 2.0;

        public FireSpell(Vector2 spawnLoc, Direction dir)
        {
            startPos = currentPos = spawnLoc;
            switch (dir)
            {
                case Direction.RIGHT:
                    directionVector = new Vector2(1, 0);
                    break;
                case Direction.UP:
                    directionVector = new Vector2(0, 1);
                    break;
                case Direction.LEFT:
                    directionVector = new Vector2(-1, 0);
                    break;
                case Direction.DOWN:
                    directionVector = new Vector2(0, -1);
                    break;
                default:
                    break;
            }
            sprite = ItemSpriteFactory.Instance.CreateFireSpellSprite();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            if (!linger)
            {
                currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
                // Distance based
                if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
                {
                    linger = true;
                }
            }
            else
            {
                startLingerTime += gt.ElapsedGameTime.TotalSeconds;
                if (startLingerTime > lingerDuration)
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
