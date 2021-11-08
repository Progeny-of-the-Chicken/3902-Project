using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Sets
{
    class EnemySet
    {
        public HashSet<IEnemy> Enemies { get => enemies; }
        HashSet<IEnemy> enemies;
        HashSet<IEnemy> toBeRemoved;

        public EnemySet()
        {
            enemies = new HashSet<IEnemy>();
            toBeRemoved = new HashSet<IEnemy>();
        }

        public void Add(IEnemy enemy)
        {
            enemies.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            foreach(IEnemy enemy in enemies)
            {
                enemy.Update(gameTime);
                if (enemy.CheckDelete())
                {
                    toBeRemoved.Add(enemy);
                }
            }
            foreach(IEnemy enemy in toBeRemoved)
            {
                enemies.Remove(enemy);
                SFXManager.Instance.PlayEnemyDeath();
            }
            toBeRemoved.Clear();
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(sb);
            }
        }
    }
}
