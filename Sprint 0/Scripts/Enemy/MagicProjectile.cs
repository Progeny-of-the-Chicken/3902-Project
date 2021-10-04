using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    public class MagicProjectile : IEnemy
    {
        ISprite sprite;

        Vector2 location;
        Vector2 direction;

        int speed = 200;

        float lifeSpan = 3.5f;
        float timeSinceFire;

        bool isActive = false;

        public MagicProjectile()
        {
            sprite = EnemySpriteFactory.Instance.CreateMagicProjectileSprite();
            timeSinceFire = lifeSpan;
        }
        public void Fire(Vector2 location, Vector2 direction)
        {
            this.location = location;
            this.direction = direction;
            timeSinceFire = 0;
        }
        public void Update(GameTime t)
        {
            timeSinceFire += (float) t.ElapsedGameTime.TotalSeconds;
            if (isActive = timeSinceFire < lifeSpan)
            {
                Move(t);
                sprite.Update(t);
            }
        }

        void Move(GameTime t)
        {
            this.location += direction * speed * (float)t.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            if (isActive)
            {
                sprite.Draw(sb, location);
            }
        }
    }
}
