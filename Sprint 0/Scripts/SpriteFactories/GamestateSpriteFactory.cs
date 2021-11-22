using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.InventorySprites;

namespace Sprint_0.Scripts.SpriteFactories
{
    public class GameStateSpriteFactory
    {
        private Texture2D texture;
        private static GameStateSpriteFactory instance = new GameStateSpriteFactory();

        public static GameStateSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private GameStateSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(ObjectConstants.inventorySpritesheetFileName);
        }

        public ISprite CreateBlackBackground()
        {
            return new BlackBackground(texture);
        }
    }
}
