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
        private Vector2 directionVector = ObjectConstants.DownUnitVector + ObjectConstants.RightUnitVector;
        private Vector2 currentPos;
        private float spreadFactor = ObjectConstants.magicProjectileSpread;
        private bool delete = false;
        private bool friendly;

        private double speedPerSecond = ObjectConstants.magicProjectileSpeed;
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private double projectileLifetimeSeconds = ObjectConstants.magicProjectileLifetime;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.magicProjectileDamage; }

        public IProjectileCollider Collider { get => collider; }

        public MagicProjectile(Vector2 spawnLoc, FacingDirection mainDirection, FacingDirection secondaryDirection)
        {
            currentPos = spawnLoc;
            // Aquamentus facing direction
            if (mainDirection == FacingDirection.Left)
            {
                directionVector.X *= ObjectConstants.vectorFlip;
            }
            // Upward, Downward, or straight projectile
            switch (secondaryDirection)
            {
                case FacingDirection.Up:
                    directionVector.Y *= ObjectConstants.vectorFlip * spreadFactor;
                    break;
                case FacingDirection.Down:
                    directionVector.Y *= spreadFactor;
                    break;
                default:
                    directionVector.Y = ObjectConstants.zero;
                    break;
            }
            sprite = EnemySpriteFactory.Instance.CreateMagicProjectileSprite();

            collider = ProjectileColliderFactory.Instance.CreateMagicProjectileCollider(this);
            friendly = false;
            SFXManager.Instance.PlayFireMagicRod();
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
            collider.Update(currentPos);
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
