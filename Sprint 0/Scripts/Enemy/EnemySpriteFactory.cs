using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.ProjectileSprites;
using Sprint_0.Scripts.Sprite.EnemySprites;
using Sprint_0.Scripts.Sprites.EnemySprites;

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

		public ISprite CreateStalfosSprite(Rectangle frame)
		{
			return new UnanimatedFlipSprite(frame, enemySprites);
		}

		public ISprite CreateOldManSprite(Rectangle frame)
        {
			return new GenericUnanimatedEnemySprite(frame, npcSprites);
        }
		public ISprite CreateGelSprite(Rectangle[] frames)
        {
			return new GenericEnemySprite(frames, enemySprites);
        }
		public ISprite CreateZolSprite(Rectangle[] frames)
        {
			return new GenericEnemySprite(frames, enemySprites);
        }
		public ISprite CreateAquamentusMoveSprite(Rectangle[] frames)
        {
			return new GenericEnemySprite(frames, bossSprites);
        }
		public ISprite CreateAquamentusShootSprite(Rectangle[] frames)
		{
			return new GenericEnemySprite(frames, bossSprites);
		}
		public ISprite CreateKeeseSprite(Rectangle[] frames)
        {
			return new GenericEnemySprite(frames, enemySprites);
        }
		public ISprite CreateMagicProjectileSprite()
		{
			return new MagicProjectileSprite(MagicProjectileFrames, ObjectConstants.scale, bossSprites);
		}
		public ISprite CreateFrontGoriyaSprite(Rectangle frame)
        {
			return new AnimatedFlipSprite(frame, enemySprites);
        }
		public ISprite CreateBackGoriyaSprite(Rectangle frame)
        {
			return new AnimatedFlipSprite(frame, enemySprites);
        }
		public ISprite CreateRightGoriyaSprite(Rectangle[] frames)
		{
			return new GoriyaRightSprite(frames, enemySprites);
		}
		public ISprite CreateLeftGoriyaSprite(Rectangle[] frames)
		{
			return new GoriyaLeftSprite(frames, enemySprites);
		}
	}
}
