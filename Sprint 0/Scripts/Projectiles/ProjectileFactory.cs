using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;

namespace Sprint_0.Scripts.Projectiles
{
    public class ProjectileFactory
    {
        private static ProjectileFactory instance = new ProjectileFactory();

        public static ProjectileFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileFactory()
        {
        }

        public IProjectile CreateArrow(Vector2 location, FacingDirection direction, bool silver)
        {
            return new Arrow(location, direction, silver);
        }

        public IProjectile CreateBoomerang(Vector2 location, FacingDirection direction, bool magical)
        {
            return new Boomerang(location, direction, magical);
        }

        public IProjectile CreateBomb(Vector2 location, FacingDirection direction)
        {
            return new Bomb(location, direction);
        }

        public IProjectile CreateFireSpell(Vector2 location, FacingDirection direction)
        {
            return new FireSpell(location, direction);
        }

        public List<IProjectile> CreateThreeMagicProjectiles(Vector2 location, FacingDirection mainDirection)
        {
            return new List<IProjectile>{
                new MagicProjectile(location, mainDirection, FacingDirection.Up),
                new MagicProjectile(location, mainDirection, mainDirection),
                new MagicProjectile(location, mainDirection, FacingDirection.Down)
            };
        }
    }
}
