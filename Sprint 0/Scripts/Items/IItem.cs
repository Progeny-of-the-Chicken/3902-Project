using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public interface IItem
    {
        void Update(GameTime gt);

        void Draw(SpriteBatch sb);

        bool CheckDelete();

        void Despawn();
    }
}
