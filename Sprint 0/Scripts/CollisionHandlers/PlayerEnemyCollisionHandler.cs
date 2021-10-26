using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Collider;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class PlayerEnemyCollisionHandler : ICollisionHandler
    {
        Link link;
        private HashSet<IEnemy> enemies;

        public PlayerEnemyCollisionHandler(Link link, HashSet<IEnemy> enemies)
        {
            this.link = link;
            this.enemies = enemies;
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
            {
                if (link.collider.CollisionRectangle.Intersects(enemy.Collider.Hitbox))
                {
                    //if we implement logic for enemy collision in link collider we'll put uncomment the next line
                    //link.collider.OnEnemyCollision(enemy);
                    enemy.Collider.OnPlayerCollision(link);
                    SpikeTrap cast = (SpikeTrap)enemy;
                    if(cast != null)
                    {
                        enemy.XDetectionCollider.OnPlayerCollision(link);
                        enemy.YDetectionCollider.OnPlayerCollision(link);
                    }
                }
            }
        }
    }
}
