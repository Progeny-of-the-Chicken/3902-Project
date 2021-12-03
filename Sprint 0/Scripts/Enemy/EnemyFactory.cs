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
		public IEnemy CreateRope(Vector2 location)
        {
			return new Rope(location);
        }
		public IEnemy CreateDodongo(Vector2 location)
        {
			return new Dodongo(location);
        }
		public IEnemy CreateMerchant(Vector2 location)
        {
			return new Merchant(location);
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
		public IEnemy CreateKeese(Vector2 location)
        {
			return new Keese(location);
        }
		public IEnemy CreateGoriya(Vector2 location)
        {
			return new Goriya(location);
        }
		public IEnemy CreateSpikeTrap(Vector2 location)
        {
			return new SpikeTrap(location);
        }
		public IEnemy CreateWallMaster(Vector2 location)
        {
			return new Wallmaster(location);
        }
		public IEnemy CreatePatraMinion(Vector2 location)
        {
			return new PatraMinion(location);
        }
	}
}
