using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.GameState.Inventory
{
    public interface IInventoryManager
    {
        void Init();

        void Update(GameTime gt);

        void Draw(SpriteBatch spriteBatch);

        void SelectWeapon();

        void MoveSelection(FacingDirection diration);
    }
}
