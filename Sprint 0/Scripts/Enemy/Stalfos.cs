using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0.Scripts.Enemy
{
    public class Stalfos : IEnemy
    {
        enum Direction { Up, Down, Left, Right, Still };

        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private StalfosSprite sprite;
        private Vector2 location;
        public Stalfos(Vector2 location)
        {
            this.location = location;
            sprite = (StalfosSprite) EnemySpriteFactory.Instance.CreateStalfos();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }

        public void Move()
        {

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
