using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.InventorySprites;

namespace Sprint_0.Scripts.GameState.Inventory
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
    }
}
