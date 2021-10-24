using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
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
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink player)
        {
            // TODO: call Link knockback
            player.TakeDamage(Owner.Damage);
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // TODO: call enemy knockback with facing direction
            enemy.TakeDamage(Owner.Damage);
        }

        //----- Helper method for initializing the hitbox -----//

        private Vector2 getKnockbackDirection(Vector2 objectPos)
        {
            // TODO: Add knockback calculate here
            return new Vector2(0, 0);
        }
    }
}
