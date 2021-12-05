using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class EllipseEnemyStrategy : IMovementStrategy
    {
        private IEnemy enemy;
        private double orbitSpeedRadians;
        private int radius;
        private double radiusChange;
        private Vector2 satelliteDimensions;

        private Vector2 ellipseCenter;
        private bool beginEllipse = true;
        private double ellipseYOffset;
        private double radiusTime = ObjectConstants.zero_float;

        public EllipseEnemyStrategy(IEnemy enemy, double orbitSpeedRadians, int radius, double radiusChange, Vector2 satelliteDimensions)
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
            UpdateEllipseCenter(location, adjustedRadius);
            double radiansToMove = (GetEllipseRadians(location) + (gt.ElapsedGameTime.TotalSeconds * orbitSpeedRadians)) % ObjectConstants.degreeRotationCW360_s;
            return GetEnemyCenter(satelliteDimensions) + new Vector2((int)(adjustedRadius * Math.Cos(radiansToMove)), (int)((adjustedRadius / ObjectConstants.oneInTwo) * Math.Sin(radiansToMove)));
        }

        //----- Math helpers -----//

        private double GetEllipseRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2((satelliteLocation.Y - ellipseCenter.Y), (satelliteLocation.X - ellipseCenter.X));
        }

        private double GetCurrentRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2((satelliteLocation.Y - GetEnemyCenter(satelliteDimensions).Y), (satelliteLocation.X - GetEnemyCenter(satelliteDimensions).X));
        }

        private Vector2 GetEnemyCenter(Vector2 satelliteWidthHeight)
        {
            return SpawnHelper.Instance.CenterLocationOnSpawner(enemy.Position, enemy.Collider.Hitbox.Size.ToVector2(), satelliteWidthHeight);
        }

        //----- Ellipse helpers -----//

        private void UpdateEllipseCenter(Vector2 location, int radius)
        {
            if (beginEllipse)
            {
                InitYOffsetForRadians(GetCurrentRadians(location));
                beginEllipse = false;
            }
            ellipseYOffset += ((ellipseCenter.Y - GetEnemyCenter(satelliteDimensions).Y) / radius) * (int)(radiusTime * radiusChange);
            ellipseCenter = GetEnemyCenter(satelliteDimensions) + new Vector2(ObjectConstants.zero, (int)ellipseYOffset);
        }

        private void InitYOffsetForRadians(double currentRadians)
        {
            if (currentRadians < ObjectConstants.degreeRotationCW90_s)
            {
                ellipseYOffset = (radius / Math.PI) * currentRadians;
            }
            else if (currentRadians < ObjectConstants.degreeRotationCW270_s)
            {
                ellipseYOffset = radius - ((radius / Math.PI) * currentRadians);
            }
            else
            {
                ellipseYOffset = (radius / Math.PI) * ObjectConstants.degreeRotationCW360_s * currentRadians;
            }
        }
    }
}
