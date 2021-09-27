using Sprint_0.Scripts.Sprite.LinkSprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private Texture2D spriteSheet;

		private static LinkSpriteFactory instance = new LinkSpriteFactory();

		public static LinkSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private LinkSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			spriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
		}

		public Texture2D GetSpriteSheet()
        {
			return spriteSheet;
        }

		public ISprite GetSpriteForState(LinkStateMachine linkState)
        {
			return new LinkMovingSprite(linkState);
        }
	}
}
