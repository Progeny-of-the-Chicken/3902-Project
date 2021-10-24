using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public class BombProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;
        private FacingDirection direction;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BombProjectileCollider(IProjectile owner, FacingDirection direction)
        {
            this.Owner = owner;
            this.direction = direction;
            _hitbox = SpriteRectangles.bombFrame;
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink link)
        {
            // No collision response
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // No collision response
        }
    }
}
