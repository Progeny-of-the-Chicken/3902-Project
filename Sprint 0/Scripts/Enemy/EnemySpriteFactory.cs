﻿using System;
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

		private Rectangle StalfosRectangle = new Rectangle(1, 59, 16, 16);
		private Rectangle OldManRectangle = new Rectangle(1, 11, 16, 16);
		private Rectangle[] GelFrames = { new Rectangle(1, 15, 8, 9), new Rectangle(10, 15, 8, 9) };
		private Rectangle[] ZolFrames = { new Rectangle(78, 11, 14, 16), new Rectangle(95, 11, 14, 16) };
		private Rectangle[] AquamentusMoveFrames = { new Rectangle(51, 11, 24, 31), new Rectangle(76, 11, 24, 31) };
		private Rectangle[] AquamentusShootFrames = { new Rectangle(1, 11, 24, 31), new Rectangle(26, 11, 24, 31) };
		private Rectangle[] MagicProjectileFrames = { new Rectangle(101, 14, 8, 10), new Rectangle(110, 14, 8, 10),
													  new Rectangle(119, 14, 8, 10), new Rectangle(128, 14, 8, 10) };
        private Rectangle[] KeeseFrames = {new Rectangle(183, 14, 18, 10), new Rectangle(200, 14, 16, 12)};
		private Rectangle GoriyaFrontFrame = new Rectangle(222, 10, 15, 17);
		private Rectangle GoriyaBackFrame = new Rectangle(240, 10, 14, 17);
		private Rectangle[] GoriyaRightFrames = { new Rectangle(256, 10, 14, 17), new Rectangle(274, 11, 16, 16 ) };
		private Rectangle BoomerangFrames = new Rectangle(290, 14, 7, 10);



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
		public ISprite CreateGelSprite()
        {
			return new GelSprite(GelFrames, 4, enemySprites);
        }
		public ISprite CreateZolSprite()
        {
			return new ZolSprite(ZolFrames, 4, enemySprites);
        }
		public ISprite CreateAquamentusMoveSprite()
        {
			return new AquamentusMoveSprite(AquamentusMoveFrames, 4, bossSprites);
        }
		public ISprite CreateAquamentusShootSprite()
		{
			return new AquamentusShootSprite(AquamentusShootFrames, 4, bossSprites);
		}
		public ISprite CreateKeeseSprite()
        {
			return new KeeseSprite(KeeseFrames, 4, enemySprites);
        }
		public ISprite CreateMagicProjectileSprite()
		{
			return new MagicProjectileSprite(MagicProjectileFrames, 3, bossSprites);
		}
		public ISprite CreateFrontGoriyaSprite()
        {
			return new GoriyaFrontSprite(GoriyaFrontFrame, 4, enemySprites);
        }
		public ISprite CreateBackGoriyaSprite()
        {
			return new GoriyaBackSprite(GoriyaBackFrame, 4, enemySprites);
        }
		public ISprite CreateRightGoriyaSprite()
		{
			return new GoriyaRightSprite(GoriyaRightFrames, 4, enemySprites);
		}
		public ISprite CreateLeftGoriyaSprite()
		{
			return new GoriyaLeftSprite(GoriyaRightFrames, 4, enemySprites);
		}

		public ISprite CreateBoomerangSprite()
        {
			return new BoomerangSprite(BoomerangFrames, 4, enemySprites);
        }
	}
}