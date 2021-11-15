using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DetectionColliderRight : IEnemyCollider
    {
        public IEnemy Owner { get => Owner; }
        private SpikeTrap _owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public DetectionColliderRight(IEnemy owner, Rectangle Hitbox)
        {
            this._owner = (SpikeTrap)owner;
            this.rectangle = Hitbox;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {

            _owner.MoveRight();

        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow)
            {
                //not needed
            }
        }
    }
}
