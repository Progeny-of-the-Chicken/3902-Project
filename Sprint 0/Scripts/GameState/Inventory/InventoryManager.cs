using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState.InventoryState.Display;

namespace Sprint_0.Scripts.GameState.InventoryState
{
    public class InventoryManager : IInventoryManager
    {
        private List<IDisplay> displays;
        private int inventoryDisplayIndex = ObjectConstants.inventoryDisplayListIndex;

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
            displays.Add(new InventoryDisplay());
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
            ((InventoryDisplay)displays[inventoryDisplayIndex]).SelectWeapon();
        }

        public void MoveSelection(FacingDirection direction)
        {
            ((InventoryDisplay)displays[inventoryDisplayIndex]).MoveSelection(direction);
        }
    }
}
