using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class ProjectilePlayerCollisionHandler : ICollisionHandler
    {
        private HashSet<IProjectile> projectiles;
        private ILink link;

        public ProjectilePlayerCollisionHandler(HashSet<IProjectile> projectiles, ILink link)
        {
            this.projectiles = projectiles;
            this.link = link;
        }

        public void Update()
        {
            foreach (IProjectile projectile in projectiles)
            {
                if (((Link)link).collider.CollisionRectangle.Intersects(projectile.Collider.Hitbox)) {
                    projectile.Collider.OnPlayerCollision((Link)link);
                    ((Link)link).collider.OnProjectileCollision(projectile);
                }
            }
        }
    }
}
