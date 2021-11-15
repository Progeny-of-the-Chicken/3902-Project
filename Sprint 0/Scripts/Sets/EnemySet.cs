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
        HashSet<IEnemy> toBeAdded;

        public EnemySet()
        {
            enemies = new HashSet<IEnemy>();
            toBeRemoved = new HashSet<IEnemy>();
            toBeAdded = new HashSet<IEnemy>();
        }

        public void Add(IEnemy enemy)
        {
            toBeAdded.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            foreach(IEnemy enemy in toBeAdded)
            {
                enemies.Add(enemy);
            }
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
            }
            toBeAdded.Clear();
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
