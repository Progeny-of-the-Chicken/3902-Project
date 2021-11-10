using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.InventoryState.Display
{
    public class InventoryDisplay : IDisplay
    {
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
            selectedWeaponSprite.Draw(spriteBatch, selectedWeaponLocation);
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
            Inventory.Instance.SelectedWeaponIndex = selectionIndex;
            selectedWeaponSprite = InventorySpriteFactory.Instance.CreateWeaponSprite(getFrameForWeapon(Inventory.Instance.Weapons[selectionIndex]));
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
            selectionSprite = InventorySpriteFactory.Instance.CreateSelectionSprite();
            selectionLocation = backdropLocation + ObjectConstants.inventorySlotLocations[Inventory.Instance.SelectedWeaponIndex];
        }

        private void InitializeInventory()
        {
            // Weapons
            for (int i = ObjectConstants.inventoryWeaponListStartIndex; i < Inventory.Instance.Weapons.Count; i++)
            {
                Rectangle sourceRec = getFrameForWeapon(Inventory.Instance.Weapons[i]);
                // Center weapon on inventory slot
                Vector2 weaponSlot = backdropLocation + ObjectConstants.weaponFromBackdropLocation + ObjectConstants.inventorySlotLocations[i]
                    + new Vector2((ObjectConstants.inventorySlotWidthHeight - sourceRec.X) / ObjectConstants.halveOpDenom,
                    (ObjectConstants.inventorySlotWidthHeight - sourceRec.Y) / ObjectConstants.halveOpDenom);
                itemSprites.Add(InventorySpriteFactory.Instance.CreateWeaponSprite(sourceRec), weaponSlot);
            }
            // Map and compass
            if (Inventory.Instance.Map)
            {
                itemSprites.Add(InventorySpriteFactory.Instance.CreateMapSprite(), backdropLocation + ObjectConstants.mapFromBackdropLocation);
            }
            if (Inventory.Instance.Compass)
            {
                itemSprites.Add(InventorySpriteFactory.Instance.CreateCompassSprite(), backdropLocation + ObjectConstants.compassFromBackdropLocation);
            }
            // Selected weapon
            selectedWeaponSprite = InventorySpriteFactory.Instance.CreateWeaponSprite(getFrameForWeapon(Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex]));
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
