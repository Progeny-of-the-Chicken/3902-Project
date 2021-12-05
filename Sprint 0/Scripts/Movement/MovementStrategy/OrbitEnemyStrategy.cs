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

        private Vector2 orbitCenter;
        private bool beginEllipse = true;
        private double ellipseYOffset;
        private double radiusTime = ObjectConstants.zero_double;
        private double xSatellite = ObjectConstants.zero_double;
        private double ySatellite = ObjectConstants.zero_double;
        private double radiusRatio = ObjectConstants.oneSecond_double;

        public OrbitEnemyStrategy(IEnemy enemy, double orbitSpeedRadians, int radius, double radiusChange, Vector2 satelliteDimensions)
        {
            this.enemy = enemy;
            this.orbitSpeedRadians = orbitSpeedRadians;
            this.radius = radius;
            this.radiusChange = radiusChange;
            this.satelliteDimensions = satelliteDimensions;

            if (((Patra)enemy).orbitState.ellipse)
            {
                radiusRatio = ObjectConstants.PatraMinionEllipseRadiusRatio;
            }
        }

        public Vector2 Move(GameTime gt, Vector2 location)
        {
            radiusTime += gt.ElapsedGameTime.TotalSeconds;
            int adjustedRadius = radius + (int)(radiusTime * radiusChange);
            UpdateOrbitCenter(location, adjustedRadius);
            double radiansToMove = (GetCurrentRadians(location) + (gt.ElapsedGameTime.TotalSeconds * orbitSpeedRadians)) % ObjectConstants.degreeRotationCW360_s;
            UpdateSatelliteCoords(adjustedRadius, radiansToMove);
            return orbitCenter + new Vector2((int)xSatellite, (int)ySatellite);
        }

        //----- Math helpers -----//

        private double GetCurrentRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2((satelliteLocation.Y - orbitCenter.Y) / radiusRatio, (satelliteLocation.X - orbitCenter.X));
        }

        private Vector2 GetEnemyCenter(Vector2 satelliteWidthHeight)
        {
            return SpawnHelper.Instance.CenterLocationOnSpawner(enemy.Position, enemy.Collider.Hitbox.Size.ToVector2(), satelliteWidthHeight);
        }

        //----- Helpers for orbit center -----//

        private void UpdateOrbitCenter(Vector2 satelliteLocation, int adjustedRadius)
        {
            orbitCenter = GetEnemyCenter(satelliteDimensions);
            if (((Patra)enemy).orbitState.ellipse)
            {
                if (beginEllipse)
                {
                    InitYOffsetForRadians(GetCurrentRadians(satelliteLocation), adjustedRadius);
                    beginEllipse = false;
                }
                double adjustedYOffset = ellipseYOffset + ((ellipseYOffset / adjustedRadius) * (radiusTime * radiusChange));
                orbitCenter += new Vector2(ObjectConstants.zero, (int)adjustedYOffset);
            }
        }

        private void InitYOffsetForRadians(double currentRadians, int adjustedRadius)
        {
            if (currentRadians < ObjectConstants.degreeRotationCW90_s)
            {
                ellipseYOffset = (adjustedRadius / Math.PI) * currentRadians;
            }
            else if (currentRadians < ObjectConstants.degreeRotationCW270_s)
            {
                ellipseYOffset = adjustedRadius - ((adjustedRadius / Math.PI) * currentRadians);
            }
            else
            {
                ellipseYOffset = (adjustedRadius / Math.PI) * currentRadians - (2 * adjustedRadius);
            }
        }

        private void UpdateSatelliteCoords(int adjustedRadius, double radiansToMove)
        {
            xSatellite = adjustedRadius * Math.Cos(radiansToMove);
            ySatellite = adjustedRadius * Math.Sin(radiansToMove) * radiusRatio;
        }
    }
}
