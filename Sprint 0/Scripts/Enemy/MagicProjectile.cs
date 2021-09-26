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
        public MagicProjectile(Vector2 location)
        {
            this.location = location;
            sprite = (MagicProjectileSprite) EnemySpriteFactory.Instance.CreateMagicProjectileSprite();
        }
        public void Update(GameTime t)
        {
            Move(t);
            sprite.Update(t);
        }

        public void Move(GameTime t)
        {
            this.location.X -= speed * (float)t.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
