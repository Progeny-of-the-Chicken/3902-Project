﻿using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Collider.Terrain
{
    public class GenericWallCollider : IBlockCollider
    {
        private ITerrain owner;
        private Rectangle hitbox;

        public GenericWallCollider(ITerrain owner)
        {
            this.owner = owner;
        }

        public ITerrain Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.collisionRectangle);
            enemy.KnockBack(adjustmentForEnemy);
            
        }

        public void OnLinkCollision(Link link)
        {
            //Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, link.Collider.collisionRectangle); TODO: get links collider to find his position
            //link.(adjustmentForEnemy); TODO: update links position
            link.StopMoving();
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //if()
            projectile.Despawn();
        }

        public void Update(Vector2 location)
        {
            //All walls do not move
        }
    }
}