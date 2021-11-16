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
    class WMDColliderLeft : IEnemyCollider
    {
        public IEnemy Owner { get => Owner; }
        private Wallmaster _owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public WMDColliderLeft(IEnemy owner, Rectangle Hitbox)
        {
            this._owner = (Wallmaster)owner;
            this.rectangle = Hitbox;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {

            _owner.ChangeDir(3);

        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow)
            {
                projectile.Despawn();
            }
        }
    }
}