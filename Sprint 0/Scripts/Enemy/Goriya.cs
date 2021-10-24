using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Enemy
{
    class Goriya : IEnemy
    {
        IProjectile boomerang;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir;
        byte[] random;

        Rectangle frontFrame = new Rectangle(222, 10, 15, 17);
        Rectangle backFrame = new Rectangle(240, 10, 14, 17);
        Rectangle[] rightFrames = { new Rectangle(256, 10, 14, 17), new Rectangle(274, 11, 16, 16) };

        public int Damage { get => _damage; }
        int _damage;
        int health = 1;
        const int knockbackDistance = 50;
        bool delete = false;

        float moveTime = 1.5f;
        float moveSpeed;
        float timeSinceMove = 0;

        FacingDirection direction;
        Vector2 location;
        (Vector2 directionVector, ISprite sprite) dependency;

        Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)> directionDependencies;
        public Goriya(Vector2 location, float scale)
        {

            this.location = location;

            moveSpeed = 25 * scale;

            random = new byte[3];
            randomDir = new RNGCryptoServiceProvider();
            directionDependencies = new Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)>();
            directionDependencies.Add(FacingDirection.Right, (new Vector2(1, 0), EnemySpriteFactory.Instance.CreateRightGoriyaSprite(scale, rightFrames)));
            directionDependencies.Add(FacingDirection.Left, (new Vector2(-1, 0), EnemySpriteFactory.Instance.CreateLeftGoriyaSprite(scale, rightFrames)));
            directionDependencies.Add(FacingDirection.Up, (new Vector2(0, -1), EnemySpriteFactory.Instance.CreateBackGoriyaSprite(scale, backFrame)));
            directionDependencies.Add(FacingDirection.Down, (new Vector2(0, 1), EnemySpriteFactory.Instance.CreateFrontGoriyaSprite(scale, frontFrame)));
            direction = FacingDirection.Down;
            directionDependencies.TryGetValue(direction, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(0, 0, (int)(frontFrame.Width * scale), (int)(frontFrame.Height * scale)));

            boomerang = null;
        }

        public void Update(GameTime t)
        {
            if (boomerang == null)
            {
                Move(t);
                dependency.sprite.Update(t);
            }
            else
            {
                boomerang.Update(t);
                if (boomerang.CheckDelete())
                {
                    boomerang = null;
                }
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
            location += dependency.directionVector * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        void SetRandomDirection()
        {
            //First byte is direction, second is whether it will shoot instead
            randomDir.GetBytes(random);
            if (random[1] % 5 == 0)
            {
                ShootProjectile();
            }
            else
            {
                direction = (FacingDirection)(random[0] % 4);
                directionDependencies.TryGetValue(direction, out dependency);
            }
        }

        public void ShootProjectile()
        {
            boomerang = ProjectileFactory.Instance.CreateEnemyBoomerang(location, direction);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= 0);
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback * knockbackDistance;
        }
        public bool CheckDelete()
        {
            return delete;
        }

        public void Draw(SpriteBatch sb)
        {
            dependency.sprite.Draw(sb, location);
            if(boomerang != null)
            {
                boomerang.Draw(sb);
            }
        }
    }
}

