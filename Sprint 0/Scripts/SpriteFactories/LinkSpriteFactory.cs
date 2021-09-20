using Microsoft.Xna.Framework;
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
	}
}
