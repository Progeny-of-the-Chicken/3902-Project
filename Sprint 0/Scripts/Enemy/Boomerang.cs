using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Enemy
{
    class Boomerang : IEnemy
    {
        private BoomerangSprite sprite;
        private Vector2 location;
        private int speed = 200;
        private int moveLength = 50;
        public Boomerang(Vector2 location)
        {
            this.location = location;
            sprite = (BoomerangSprite)EnemySpriteFactory.Instance.CreateBoomerangSprite();
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

        public void ShootProjectile()
        {
            //not needed
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}

