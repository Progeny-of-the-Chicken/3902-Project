﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.InventorySprites;

namespace Sprint_0.Scripts.GameState.InventoryState
{
    public class InventorySpriteFactory
    {
        private Texture2D texture;

        private static InventorySpriteFactory instance = new InventorySpriteFactory();

        public static InventorySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private InventorySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(ObjectConstants.inventorySpritesheetFileName);
        }

        public ISprite CreateWeaponBackdropSprite()
        {
            return new WeaponBackdropSprite(texture);
        }

        public ISprite CreateMapBackdropSprite()
        {
            return new MapBackdropSprite(texture);
        }

        public ISprite CreateHUDBackdropSprite()
        {
            return new HUDBackdropSprite(texture);
        }

        public ISprite CreateCoverSprite(Rectangle destRec)
        {
            return new CoverSprite(texture, destRec);
        }

        public ISprite CreateSelectionSprite()
        {
            return new SelectionSprite(texture);
        }

        public ISprite CreateWeaponSprite(Rectangle sourceRec)
        {
            return new WeaponSprite(texture, sourceRec);
        }

        public ISprite CreateMapSprite()
        {
            return new MapSprite(texture);
        }

        public ISprite CreateCompassSprite()
        {
            return new CompassSprite(texture);
        }

        public ISprite CreateFullHeartSprite()
        {
            return new FullHeartSprite(texture);
        }
        public ISprite CreateHalfHeartSprite()
        {
            return new HalfHeartSprite(texture);
        }
        public ISprite CreateEmptyHeartSprite()
        {
            return new EmptyHeartSprite(texture);
        }
        public ISprite CreateBlackHUDCoverSprite()
        {
            return new BlackHUDCoverSprite(texture);
        }

        public ISprite CreateWhiteSwordSprite()
        {
            return new WhiteSwordSprite(texture);
        }

        public ISprite CreateEmptyMapSprite()
        {
            return new EmptyMapSprite(texture);
        }

        public ISprite CreateRoomMapSprite()
        {
            return new RoomMapSprite(texture);
        }

        public ISprite CreateLevelNumberSprite()
        {
            return new LevelNumberSprite(texture);
        }

        public ISprite CreateCurrentRoomMapMarkerSprite()
        {
            return new CurrentRoomMapMarkerSprite(texture);
        }

        public ISprite CreateTreasureRoomMapMarkerSprite()
        {
            return new TreasureRoomMapMarkerSprite(texture);
        }
    }
}
