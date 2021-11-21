using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Terrain
{
    public class ObjectsFromObjectsFactory
    {
        private IRoom room;

        private static ObjectsFromObjectsFactory instance = new ObjectsFromObjectsFactory();

        public static ObjectsFromObjectsFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ObjectsFromObjectsFactory()
        {
        }

        public void LoadRoom(IRoom room)
        {
            this.room = room;
        }

        public void CreateBoomerangFromEnemy(Vector2 location, FacingDirection direction, IEnemy enemy)
        {
            room.AddProjectile(ProjectileFactory.Instance.CreateEnemyBoomerang(location, direction, enemy));
        }

        public void CreateThreeMagicProjectilesFromEnemy(Vector2 location, FacingDirection direction)
        {
            List<IProjectile> projectiles = ProjectileFactory.Instance.CreateThreeMagicProjectiles(location, direction);
            foreach (IProjectile projectile in projectiles)
            {
                room.AddProjectile(projectile);
            }
        }

        public IProjectile CreateBlastZoneFromBomb(Vector2 location)
        {
            IProjectile projectile = ProjectileFactory.Instance.CreateBlastZone(location);
            room.AddProjectile(projectile);
            return projectile;
        }

        public IProjectile CreateSwordAttackHitboxFromLink(Vector2 location, FacingDirection direction)
        {
            IProjectile projectile = ProjectileFactory.Instance.CreateSwordAttackHitbox(location, direction);
            room.AddProjectile(projectile);
            return projectile;
        }

        public void CreateStaticEffect(Vector2 location, EffectType type)
        {
            room.AddEffect(new Effect.StaticEffect(location, type));
        }

        public void CreateSwordBeamExplosion(Vector2 location)
        {
            foreach (IEffect effect in EffectFactory.Instance.CreateSwordBeamExplosion(location))
            {
                room.AddEffect(effect);
            }
        }
        public void CreateGelsFromZol(Vector2 location)
        {
            room.AddEnemy(EnemyFactory.Instance.CreateGel(location));
            room.AddEnemy(EnemyFactory.Instance.CreateGel(location));
        }
    }
}
