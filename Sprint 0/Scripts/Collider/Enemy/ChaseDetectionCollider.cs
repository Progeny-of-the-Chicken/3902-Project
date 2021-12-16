using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class ChaseDetectionCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private IEnemy owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        private Vector2 location;
        public ChaseDetectionCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.rectangle = collisionRectangle;
            location = Vector2.Zero;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
            this.location = location;
        }

        public void OnPlayerCollision(Link player)
        {
            if (owner is Rope)
            {
                ((Rope)owner).ChaseLink();
            }
            else if (owner is MegaDarknut)
            {
                ((MegaDarknut)owner).ChaseLink();
            }
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //None
        }
    }
}
