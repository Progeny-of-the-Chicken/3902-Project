using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class NPCCollider : IEnemyCollider
    {
        IEnemy _owner;
        Rectangle rectangle;
        public IEnemy owner => throw new NotImplementedException();

        public Rectangle collisionRectangle => throw new NotImplementedException();

        public NPCCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void OnPlayerCollision(ILink player)
        {
            //unused
        }

        public void OnProjectileCollision(FacingDirection direction, IProjectile projectile)
        {
            //unused
        }

        public void Update(Vector2 location)
        {
            //unused
        }
    }
}
