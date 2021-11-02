using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DetectionCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private IEnemy owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public DetectionCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow)
            {
                projectile.Despawn();
            }
        }
    }
}
