using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;

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

        // Effects

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

        // Enemies

        public IEnemy CreateGelFromZol(Vector2 location)
        {
            IEnemy enemy = EnemyFactory.Instance.CreateGel(location);
            room.AddEnemy(enemy);
            return enemy;
        }

        public IEnemy CreateStalfosFromMegaStalfos(Vector2 location)
        {
            IEnemy enemy = EnemyFactory.Instance.CreateStalfos(location);
            room.AddEnemy(enemy);
            return enemy;
        }

        public IEnemy CreateZolFromMegaGel(Vector2 location)
        {
            IEnemy enemy = EnemyFactory.Instance.CreateZol(location);
            room.AddEnemy(enemy);
            return enemy;
        }

        public IEnemy CreateMegaGelFromMegaZol(Vector2 location)
        {
            IEnemy enemy = EnemyFactory.Instance.CreateMegaGel(location);
            room.AddEnemy(enemy);
            return enemy;
        }

        public IEnemy CreatePatraMinion(Vector2 location, IEnemy patra)
        {
            IEnemy patraMinion = EnemyFactory.Instance.CreatePatraMinion(location, patra);
            room.AddEnemy(patraMinion);
            return patraMinion;
        }

        // Items

        public void CreateItemDrop(Vector2 location, Vector2 spawnerDimensions, ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.SmallHeartItem:
                    room.AddItem(ItemFactory.Instance.CreateSmallHeartItem(location, spawnerDimensions));
                    break;
                case ItemType.YellowRuby:
                    room.AddItem(ItemFactory.Instance.CreateYellowRuby(location, spawnerDimensions));
                    break;
                case ItemType.BlueRuby:
                    room.AddItem(ItemFactory.Instance.CreateBlueRuby(location, spawnerDimensions));
                    break;
                case ItemType.Fairy:
                    room.AddItem(ItemFactory.Instance.CreateFairy(location, spawnerDimensions));
                    break;
                case ItemType.BombItem:
                    room.AddItem(ItemFactory.Instance.CreateBombItem(location, spawnerDimensions));
                    break;
                case ItemType.Clock:
                    room.AddItem(ItemFactory.Instance.CreateClock(location, spawnerDimensions));
                    break;
                default:
                    // Should never happen
                    room.AddItem(ItemFactory.Instance.CreateSmallHeartItem(location, spawnerDimensions));
                    break;
            }
        }
    }
}
