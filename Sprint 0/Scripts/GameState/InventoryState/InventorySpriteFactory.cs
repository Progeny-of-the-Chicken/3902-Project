using Microsoft.Xna.Framework;
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

        public ISprite CreateDiscoveredRoomSprite(Rectangle sourceRec)
        {
            return new DiscoveredRoomSprite(texture, sourceRec);
        }
    }
}
