using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.ProjectileSprites;

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

		Rectangle[] MagicProjectileFrames = { new Rectangle(101, 14, 8, 10), new Rectangle(110, 14, 8, 10),
											  new Rectangle(119, 14, 8, 10), new Rectangle(128, 14, 8, 10) };


		private EnemySpriteFactory()
		{

		}

		public void LoadAllTextures(ContentManager content)
        {
			enemySprites = content.Load<Texture2D>("enemies");
			npcSprites = content.Load<Texture2D>("npc");
			bossSprites = content.Load<Texture2D>("bosses");
		}

		public ISprite CreateStalfosSprite(float scale, Rectangle frame)
		{
			return new StalfosSprite(frame, scale, enemySprites);
		}

		public ISprite CreateOldManSprite(float scale, Rectangle frame)
        {
			return new OldManSprite(frame, scale, npcSprites);
        }
		public ISprite CreateGelSprite(float scale, Rectangle[] frames)
        {
			return new GelSprite(frames, scale, enemySprites);
        }
		public ISprite CreateZolSprite(float scale, Rectangle[] frames)
        {
			return new ZolSprite(frames, scale, enemySprites);
        }
		public ISprite CreateAquamentusMoveSprite(float scale, Rectangle[] frames)
        {
			return new AquamentusMoveSprite(frames, scale, bossSprites);
        }
		public ISprite CreateAquamentusShootSprite(float scale, Rectangle[] frames)
		{
			return new AquamentusShootSprite(frames, scale, bossSprites);
		}
		public ISprite CreateKeeseSprite(float scale, Rectangle[] frames)
        {
			return new KeeseSprite(frames, scale, enemySprites);
        }
		public ISprite CreateMagicProjectileSprite(float scale)
		{
			return new MagicProjectileSprite(MagicProjectileFrames, scale, bossSprites);
		}
		public ISprite CreateFrontGoriyaSprite(float scale, Rectangle frame)
        {
			return new GoriyaFrontSprite(frame, scale, enemySprites);
        }
		public ISprite CreateBackGoriyaSprite(float scale, Rectangle frame)
        {
			return new GoriyaBackSprite(frame, scale, enemySprites);
        }
		public ISprite CreateRightGoriyaSprite(float scale, Rectangle[] frames)
		{
			return new GoriyaRightSprite(frames, scale, enemySprites);
		}
		public ISprite CreateLeftGoriyaSprite(float scale, Rectangle[] frames)
		{
			return new GoriyaLeftSprite(frames, scale, enemySprites);
		}
	}
}
