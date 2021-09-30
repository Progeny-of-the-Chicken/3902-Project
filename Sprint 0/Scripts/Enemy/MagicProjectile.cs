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
        MagicProjectileSprite sprite;
        private Vector2 location;
        private int speed = 200;
        private Vector2 direction;
        public MagicProjectile(Vector2 location, Vector2 direction)
        {
            this.location = location;
            this.direction = direction;
            sprite = (MagicProjectileSprite) EnemySpriteFactory.Instance.CreateMagicProjectileSprite();
        }
        public void Update(GameTime t)
        {
            Move(t);
            sprite.Update(t);
        }

        public void Move(GameTime t)
        {
            this.location += direction * speed * (float)t.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
