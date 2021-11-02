using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Effect;

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

        public IProjectile CreateBoomerangFromEnemy(Vector2 location, FacingDirection direction)
        {
            IProjectile projectile = ProjectileFactory.Instance.CreateEnemyBoomerang(location, direction);
            room.AddProjectile(projectile);
            return projectile;
        }

        public List<IProjectile> CreateThreeMagicProjectilesFromEnemy(Vector2 location, FacingDirection direction)
        {
            List<IProjectile> projectiles = ProjectileFactory.Instance.CreateThreeMagicProjectiles(location, direction);
            foreach (IProjectile projectile in projectiles)
            {
                room.AddProjectile(projectile);
            }
            return projectiles;
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

        public void CreatePopEffect(Vector2 location, EffectType type)
        {
            room.AddEffect(new Effect.Effect(location, type));
        }
    }
}
