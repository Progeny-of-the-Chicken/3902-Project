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

		public IEnemy CreateStalfos(Vector2 location, float scale)
		{
			return new Stalfos(location, scale);
		}
		public IEnemy CreateOldMan(Vector2 location, float scale)
        {
			return new OldMan(location, scale);
        }
		public IEnemy CreateGel(Vector2 location, float scale)
		{
			return new Gel(location, scale);
		}
		public IEnemy CreateZol(Vector2 location, float scale)
        {
			return new Zol(location, scale);
        }
		public IEnemy CreateAquamentus(Vector2 location, float scale)
        {
			return new Aquamentus(location, scale);
        }
		public IEnemy CreateKeese(Vector2 location, float scale)
        {
			return new Keese(location, scale);
        }
		public IEnemy CreateGoriya(Vector2 location, float scale)
        {
			return new Goriya(location, scale);
        }
		public IEnemy CreateWallmaster(Vector2 location, float scale)
        {
			return new Wallmaster(location, scale);
        }

		public IEnemy CreateSpikeTrap(Vector2 location, float scale)
        {
			return new SpikeTrap(location, scale);
        }
	}
}
