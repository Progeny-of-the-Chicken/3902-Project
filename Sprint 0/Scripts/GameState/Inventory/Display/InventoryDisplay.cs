using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.Inventory.Display
{
    public class InventoryDisplay : IDisplay
    {
        private Dictionary<ISprite, Vector2> weapons;
        private ISprite selectionSprite;
        private Vector2 selectionLocation;
        private int selectionIndex;

        private int spaceBetweenWeapon = ObjectConstants.inventorySpaceBetweenWeapon;
        private int spaceBetweenSelection = ObjectConstants.inventorySpaceBetweenSelection;
        private int weaponListStartIndex = ObjectConstants.inventoryWeaponListStartIndex;

        public InventoryDisplay()
        {
            ParseInventory();
            InitializeSelection();
        }

        public void Update(GameTime gt)
        {
            selectionSprite.Update(gt);
            // No animation for weapons
            // TODO: Check whether placeholder colors need to be covered by black boxes
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            foreach (KeyValuePair<ISprite, Vector2> weapon in weapons)
            {
                weapon.Key.Draw(spriteBatch, weapon.Value);
            }
            selectionSprite.Draw(spriteBatch, selectionLocation);
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (KeyValuePair<ISprite, Vector2> weapon in weapons)
            {
                weapons[weapon.Key] += displacement;
            }
            selectionLocation += displacement;
        }

        public void SelectWeapon()
        {
            // TODO: Update selected item, update inventory's selected item
        }

        public void MoveSelection(FacingDirection direction)
        {
            int index = ComputeIndexFromDirection(direction);
            if (ValidSelectionMovement(index))
            {
                selectionIndex = index;
            }
        }

        //----- Helper methods to set up weapon sprites from inventory -----//

        private void ParseInventory()
        {
            // TODO: Replace with inventory search function
            // if map, if compass, foreach weapon in inventory...
        }

        private void InitializeSelection()
        {
            // TODO: Place selection at selected item
        }

        //----- Helper method for selection movement -----//

        private int ComputeIndexFromDirection(FacingDirection direction)
        {
            int index = selectionIndex;
            switch (direction) {
                case FacingDirection.Right:
                    index += ObjectConstants.inventoryMoveSelectionIndexRight;
                    break;
                case FacingDirection.Up:
                    index += ObjectConstants.inventoryMoveSelectionIndexUp;
                    break;
                case FacingDirection.Left:
                    index += ObjectConstants.inventoryMoveSelectionIndexLeft;
                    break;
                case FacingDirection.Down:
                    index += ObjectConstants.inventoryMoveSelectionIndexDown;
                    break;
            }
            return index;
        }

        private bool ValidSelectionMovement(int indexToTest)
        {
            bool valid = true;
            if (indexToTest < weaponListStartIndex || indexToTest > weapons.Count)
            {
                valid = false;
            }
            return valid;
        }
    }
}
