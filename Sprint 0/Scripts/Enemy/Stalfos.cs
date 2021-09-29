using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0.Scripts.Enemy
{
    public class Stalfos : IEnemy
    {
        enum Direction { Up, Down, Left, Right};

        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private StalfosSprite sprite;
        private byte[] random;
        private float moveTime = 2;
        private float moveSpeed = 100;
        private float timeSinceMove = 0;
        private Vector2 location;
        private Vector2 directionVector;
        private Direction direction;
        public Stalfos(Vector2 location)
        {
            this.location = location;
            directionVector = new Vector2(-1, 0) * moveSpeed;
            random = new byte[1];
            sprite = (StalfosSprite) EnemySpriteFactory.Instance.CreateStalfosSprite();
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                //Get a random direction to move in
                randomDir.GetBytes(random);
                direction = (Direction)(random[0] % 4);

                switch (direction)
                {
                    case Direction.Down:
                        directionVector = new Vector2(0, 1);
                        break;
                    case Direction.Left:
                        directionVector = new Vector2(-1, 0);
                        break;
                    case Direction.Right:
                        directionVector = new Vector2(1, 0);
                        break;
                    case Direction.Up:
                        directionVector = new Vector2(0, -1);
                        break;
                }
                directionVector *= moveSpeed;
                timeSinceMove = 0;
            }
            location += directionVector * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        public void ShootProjectile()
        {
            //not needed
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
