using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Sprint_0.Scripts.Enemy
{
    class EnemyFactory
    {
		private Texture2D spriteSheet;

		private static EnemyFactory instance = new EnemyFactory();

		public static EnemyFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemyFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			spriteSheet = content.Load<Texture2D>("enemy");
		}

		public IEnemy CreateStalfos()
		{
			return new Stalfos();
		}
	}
}
