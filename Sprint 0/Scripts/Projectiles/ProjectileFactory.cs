using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

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

        public IProjectile CreateLinkBasicBoomerang(Vector2 location, FacingDirection direction, Link link)
        {
            return new Boomerang(location, direction, false, link);
        }

        public IProjectile CreateLinkMagicalBoomerang(Vector2 location, FacingDirection direction, Link link)
        {
            return new Boomerang(location, direction, true, link);
        }

        public IProjectile CreateEnemyBoomerang(Vector2 location, FacingDirection direction, IEnemy enemy)
        {
            return new Boomerang(location, direction, false, enemy);
        }

        public IProjectile CreateBomb(Vector2 location, FacingDirection direction)
        {
            return new Bomb(location, direction);
        }

        public IProjectile CreateBlastZone(Vector2 location)
        {
            return new BlastZone(location);
        }

        public IProjectile CreateFireSpell(Vector2 location, FacingDirection direction)
        {
            return new FireSpell(location, direction);
        }

        public IProjectile CreateMagicProjectile(Vector2 location, Vector2 directionVector)
        {
            return new MagicProjectile(location, directionVector);
        }

        public List<IProjectile> CreateThreeMagicProjectiles(Vector2 location, FacingDirection mainDirection)
        {
            return new List<IProjectile>{
                new MagicProjectile(location, new Vector2(0, 0)),
                new MagicProjectile(location, new Vector2(0, 0)),
                new MagicProjectile(location, new Vector2(0, 0))
            };
        }

        public IProjectile CreateSwordAttackHitbox(Vector2 location, FacingDirection direction)
        {
            return new SwordAttackHitbox(location, direction);
        }

        public IProjectile CreateSwordBeam(Vector2 location, FacingDirection direction)
        {
            return new SwordBeam(location, direction);
        }

        public IProjectile CreateShotgunPellet(Vector2 spawnLoc, FacingDirection direction)
        {
            return new ShotgunPelletProjectile(spawnLoc, direction);
        }
    }
}
