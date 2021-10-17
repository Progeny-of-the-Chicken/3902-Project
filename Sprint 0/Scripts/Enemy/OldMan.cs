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

        public int damage { get => _damage; }
        const int _damage = 0;

        public OldMan(Vector2 location, float scale)
        {
            this.location = location;
            sprite = (OldManSprite)EnemySpriteFactory.Instance.CreateOldManSprite(scale);
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }

        public void TakeDamage(int damage, Vector2 knockback)
        {
            throw new NotImplementedException();
        }
    }
}
