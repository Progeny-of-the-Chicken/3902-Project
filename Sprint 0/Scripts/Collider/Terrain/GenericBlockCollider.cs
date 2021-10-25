using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Collider.Terrain
{
    public class GenericBlockCollider : IBlockCollider
    {
        private ITerrain owner;
        private Rectangle hitbox;

        public GenericBlockCollider(ITerrain owner, Rectangle hitbox)
        {
            this.owner = owner;
            this.hitbox = hitbox;
        }

        public ITerrain Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            //Keese can go over blocks
            if(!(enemy is Keese))
            {
                Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.collisionRectangle);
                enemy.KnockBack(adjustmentForEnemy);
            }
        }

        public void OnLinkCollision(Link link)
        {
            //Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, link.Collider.collisionRectangle); TODO: get links collider to find his position
            //link.(adjustmentForEnemy); TODO: update links position
            link.StopMoving();
            link.PushBackBy(Overlap.DirectionToMoveObjectOff(this.hitbox, link.collider.CollisionRectangle));
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //TODO: I don't think there are but maybe there should be interactions with specific projectiles
        }

        public void Update(Vector2 location)
        {
            //most blocks do not move so nothing should happen here
        }
    }
}
