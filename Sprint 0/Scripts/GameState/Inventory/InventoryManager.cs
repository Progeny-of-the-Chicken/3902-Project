using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.GameState.Inventory
{
    public class InventoryManager : IInventoryManager
    {
        private static InventoryManager instance = new InventoryManager();

        public static InventoryManager Instance
        {
            get
            {
                return instance;
            }
        }

        private InventoryManager()
        {
        }

        public void Init()
        {

        }

        public void Update(GameTime gt)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void SelectWeapon()
        {

        }

        public void MoveSelection(FacingDirection diration)
        {

        }
    }
}
