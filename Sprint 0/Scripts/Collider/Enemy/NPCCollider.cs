﻿using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class NPCCollider : IEnemyCollider
    {
        Rectangle hitbox;
        public IEnemy owner { get => owner; }
        public IEnemy _owner;

        public Rectangle collisionRectangle { get => hitbox; }

        public NPCCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = owner;
            this.hitbox = collisionRectangle;
        }
        public void OnPlayerCollision(Link player)
        {
            Vector2 pushBack = Vector2.Zero;
            pushBack = Overlap.DirectionToMoveObjectOff(hitbox, player.collider.CollisionRectangle);
            player.PushBackBy(pushBack);
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
