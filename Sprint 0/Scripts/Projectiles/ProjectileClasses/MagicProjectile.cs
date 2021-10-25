using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Collider.Projectile;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class MagicProjectile : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector = new Vector2(1, 1);
        private Vector2 currentPos;
        private float spreadFactor = 0.3f;
        private bool delete = false;
        private bool friendly;

        private double speedPerSecond = 150.0;
        private double startTimeSeconds = 0.0;
        private double projectileLifetimeSeconds = 3.0;

        public bool Friendly { get => friendly; }

        public int Damage { get => 1; }

        public IProjectileCollider Collider { get => collider; }

        public MagicProjectile(Vector2 spawnLoc, FacingDirection mainDirection, FacingDirection secondaryDirection)
        {
            currentPos = spawnLoc;
            // Aquamentus facing direction
            if (mainDirection == FacingDirection.Left)
            {
                directionVector.X *= -1;
            }
            // Upward, Downward, or straight projectile
            switch (secondaryDirection)
            {
                case FacingDirection.Up:
                    directionVector.Y *= (-1) * spreadFactor;
                    break;
                case FacingDirection.Down:
                    directionVector.Y *= spreadFactor;
                    break;
                default:
                    directionVector.Y = 0;
                    break;
            }
            sprite = EnemySpriteFactory.Instance.CreateMagicProjectileSprite(1.5f);

            collider = new GenericEnemyProjectileCollider(this);
            friendly = false;
        }

        public void Update(GameTime gt)
        {
            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            startTimeSeconds += gt.ElapsedGameTime.TotalSeconds;
            if (startTimeSeconds > projectileLifetimeSeconds)
            {
                delete = true;
            }
            sprite.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            delete = true;
        }
    }
}
