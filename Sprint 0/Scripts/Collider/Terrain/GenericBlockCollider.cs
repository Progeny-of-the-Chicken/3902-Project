using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Items;


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
            //Flying enemies
            if (!(enemy is Keese) && !(enemy is Aquamentus) && !(enemy is Patra) && !(enemy is MegaKeese) && !(enemy is Manhandla))
            {
                Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.Hitbox);
                enemy.SuddenKnockBack(adjustmentForEnemy);
                enemy.ChangeDirection();
            }
        }

        public void OnLinkCollision(Link link)
        {
            link.StopMoving();
            link.PushBackInstantlyBy(Overlap.DirectionToMoveObjectOff(this.hitbox, link.collider.CollisionRectangle));
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            // No projectile interaction
        }

        public void OnItemCollision(IItem item)
        {
            Vector2 adjustmentForBlock = Overlap.DirectionToMoveObjectOff(this.hitbox, item.Collider.Hitbox);
            item.MoveItemBlock(adjustmentForBlock);
        }

        public void Update(Vector2 location)
        {
            //most blocks do not move so nothing should happen here
        }
    }
}
