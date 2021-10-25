using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class ProjectileBlockCollisionHandler : ICollisionHandler
    {
        private HashSet<IProjectile> projectiles;
        private HashSet<ITerrain> blocks;

        public ProjectileBlockCollisionHandler(HashSet<IProjectile> projectiles, HashSet<ITerrain> blocks)
        {
            this.projectiles = projectiles;
            this.blocks = blocks;
        }

        public void Update()
        {
            foreach (IProjectile projectile in projectiles)
            {
                foreach (ITerrain block in blocks)
                {
                    // Compare projectile hitbox to block hitbox
                }
            }
        }
    }
}
