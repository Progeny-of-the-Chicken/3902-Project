using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public class BoomerangProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;
        private FacingDirection direction;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BoomerangProjectileCollider(IProjectile owner, FacingDirection direction)
        {
            this.Owner = owner;
            this.direction = direction;
            // No size variation between basic and magical boomerangs
            _hitbox = SpriteRectangles.basicBoomerangFrames[0];
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink link)
        {
            if (Owner.Friendly)
            {
                // Add to inventory in Sprint 4
                Owner.Despawn();
            }
            else
            {
                // TODO: knockback link
                link.TakeDamage(Owner.Damage);
            }
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            if (Owner.Friendly)
            {
                enemy.TakeDamage(Owner.Damage);
            }
            else
            {
                Owner.Despawn();
            }
        }

        // TODO: Implement boomerang return
    }
}
