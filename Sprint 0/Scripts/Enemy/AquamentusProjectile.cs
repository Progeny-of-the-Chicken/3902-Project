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

        public AquamentusProjectile()
        {
            topProjectile = (MagicProjectile) EnemyFactory.Instance.CreateMagicProjectile();
            middleProjectile = (MagicProjectile)EnemyFactory.Instance.CreateMagicProjectile();
            bottomProjectile = (MagicProjectile)EnemyFactory.Instance.CreateMagicProjectile();
        }
        public void Fire(Vector2 location)
        {
            topProjectile.Fire(location, new Vector2(-1, -0.5f));
            middleProjectile.Fire(location, new Vector2(-1, 0));
            bottomProjectile.Fire(location, new Vector2(-1, 0.5f));
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
