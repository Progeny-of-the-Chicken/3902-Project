using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class Goriya : IEnemy
    {
        enum Direction { Up, Down, Left, Right, Still };

        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private GoriyaFrontSprite spriteF;
        private GoriyaBackSprite spriteB;
        private GoriyaRightSprite spriteR;
        private ISprite sprite;
        private bool MovingLeft;
        private bool MovingRight;
        private bool MovingUp;
        private bool MovingDown;
        private Vector2 location;
        public Goriya(Vector2 location)
        {
            this.location = location;
            sprite = (GoriyaFrontSprite)EnemySpriteFactory.Instance.CreateFrontGoriyaSprite();
            spriteF = (GoriyaFrontSprite)EnemySpriteFactory.Instance.CreateFrontGoriyaSprite();
            spriteB = (GoriyaBackSprite)EnemySpriteFactory.Instance.CreateBackGoriyaSprite();
            spriteR = (GoriyaRightSprite)EnemySpriteFactory.Instance.CreateRightGoriyaSprite();
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

