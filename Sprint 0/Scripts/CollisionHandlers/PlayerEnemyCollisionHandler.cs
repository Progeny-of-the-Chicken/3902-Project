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
                }
                SpikeTrap cast = enemy as SpikeTrap;
                Wallmaster cast2 = enemy as Wallmaster;
                if (cast != null)
                {
                    if (link.collider.CollisionRectangle.Intersects(cast.ColliderUp.Hitbox))
                    {
                        cast.ColliderUp.OnPlayerCollision(link);
                    }
                    if (link.collider.CollisionRectangle.Intersects(cast.ColliderDown.Hitbox))
                    {
                        cast.ColliderDown.OnPlayerCollision(link);
                    }
                    if (link.collider.CollisionRectangle.Intersects(cast.ColliderRight.Hitbox))
                    {
                        cast.ColliderRight.OnPlayerCollision(link);
                    }
                    if (link.collider.CollisionRectangle.Intersects(cast.ColliderLeft.Hitbox))
                    {
                        cast.ColliderLeft.OnPlayerCollision(link);
                    }
                    if (cast2 != null)
                    {
                        if (link.collider.CollisionRectangle.Intersects(cast2.WMDColliderUp.Hitbox))
                        {
                            cast2.WMDColliderUp.OnPlayerCollision(link);
                        }
                        if (link.collider.CollisionRectangle.Intersects(cast2.WMDColliderDown.Hitbox))
                        {
                            cast2.WMDColliderDown.OnPlayerCollision(link);
                        }
                        if (link.collider.CollisionRectangle.Intersects(cast2.WMDColliderRight.Hitbox))
                        {
                            cast2.WMDColliderRight.OnPlayerCollision(link);
                        }
                        if (link.collider.CollisionRectangle.Intersects(cast2.WMDColliderLeft.Hitbox))
                        {
                            cast2.WMDColliderLeft.OnPlayerCollision(link);
                        }
                    }
                }
                Rope rope = enemy as Rope;
                if (rope != null && link.collider.CollisionRectangle.Intersects(rope.ChaseCollider.Hitbox))
                {
                    rope.ChaseCollider.OnPlayerCollision(link);
                }
            }
        }
    }
}
