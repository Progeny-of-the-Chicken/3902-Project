using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.MainMenuSprites;

namespace Sprint_0.Scripts.GameState.MainMenuState
{
    public class MainMenuSpriteFactory
    {
        private Texture2D texture;

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
        }

        public ISprite CreateBackgroundSprite()
        {
            return new BackgroundSprite(texture);
        }
        public ISprite CreateSelectionSprite()
        {
            return new SelectionSprite(texture);
        }
    }
}
