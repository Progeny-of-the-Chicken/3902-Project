using Sprint_0.Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.CollisionHandlers
{
    class EnemyEnemyCollisionHandler : ICollisionHandler
    {
        private HashSet<IEnemy> enemies;

        public EnemyEnemyCollisionHandler(HashSet<IEnemy> enemies)
        {
            this.enemies = enemies;
        }

        public void Update()
        {
            foreach (IEnemy enemy1 in enemies)
            {
                foreach(IEnemy enemy2 in enemies)
                {
                    if(!enemy1.Equals(enemy2) && enemy1.Collider.Hitbox.Intersects(enemy2.Collider.Hitbox))
                    {
                        enemy1.Collider.OnEnemyCollision(enemy2);
                        enemy2.Collider.OnEnemyCollision(enemy1);
                    }
                }
            }
        }
    }
}
