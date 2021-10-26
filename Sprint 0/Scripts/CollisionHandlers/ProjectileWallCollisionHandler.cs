using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class ProjectileWallCollisionHandler : ICollisionHandler
    {
        private HashSet<IProjectile> projectiles;
        private HashSet<IWall> walls;

        public ProjectileWallCollisionHandler(HashSet<IProjectile> projectiles, HashSet<IWall> walls)
        {
            this.projectiles = projectiles;
            this.walls = walls;
        }

        public void Update()
        {
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IWall wall in walls)
                {
                    if (wall.Collider.Hitbox.Intersects(projectile.Collider.Hitbox))
                    {
                        wall.Collider.OnProjectileCollision(projectile);
                    }
                }
            }
        }
    }
}
