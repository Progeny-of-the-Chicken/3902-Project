using System.Collections.Generic;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class EnemyBlockCollisionHandler : ICollisionHandler
    {
        private HashSet<IEnemy> enemies;
        private HashSet<ITerrain> blocks;

        public EnemyBlockCollisionHandler(HashSet<IEnemy> enemies, HashSet<ITerrain> blocks)
        {
            this.enemies = enemies;
            this.blocks = blocks;
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (ITerrain block in blocks)
                {
                    Wallmaster cast = enemy as Wallmaster;
                    if (block.Collider.Hitbox.Intersects(enemy.Collider.collisionRectangle) && cast == null)
                    {
                        block.Collider.OnEnemyCollision(enemy);
                    }

                }
            }
        }
    }
}
