using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        enum Direction { Up, Down, Left, Right, Still };
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private GelSprite sprite;
        private byte[] random;
        private float moveTime = 1;
        private float moveSpeed = 100;
        private float timeSinceMove = 0;
        private float pauseTime = 1;
        private float timePaused = 0;
        private Vector2 location;
        private Vector2 directionVector;
        private Direction direction;

        public Gel(Vector2 location)
        {
            this.location = location;
            directionVector = new Vector2(-1, 0) * moveSpeed;
            random = new byte[1];
            sprite = (GelSprite)EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void Update(GameTime t)
        {
            Move(t);
            sprite.Update(t);   
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            timePaused += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= moveTime + pauseTime)
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
                timePaused = 0;
            }
            if(timePaused >= pauseTime)
            {
                location += directionVector * (float)gt.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ShootProjectile()
        {
            //not used
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
