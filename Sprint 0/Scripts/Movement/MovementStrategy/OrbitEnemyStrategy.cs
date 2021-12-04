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

        private double radiusTime = ObjectConstants.zero_float;

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
            radiusTime += gt.ElapsedGameTime.TotalSeconds;
            int adjustedRadius = radius + (int)(radiusTime * radiusChange);
            double radiansToMove = (GetCurrentRadians(location) + (gt.ElapsedGameTime.TotalSeconds * orbitSpeedRadians)) % ObjectConstants.degreeRotationCW360_s;
            return GetEnemyCenter(satelliteDimensions) + new Vector2((int)(adjustedRadius * Math.Cos(radiansToMove)), (int)(adjustedRadius * Math.Sin(radiansToMove)));
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
