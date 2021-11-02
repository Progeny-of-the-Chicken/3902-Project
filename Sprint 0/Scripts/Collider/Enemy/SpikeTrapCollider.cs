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
            Rectangle intersect = Rectangle.Intersect(player.collider.CollisionRectangle, this.Hitbox);
            Vector2 direction;
            if (intersect.Width > intersect.Height)
            {
                direction = Vector2.UnitX;
                if (intersect.Location.X < owner.Location.X)
                {
                    direction *= ObjectConstants.vectorFlip;
                }
            } else
            {
                
                direction = Vector2.UnitY;
                if (intersect.Location.X < owner.Location.Y)
                {
                    direction *= ObjectConstants.vectorFlip;
                }
            }
            owner.SetHasHit(direction);
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
