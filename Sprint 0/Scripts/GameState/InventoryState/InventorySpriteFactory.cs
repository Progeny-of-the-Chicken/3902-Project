using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public void LoadTextures(Texture2D texture)
        {
            this.texture = texture;
        }

        public ISprite CreateBackdropSprite()
        {
            return new BackdropSprite(texture);
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
    }
}
