using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class BombProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BombProjectileCollider(IProjectile owner)
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
            // No collision response
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // No collision response
        }
    }
}
