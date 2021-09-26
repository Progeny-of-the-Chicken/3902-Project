using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class EnemySpriteFactory
    {
        private Texture2D enemySprites;
		private Texture2D npcSprites;
		private Texture2D bossSprites;

		private static EnemySpriteFactory instance = new EnemySpriteFactory();
		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		} 

		private Rectangle StalfosRectangle = new Rectangle(2, 59, 14, 15);
		private Rectangle OldManRectangle = new Rectangle(1, 11, 16, 15);
		private EnemySpriteFactory()
		{

		}

		public void LoadAllTextures(ContentManager content)
        {
			enemySprites = content.Load<Texture2D>("enemies.png");
			npcSprites = content.Load<Texture2D>("npc.png");
			bossSprites = content.Load<Texture2D>("bosses.png");
		}

		public ISprite CreateStalfosSprite()
		{
			return new StalfosSprite(StalfosRectangle, 4, enemySprites);
		}

		public ISprite CreateOldManSprite()
        {
			return new OldManSprite(OldManRectangle, 4, npcSprites);
        }
	}
}
