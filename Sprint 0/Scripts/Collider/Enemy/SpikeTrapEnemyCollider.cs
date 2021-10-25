using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class SpikeTrapEnemyCollider : IEnemyCollider
    {
        public IEnemy owner { get => _owner; }
        private SpikeTrap _owner;
        public Rectangle collisionRectangle { get => collisionRectangle; }
        public Rectangle detectionRectangleX;
        public Rectangle detectionRectangkeY;
        private Rectangle rectangle;
        public SpikeTrapEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = (SpikeTrap)owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
           // _owner.Move(GameTime gt);
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //despawn projectile
        }
    }
}
