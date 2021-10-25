using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class ProjectileEnemyCollisionHandler : ICollisionHandler
    {
        private HashSet<IProjectile> projectiles;
        private HashSet<IEnemy> enemies;

        public ProjectileEnemyCollisionHandler(HashSet<IProjectile> projectiles, HashSet<IEnemy> enemies)
        {
            this.projectiles = projectiles;
            this.enemies = enemies;
        }

        public void Update()
        {
            foreach (IProjectile projectile in projectiles)
            {
                // TODO: Compare projectile collider against enemy collider
            }
        }
    }
}
