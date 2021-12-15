using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DodongoDetectionCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private Dodongo owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;

        public DodongoDetectionCollider(Dodongo owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            this.rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            //unused
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Bomb || projectile is ShotgunPelletProjectile)
            {
                projectile.Despawn();
                owner.Stun();
            }
        }
    }
}
