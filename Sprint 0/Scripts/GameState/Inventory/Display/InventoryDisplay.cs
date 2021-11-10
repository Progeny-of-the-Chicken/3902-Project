using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.InventorySprites;

namespace Sprint_0.Scripts.GameState.Inventory.Display
{
    public class InventoryDisplay : IDisplay
    {
        // TODO: Check whether this is needed based on inventory implementation
        private Dictionary<ISprite, Vector2> itemSprites;
        private ISprite selectionSprite;
        private Vector2 selectionLocation;
        private int selectionIndex;
        private ISprite selectedWeaponSprite;
        private Vector2 selectedWeaponLocation;
        private Vector2 backdropLocation = ObjectConstants.backdropSpawnLocation;

        public InventoryDisplay()
        {
            InitializeInventory();
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
            foreach (KeyValuePair<ISprite, Vector2> item in itemSprites)
            {
                item.Key.Draw(spriteBatch, item.Value);
            }
            selectionSprite.Draw(spriteBatch, selectionLocation);
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (KeyValuePair<ISprite, Vector2> item in itemSprites)
            {
                itemSprites[item.Key] += displacement;
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
                selectionLocation = ObjectConstants.inventorySlotLocations[selectionIndex];
            }
        }

        //----- Helper method for selection movement -----//

        private int ComputeIndexFromDirection(FacingDirection direction)
        {
            return direction switch
            {
                FacingDirection.Right => selectionIndex + ObjectConstants.inventoryMoveSelectionRightIndex,
                FacingDirection.Up => selectionIndex + ObjectConstants.inventoryMoveSelectionUpIndex,
                FacingDirection.Left => selectionIndex + ObjectConstants.inventoryMoveSelectionLeftIndex,
                FacingDirection.Down => selectionIndex + ObjectConstants.inventoryMoveSelectionDownIndex,
                // Default should never happen
                _ => selectionIndex
            };
        }

        private bool ValidSelectionMovement(int indexToTest)
        {
            return (indexToTest >= ObjectConstants.inventoryWeaponListStartIndex || indexToTest <= itemSprites.Count);
        }

        //----- Helper methods to set up weapon sprites from inventory -----//

        private void InitializeSelection()
        {
            // TODO: Place selection at selected item
            // Temporary dummy selection
            int selectedWeaponIndex = 1;

            selectionSprite = InventorySpriteFactory.Instance.CreateSelectionSprite();
            selectionLocation = backdropLocation + ObjectConstants.inventorySlotLocations[selectedWeaponIndex];
        }

        private void InitializeInventory()
        {
            // TODO: Replace with inventory search function
            // Temporary dummy inventory for testing purposes
            List<WeaponType> inventory = new List<WeaponType>
            {
                WeaponType.BlueCandle,
                WeaponType.Bomb,
                WeaponType.BasicBoomerang
            };
            int selectedWeaponIndex = 1;
            bool map = true;
            bool compass = true;

            // Weapons
            for (int i = ObjectConstants.inventoryWeaponListStartIndex; i < inventory.Count; i++)
            {
                Rectangle sourceRec = getFrameForWeapon(inventory[i]);
                // Center weapon on inventory slot
                Vector2 weaponSlot = backdropLocation + ObjectConstants.weaponFromBackdropLocation + ObjectConstants.inventorySlotLocations[i]
                    + new Vector2((ObjectConstants.inventorySlotWidthHeight - sourceRec.X) / ObjectConstants.halveOpDenom,
                    (ObjectConstants.inventorySlotWidthHeight - sourceRec.Y) / ObjectConstants.halveOpDenom);
                itemSprites.Add(InventorySpriteFactory.Instance.CreateWeaponSprite(sourceRec), weaponSlot);
            }
            // Map and compass
            if (map)
            {
                itemSprites.Add(InventorySpriteFactory.Instance.CreateMapSprite(), backdropLocation + ObjectConstants.mapFromBackdropLocation);
            }
            if (compass)
            {
                itemSprites.Add(InventorySpriteFactory.Instance.CreateCompassSprite(), backdropLocation + ObjectConstants.compassFromBackdropLocation);
            }
            // Selected weapon
            selectedWeaponSprite = InventorySpriteFactory.Instance.CreateWeaponSprite(getFrameForWeapon(inventory[selectedWeaponIndex]));
            selectedWeaponLocation = backdropLocation + ObjectConstants.selectionWeaponFromBackdropLocation;
        }

        private Rectangle getFrameForWeapon(WeaponType weapon)
        {
            return weapon switch
            {
                WeaponType.BasicBoomerang => SpriteRectangles.weaponBasicBoomerangFrame,
                WeaponType.MagicalBoomerang => SpriteRectangles.weaponMagicalBoomerangFrame,
                WeaponType.Bomb => SpriteRectangles.weaponBombFrame,
                WeaponType.BasicArrow => SpriteRectangles.weaponBasicArrowFrame,
                WeaponType.SilverArrow => SpriteRectangles.weaponSilverArrowFrame,
                WeaponType.Bow => SpriteRectangles.weaponBowFrame,
                WeaponType.BlueCandle => SpriteRectangles.weaponBlueCandleFrame,
                // Default should never happen
                _ => SpriteRectangles.weaponBlueCandleFrame
            };
        }
    }
}
