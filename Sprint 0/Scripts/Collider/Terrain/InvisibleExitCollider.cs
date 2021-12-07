﻿using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Items;


namespace Sprint_0.Scripts.Collider.Terrain
{
    public class InvisibleExitCollider : IBlockCollider
    {
        private ITerrain owner;
        private Rectangle hitbox;

        public InvisibleExitCollider(ITerrain owner, Rectangle hitbox)
        {
            this.owner = owner;
            this.hitbox = hitbox;
        }

        public ITerrain Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            //Keese can go over blocks
            if (!(enemy is Keese))
            {
                Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.Hitbox);
                enemy.SuddenKnockBack(adjustmentForEnemy);
            }
        }

        public void OnLinkCollision(Link link)
        {
            link.StopMoving();
            link.ResetPosition(ObjectConstants.leftOfStairSpawnPosition);
            RoomManager.Instance.SwitchToRoom(ObjectConstants.stairRoom);
            SFXManager.Instance.PlayStairs();
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            // No projectile interaction
        }

        public void OnItemCollision(IItem item)
        {
            //no item collision

        }

        public void Update(Vector2 location)
        {
            //Stairs do not move
        }
    }
}
