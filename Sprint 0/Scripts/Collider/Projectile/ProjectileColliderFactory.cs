using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class ProjectileColliderFactory
    {
        private static ProjectileColliderFactory instance = new ProjectileColliderFactory();

        public static ProjectileColliderFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileColliderFactory()
        {
        }

        public IProjectileCollider CreateArrowCollider(IProjectile projectile, FacingDirection direction)
        {
            return new RotatedProjectileCollider(projectile, direction);
        }

        public IProjectileCollider CreateBoomerangCollider(IProjectile projectile)
        {
            return new BoomerangProjectileCollider(projectile);
        }

        public IProjectileCollider CreateBombCollider(IProjectile projectile)
        {
            return new BombProjectileCollider(projectile);
        }

        public IProjectileCollider CreateBlastZoneCollider(IProjectile projectile)
        {
            return new BlastZoneProjectileCollider(projectile);
        }

        public IProjectileCollider CreateFireSpellCollider(IProjectile projectile)
        {
            return new FireSpellProjectileCollider(projectile);
        }

        public IProjectileCollider CreateMagicProjectileCollider(IProjectile projectile)
        {
            return new GenericEnemyProjectileCollider(projectile);
        }

        public IProjectileCollider CreateSwordAttackHitboxCollider(IProjectile projectile, FacingDirection direction)
        {
            return new RotatedProjectileCollider(projectile, direction);
        }

        public IProjectileCollider CreateSwordBeamCollider(IProjectile projectile, FacingDirection direction)
        {
            return new RotatedProjectileCollider(projectile, direction);
        }
    }
}
