using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class WallmasterEnemyCollider : IEnemyCollider
    {
        public IEnemy owner { get => _owner; }
        private string firstRoom = "Room25";
        private Wallmaster _owner;
        public Rectangle collisionRectangle { get => collisionRectangle; }
        private Rectangle rectangle;
        public WallmasterEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = (Wallmaster)owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink player)
        {

            _owner.GrabLink();
        }

        public void OnProjectileCollision(FacingDirection collisionDirection, IProjectile projectile)
        {
            //despawn projectile
        }
    }

}

