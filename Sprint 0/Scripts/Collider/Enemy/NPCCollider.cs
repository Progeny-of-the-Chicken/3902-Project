using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class NPCCollider : IEnemyCollider
    {
        IEnemy owner;
        Rectangle hitbox;
        public IEnemy Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public NPCCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.hitbox = collisionRectangle;
        }
        public void OnPlayerCollision(Link player)
        {
            Vector2 pushBack = Overlap.DirectionToMoveObjectOff(hitbox, player.collider.CollisionRectangle);
            player.PushBackInstantlyBy(pushBack);
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //can implement ability to counterattack, however that's low on our priorities for now
        }

        public void Update(Vector2 location)
        {
            //unused
        }
    }
}
