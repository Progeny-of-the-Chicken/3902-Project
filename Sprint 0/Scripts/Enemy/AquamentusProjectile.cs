using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint_0.Scripts.Enemy
{
    class AquamentusProjectile : IEnemy
    {
        MagicProjectile topProjectile;
        MagicProjectile middleProjectile;
        MagicProjectile bottomProjectile;

        public AquamentusProjectile(Vector2 location)
        {
            topProjectile = (MagicProjectile) EnemyFactory.Instance.CreateMagicProjectile(location, new Vector2(-1, -0.5f));
            middleProjectile = (MagicProjectile)EnemyFactory.Instance.CreateMagicProjectile(location, new Vector2(-1, 0));
            bottomProjectile = (MagicProjectile)EnemyFactory.Instance.CreateMagicProjectile(location, new Vector2(-1, 0.5f));
        }
        public void Update(GameTime gt)
        {
            topProjectile.Update(gt);
            middleProjectile.Update(gt);
            bottomProjectile.Update(gt);
        }
        public void Draw(SpriteBatch sb)
        {
            topProjectile.Draw(sb);
            middleProjectile.Draw(sb);
            bottomProjectile.Draw(sb);
        }
    }
}
