using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Sets
{
    class EnemySet
    {
        public HashSet<IEnemy> Enemies { get => enemies; }
        HashSet<IEnemy> enemies;
        HashSet<IEnemy> toBeRemoved;
        DropItemCommand itemDropper;

        public EnemySet()
        {
            enemies = new HashSet<IEnemy>();
            toBeRemoved = new HashSet<IEnemy>();
            itemDropper = new DropItemCommand();
        }

        public void Add(IEnemy enemy)
        {
            enemies.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update(gameTime);
                if (enemy.CheckDelete())
                {
                    toBeRemoved.Add(enemy);
                }
            }
            foreach (IEnemy enemy in toBeRemoved)
            {
                itemDropper.Execute(enemy);
                enemies.Remove(enemy);
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
