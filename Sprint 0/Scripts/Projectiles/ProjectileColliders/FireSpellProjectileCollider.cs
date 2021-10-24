using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
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
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink link)
        {
            // TODO: Only make Link take damage if it is in linger state
            link.TakeDamage(Owner.Damage);
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            enemy.TakeDamage(Owner.Damage);
        }
    }
}
