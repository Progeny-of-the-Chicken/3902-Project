using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class ManhandlaHeadCollider : IEnemyCollider
    {
        private IEnemy owner;
        private Rectangle hitbox;

        public IEnemy Owner { get => owner; }
        
        public Rectangle Hitbox { get => hitbox; }

        public ManhandlaHeadCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            hitbox = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
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
