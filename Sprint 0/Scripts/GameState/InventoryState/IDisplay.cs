using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.GameState.InventoryState
{
    public interface IDisplay
    {
        void Update(GameTime gt);

        void Draw(SpriteBatch spriteBatch, GameTime gt);

        void Scroll(Vector2 displacement);
    }
}
