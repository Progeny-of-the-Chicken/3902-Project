using System.Collections.Generic;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class EnemyWallCollisionHandler : ICollisionHandler
    {
        private HashSet<IEnemy> enemies;
        private HashSet<IWall> walls;

        public EnemyWallCollisionHandler(HashSet<IEnemy> enemies, HashSet<IWall> walls)
        {
            this.enemies = enemies;
            this.walls = walls;
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (IWall wall in walls)
                {
                    if (wall.Collider.Hitbox.Intersects(enemy.Collider.Hitbox))
                    {
                        wall.Collider.OnEnemyCollision(enemy);
                    }
                }
            }
        }
    }
}
