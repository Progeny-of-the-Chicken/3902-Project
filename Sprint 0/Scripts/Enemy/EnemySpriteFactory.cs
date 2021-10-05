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
        Texture2D enemySprites;
		Texture2D npcSprites;
		Texture2D bossSprites;

		private static EnemySpriteFactory instance = new EnemySpriteFactory();
		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		} 

		Rectangle StalfosRectangle = new Rectangle(1, 59, 16, 16);
		Rectangle OldManRectangle = new Rectangle(1, 11, 16, 16);
		Rectangle[] GelFrames = { new Rectangle(1, 15, 8, 9), new Rectangle(10, 15, 8, 9) };
		Rectangle[] ZolFrames = { new Rectangle(78, 11, 14, 16), new Rectangle(95, 11, 14, 16) };
		Rectangle[] AquamentusMoveFrames = { new Rectangle(51, 11, 24, 31), new Rectangle(76, 11, 24, 31) };
		Rectangle[] AquamentusShootFrames = { new Rectangle(1, 11, 24, 31), new Rectangle(26, 11, 24, 31) };
		Rectangle[] MagicProjectileFrames = { new Rectangle(101, 14, 8, 10), new Rectangle(110, 14, 8, 10),
											  new Rectangle(119, 14, 8, 10), new Rectangle(128, 14, 8, 10) };
        Rectangle[] KeeseFrames = { new Rectangle(200, 14, 16, 12), new Rectangle(183, 14, 18, 10) };
		Rectangle GoriyaFrontFrame = new Rectangle(222, 10, 15, 17);
		Rectangle GoriyaBackFrame = new Rectangle(240, 10, 14, 17);
		Rectangle[] GoriyaRightFrames = { new Rectangle(256, 10, 14, 17), new Rectangle(274, 11, 16, 16 ) };
		Rectangle BoomerangFrames = new Rectangle(290, 14, 7, 10);



		private EnemySpriteFactory()
		{

		}

		public void LoadAllTextures(ContentManager content)
        {
			enemySprites = content.Load<Texture2D>("enemies");
			npcSprites = content.Load<Texture2D>("npc");
			bossSprites = content.Load<Texture2D>("bosses");
		}

		public ISprite CreateStalfosSprite(float scale)
		{
			return new StalfosSprite(StalfosRectangle, scale, enemySprites);
		}

		public ISprite CreateOldManSprite(float scale)
        {
			return new OldManSprite(OldManRectangle, scale, npcSprites);
        }
		public ISprite CreateGelSprite(float scale)
        {
			return new GelSprite(GelFrames, scale, enemySprites);
        }
		public ISprite CreateZolSprite(float scale)
        {
			return new ZolSprite(ZolFrames, scale, enemySprites);
        }
		public ISprite CreateAquamentusMoveSprite(float scale)
        {
			return new AquamentusMoveSprite(AquamentusMoveFrames, scale, bossSprites);
        }
		public ISprite CreateAquamentusShootSprite(float scale)
		{
			return new AquamentusShootSprite(AquamentusShootFrames, scale, bossSprites);
		}
		public ISprite CreateKeeseSprite(float scale)
        {
			return new KeeseSprite(KeeseFrames, scale, enemySprites);
        }
		public ISprite CreateMagicProjectileSprite(float scale)
		{
			return new MagicProjectileSprite(MagicProjectileFrames, scale, bossSprites);
		}
		public ISprite CreateFrontGoriyaSprite(float scale)
        {
			return new GoriyaFrontSprite(GoriyaFrontFrame, scale, enemySprites);
        }
		public ISprite CreateBackGoriyaSprite(float scale)
        {
			return new GoriyaBackSprite(GoriyaBackFrame, scale, enemySprites);
        }
		public ISprite CreateRightGoriyaSprite(float scale)
		{
			return new GoriyaRightSprite(GoriyaRightFrames, scale, enemySprites);
		}
		public ISprite CreateLeftGoriyaSprite(float scale)
		{
			return new GoriyaLeftSprite(GoriyaRightFrames, scale, enemySprites);
		}
	}
}
