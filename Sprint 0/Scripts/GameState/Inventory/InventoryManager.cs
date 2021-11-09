using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState.Inventory.Display;

namespace Sprint_0.Scripts.GameState.Inventory
{
    public class InventoryManager : IInventoryManager
    {
        private List<IDisplay> displays;

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
            displays.Add(new BackdropDisplay());
        }

        public void Update(GameTime gt)
        {
            foreach (IDisplay display in displays)
            {
                display.Update(gt);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            foreach (IDisplay display in displays)
            {
                display.Draw(spriteBatch, gt);
            }
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (IDisplay display in displays)
            {
                display.Scroll(displacement);
            }
        }

        public void SelectWeapon()
        {

        }

        public void MoveSelection(FacingDirection diration)
        {

        }
    }
}
