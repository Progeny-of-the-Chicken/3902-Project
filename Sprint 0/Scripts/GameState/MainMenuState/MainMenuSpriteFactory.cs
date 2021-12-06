using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.MainMenuSprites;

namespace Sprint_0.Scripts.GameState.MainMenuState
{
    public class MainMenuSpriteFactory
    {
        private Texture2D texture;
        private Texture2D texture2;

        private static MainMenuSpriteFactory instance = new MainMenuSpriteFactory();

        public static MainMenuSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MainMenuSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(ObjectConstants.mainMenuSpritesheetFileName);
            texture2 = content.Load<Texture2D>(ObjectConstants.inventorySpritesheetFileName);
        }

        public ISprite CreateBackgroundSprite()
        {
            return new BackgroundSprite(texture);
        }
        public ISprite CreateSelectionSprite()
        {
            return new CurrentSelectionSprite(texture2);
        }

        public ISprite CreateCurrentSettingsSprite()
        {
            return new CurrentSettingsSprite(texture2);
        }
    }
}
