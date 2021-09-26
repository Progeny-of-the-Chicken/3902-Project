using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint_0.Scripts.Enemy
{
    class EnemySpriteFactory
    {
        private Texture2D spriteSheet;

		private static EnemySpriteFactory instance = new EnemySpriteFactory();
		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		} 

		private Rectangle StalfosRectangle = new Rectangle(2, 59, 14, 15);
		private EnemySpriteFactory()
		{

		}

		public void LoadAllTextures(ContentManager content)
        {
			spriteSheet = content.Load<Texture2D>("enemies.png");
		}

		public ISprite CreateStalfos()
		{
			return new StalfosSprite(StalfosRectangle, 4, spriteSheet);
		}
	}
}
