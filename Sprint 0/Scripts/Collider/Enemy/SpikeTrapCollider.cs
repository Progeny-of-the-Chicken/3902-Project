using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class SpikeTrapCollider : IEnemyCollider
    {

        public IEnemy Owner { get => owner; }
        private SpikeTrap owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public SpikeTrapCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = (SpikeTrap)owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            player.TakeDamage(owner.Damage);
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow || projectile is SwordBeam)
            {
                projectile.Despawn();
            }
        }
    }
}
