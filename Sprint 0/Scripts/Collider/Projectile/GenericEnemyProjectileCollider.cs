using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class GenericEnemyProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public GenericEnemyProjectileCollider(IProjectile owner)
        {
            Owner = owner;
            if (Owner is MagicProjectile)
            {
                _hitbox = ObjectConstants.standardProjectileSize;
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            if (player.CanBeAffectedByEnemy)
            {
                Vector2 pushBack = Overlap.DirectionToMoveObjectOff(_hitbox, player.collider.CollisionRectangle);
                //playing it safe to avoid dividebyzero
                if (!pushBack.Equals(Vector2.Zero))
                {
                    pushBack.Normalize();
                    pushBack *= ObjectConstants.DefaultEnemyKnockbackToLink;
                }
                player.PushBackGentlyBy(pushBack);
                player.TakeDamage(Owner.Damage);
            }
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // No collision response
        }
    }
}
