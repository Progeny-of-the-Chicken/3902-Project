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
        enum Direction { Up, Down, Left, Right };

        static RNGCryptoServiceProvider randomDir;
        byte[] random;
        
        ISprite[] sprites;
        ISprite sprite;
        
        float moveTime = 1.5f;
        float moveSpeed = 100;
        float timeSinceMove = 0;
        bool paused = false;

        Direction direction;
        Vector2 location;
        Vector2 directionVector;

        public Goriya(Vector2 location)
        {

            this.location = location;
            directionVector = new Vector2(0, 1);

            random = new byte[3];
            randomDir = new RNGCryptoServiceProvider();

            sprites = new ISprite[] { EnemySpriteFactory.Instance.CreateBackGoriyaSprite(),
                                    EnemySpriteFactory.Instance.CreateFrontGoriyaSprite(),
                                    EnemySpriteFactory.Instance.CreateLeftGoriyaSprite(),
                                    EnemySpriteFactory.Instance.CreateRightGoriyaSprite() };
            sprite = sprites[1];
        }

        public void Update(GameTime t)
        {
            Move(t);
            //if (!paused)
            //{
                sprite.Update(t);
            //}
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= moveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += directionVector * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        void SetRandomDirection()
        {
            //First byte is vertical/horizontal, second is +/-, third is whether it will shoot instead
            randomDir.GetBytes(random);
            if (random[2] % 5 == 0)
            {
                directionVector = Vector2.Zero;
                ShootProjectile();
            }
            else
            {
                int axis = random[0] % 2;
                int magnitude = random[1] % 2;
                if (axis == 0)
                {
                    directionVector.X = magnitude * 2 - 1;
                    directionVector.Y = 0;

                    direction = (Direction) magnitude + 2;
                }
                else
                {
                    directionVector.X = 0;
                    directionVector.Y = magnitude * 2 - 1;

                    direction = (Direction) magnitude;
                }
                sprite = sprites[(int) direction];
            }
        }

        public void ShootProjectile()
        {
            paused = true;
            //TODO: Boomerang logic
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}

