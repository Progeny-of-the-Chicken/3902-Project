using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class OrbitEnemyStrategy : IMovementStrategy
    {
        private IEnemy enemy;
        private double orbitSpeedRadians;
        private int radius;
        private double radiusChange;
        private Vector2 satelliteDimensions;

        public OrbitEnemyStrategy(IEnemy enemy, double orbitSpeedRadians, int radius, double radiusChange, Vector2 satelliteDimensions)
        {
            this.enemy = enemy;
            this.orbitSpeedRadians = orbitSpeedRadians;
            this.radius = radius;
            this.radiusChange = radiusChange;
            this.satelliteDimensions = satelliteDimensions;
        }

        public Vector2 Move(GameTime gt, Vector2 location)
        {
            radius += (int)(gt.ElapsedGameTime.TotalSeconds * radiusChange);
            double radiansToMove = GetCurrentRadians(location) + (gt.ElapsedGameTime.TotalSeconds * orbitSpeedRadians);
            Vector2 center = GetEnemyCenter(satelliteDimensions);
            Vector2 offset = new Vector2((int)(radius * Math.Cos(radiansToMove)), (int)(radius * Math.Sin(radiansToMove)));
            return center + offset;
        }

        //----- Math helpers -----//

        private double GetCurrentRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2((satelliteLocation.Y - GetEnemyCenter(satelliteDimensions).Y), (satelliteLocation.X - GetEnemyCenter(satelliteDimensions).X));
        }

        private Vector2 GetEnemyCenter(Vector2 satelliteWidthHeight)
        {
            return SpawnHelper.Instance.CenterLocationOnSpawner(enemy.Position, enemy.Collider.Hitbox.Size.ToVector2(), satelliteWidthHeight);
        }
    }
}
