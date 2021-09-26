using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    public class Zol : IEnemy
    {
        private ZolSprite sprite;
        private Vector2 location;

        public Zol(Vector2 location)
        {
            this.location = location;
            sprite = (ZolSprite)EnemySpriteFactory.Instance.CreateZolSprite();
        }
        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void ShootProjectile()
        {
            //not used
        }
        public void Move()
        {

        }
    }
}
