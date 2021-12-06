using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class FireSpellProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public FireSpellProjectileCollider(IProjectile owner)
        {
            this.Owner = owner;
            _hitbox = SpriteRectangles.bombFrame;
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link link)
        {
            if (((FireSpell)Owner).linger)
            {
                link.TakeDamage(Owner.Damage);
            }
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            if (enemy is Darknut && enemy.CanBeAffectedByPlayer)
            {
                ((Darknut)enemy).TryTakeDamage(Owner.Damage, Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
            }
            else if (enemy is MegaDarknut && enemy.CanBeAffectedByPlayer)
            {
                ((MegaDarknut)enemy).TryTakeDamage(Owner.Damage, Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
            }
            else if (enemy.CanBeAffectedByPlayer)
            {
                // No knockback
                enemy.TakeDamage(Owner.Damage);
            }
        }
    }
}
