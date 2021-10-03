using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    public class Aquamentus : IEnemy
    {
        ISprite sprite;
        private AquamentusProjectile projectile;
        private Vector2 location;
        private Vector2 direction = new Vector2(-1, 0);
        private Vector2 startLocation;
        private float speed = 100;
        private float moveDistance = 75;
        private float projectileLifespan = 2.5f;
        private float timeSinceFire = 0;
        private float reloadTime = 3.5f;
        private float shootSpriteTime = 0.5f;
        public Aquamentus(Vector2 location)
        {
            this.location = location;
            startLocation = location;
            sprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite();
        }
        public void Update(GameTime t)
        {
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
            if(location.X < startLocation.X - moveDistance || location.X > startLocation.X)
            {
                speed *= -1;
            }
            if((sprite as AquamentusShootSprite) != null && timeSinceFire >= shootSpriteTime)
            {
                sprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite();
            }
            Move(t);
            sprite.Update(t);
            if (projectile != null)
            {
                projectile.Update(t);
            }
        }

        public void Move(GameTime t)
        {
            location += speed * direction * (float)t.ElapsedGameTime.TotalSeconds;
        }

        public void ShootProjectile()
        {
            projectile = (AquamentusProjectile)EnemyFactory.Instance.CreateAquamentusProjectile(location);
            sprite = EnemySpriteFactory.Instance.CreateAquamentusShootSprite();
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
