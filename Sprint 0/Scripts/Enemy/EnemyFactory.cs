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

		public IEnemy CreateStalfos(Vector2 location)
		{
			return new Stalfos(location);
		}
		public IEnemy CreateOldMan(Vector2 location)
        {
			return new OldMan(location);
        }
		public IEnemy CreateGel(Vector2 location)
		{
			return new Gel(location);
		}
		public IEnemy CreateZol(Vector2 location)
        {
			return new Zol(location);
        }
		public IEnemy CreateAquamentus(Vector2 location)
        {
			return new Aquamentus(location);
        }
		public IEnemy CreateMagicProjectile()
        {
			return new MagicProjectile();
        }
		public IEnemy CreateAquamentusProjectile()
        {
			return new AquamentusProjectile();
        }
		public IEnemy CreateKeese(Vector2 location)
        {
			return new Keese(location);
        }
		public IEnemy CreateGoriya(Vector2 location)
        {
			return new Goriya(location);
        }
	}
}
