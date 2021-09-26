using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Enemy
{
    public class Aquamentus : IEnemy
    {
        ISprite sprite;
        private MagicProjectile projectile;
        private Vector2 location;
        private float projectileLifespan = 2.5f;
        private float timeSinceFire = 0;
        private float reloadTime = 3.5f;
        public Aquamentus(Vector2 location)
        {
            this.location = location;
            sprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite();
        }
        public void Update(GameTime t)
        {
            sprite.Update(t);
            timeSinceFire += (float) t.ElapsedGameTime.TotalSeconds;
            if(timeSinceFire >= reloadTime)
            {
                timeSinceFire = 0;
                ShootProjectile();
            }
            if(timeSinceFire >= projectileLifespan)
            {
                projectile = null;
            }
            if (projectile != null)
            {
                projectile.Update(t);
            }
        }

        public void Move()
        {
            
        }

        public void ShootProjectile()
        {
            projectile = (MagicProjectile)EnemyFactory.Instance.CreateMagicProjectile(location);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
            if (projectile != null)
            {
                projectile.Draw(sb);
            }
        }

    }
}
