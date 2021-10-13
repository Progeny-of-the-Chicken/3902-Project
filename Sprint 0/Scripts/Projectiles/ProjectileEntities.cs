using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Projectiles
{
    public class ProjectileEntities
    {
        private Game1 game;
        public HashSet<IProjectile> projectiles;

        public ProjectileEntities(Game1 game)
        {
            this.game = game;
            projectiles = new HashSet<IProjectile>();
        }

        public void Update(GameTime gameTime)
        {
            HashSet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Update(gameTime);
                if (projectile.CheckDelete())
                {
                    projectilesToRemove.Add(projectile);
                }

            }
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }
    }
}
