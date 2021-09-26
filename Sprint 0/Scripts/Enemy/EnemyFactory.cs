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
	}
}
