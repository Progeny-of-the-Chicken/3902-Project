using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0
{
    public interface ILink
    {
        void Draw(SpriteBatch sb);
        void Update(GameTime gt);
        public void TakeDamage(int damage);
    }
}