using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Collider;

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
                foreach (IEnemy enemy in enemies)
                {
                    if (projectile.Collider.Hitbox.Intersects(enemy.Collider.Hitbox))
                    {
                        projectile.Collider.OnEnemyCollision(enemy);
                        enemy.Collider.OnProjectileCollision(projectile);
                    }
                    Dodongo dodongo = enemy as Dodongo;
                    if(dodongo != null && projectile.Collider.Hitbox.Intersects(dodongo.DetectionCollider.Hitbox))
                    {
                        dodongo.DetectionCollider.OnProjectileCollision(projectile);
                    }
                }
            }
        }
    }
}
