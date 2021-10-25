using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class BlastZoneProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BlastZoneProjectileCollider(IProjectile owner)
        {
            this.Owner = owner;
            _hitbox = new Rectangle(0, 0, ObjectConstants.blastZoneWidthHeight, ObjectConstants.blastZoneWidthHeight);
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            player.TakeDamage(Owner.Damage);
            // TODO: call Link knockback
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            enemy.TakeDamage(Owner.Damage);
            enemy.KnockBack(Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
        }
    }
}
