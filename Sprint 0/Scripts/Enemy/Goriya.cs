using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class Goriya : IEnemy
    {
        enum Direction { Up, Down, Left, Right, Still };

        private static RNGCryptoServiceProvider randomDir; 
        private GoriyaFrontSprite spriteF;
        private GoriyaBackSprite spriteB;
        private GoriyaRightSprite spriteR;
        private GoriyaLeftSprite spriteL;
        private ISprite sprite;
        private Direction direction;
        private byte[] random;
        private float moveTime = 2;
        private float moveSpeed = 100;
        private float timeSinceMove = 0;
        private Vector2 location;
        private Vector2 directionVector;
        public Goriya(Vector2 location)
        {
            this.location = location;
            directionVector = new Vector2(0, 1) * moveSpeed;
            randomDir = new RNGCryptoServiceProvider();
            random = new byte[1];
            spriteF = (GoriyaFrontSprite)EnemySpriteFactory.Instance.CreateFrontGoriyaSprite();
            spriteB = (GoriyaBackSprite)EnemySpriteFactory.Instance.CreateBackGoriyaSprite();
            spriteR = (GoriyaRightSprite)EnemySpriteFactory.Instance.CreateRightGoriyaSprite();
            spriteL = (GoriyaLeftSprite)EnemySpriteFactory.Instance.CreateLeftGoriyaSprite();
            sprite = spriteF;
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            if (direction != Direction.Still)
            {
                sprite.Update(gt);
            }
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
                        sprite = spriteF;
                        directionVector = new Vector2(0, 1);
                        break;
                    case Direction.Left:
                        sprite = spriteL;
                        directionVector = new Vector2(-1, 0);
                        break;
                    case Direction.Right:
                        sprite = spriteR;
                        directionVector = new Vector2(1, 0);
                        break;
                    case Direction.Up:
                        sprite = spriteB;
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
            direction = Direction.Still;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}

