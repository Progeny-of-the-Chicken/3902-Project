﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider;


namespace Sprint_0.Scripts.Enemy
{
    class Keese : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle[] frames = { new Rectangle(200, 14, 16, 12), new Rectangle(183, 14, 18, 10) };


        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        
        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;

        public int Damage { get => _damage; }
        int _damage;
        int health = 1;
        const int knockbackDistance = 50;
        
        Vector2 location;
        Vector2 directionVector;

        public Keese(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            directionVector = Vector2.Zero;
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateKeeseSprite(scale, frames);
            Rectangle collision = new Rectangle(0, 0, (int)(frames[0].Width * scale), (int)(frames[0].Height * scale));
            collider = new GenericEnemyCollider(this, collision);
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            if(directionVector != Vector2.Zero)
            {
                sprite.Update(gt);
            }
            collider.Update(location);
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
            randomDir.GetBytes(random);
            directionVector.X = (random[0] % 3) - 1;
            directionVector.Y = (random[1] % 3) - 1;
        }
        public void TakeDamage(int damage, Vector2 knockback)
        {
            health -= damage;
            location += knockback * knockbackDistance;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
