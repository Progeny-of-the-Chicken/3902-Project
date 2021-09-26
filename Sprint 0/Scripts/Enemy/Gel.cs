using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        private GelSprite sprite;
        private Vector2 location;

        public Gel(Vector2 location)
        {
            this.location = location;
            sprite = (GelSprite)EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void Update(GameTime t)
        {
            sprite.Update(t);   
        }

        public void Move()
        {

        }

        public void ShootProjectile()
        {
            //not used
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
