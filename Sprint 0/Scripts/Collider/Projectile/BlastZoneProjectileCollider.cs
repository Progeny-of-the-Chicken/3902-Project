using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class BlastZoneProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;
        private Vector2 locationOffset = new Vector2((float)ObjectConstants.blastZonePositionOffset);

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BlastZoneProjectileCollider(IProjectile owner)
        {
            this.Owner = owner;
            _hitbox = ObjectConstants.blastZoneSize;
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint() + locationOffset.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            player.TakeDamage(Owner.Damage);
            player.PushBackGentlyBy(Overlap.DirectionToMoveObjectOff(player.collider.CollisionRectangle, _hitbox));
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            enemy.TakeDamage(Owner.Damage);
            enemy.KnockBack(Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
        }
    }
}
