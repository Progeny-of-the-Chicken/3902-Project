using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    public class OldMan : IEnemy
    {
        private OldManSprite sprite;
        private Vector2 location;
        public OldMan(Vector2 location)
        {
            this.location = location;
            sprite = (OldManSprite)EnemySpriteFactory.Instance.CreateOldManSprite();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
