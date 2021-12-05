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
        private double radiusTime = ObjectConstants.zero_double;
        private double xOffset = ObjectConstants.zero_double;
        private double yOffset = ObjectConstants.zero_double;

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
            double radiansToMove = (GetScaledEllipseRadians(location) + (gt.ElapsedGameTime.TotalSeconds * orbitSpeedRadians)) % ObjectConstants.degreeRotationCW360_s;
            UpdateLocationOffsets(adjustedRadius, radiansToMove);
            return ellipseCenter + new Vector2((int)xOffset, (int)yOffset);
        }

        //----- Math helpers -----//

        private double GetScaledEllipseRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2((satelliteLocation.Y - ellipseCenter.Y) / ObjectConstants.PatraMinionEllipseRadiusRatio, (satelliteLocation.X - ellipseCenter.X));
        }

        private double GetScaledRadians(Vector2 satelliteLocation)
        {
            return Math.PI + Math.Atan2(((satelliteLocation.Y - GetEnemyCenter(satelliteDimensions).Y) / ObjectConstants.PatraMinionEllipseRadiusRatio), (satelliteLocation.X - GetEnemyCenter(satelliteDimensions).X));
        }

        private Vector2 GetEnemyCenter(Vector2 satelliteWidthHeight)
        {
            return SpawnHelper.Instance.CenterLocationOnSpawner(enemy.Position, enemy.Collider.Hitbox.Size.ToVector2(), satelliteWidthHeight);
        }

        //----- Ellipse helpers -----//

        private void UpdateEllipseCenter(Vector2 satelliteLocation, int adjustedRadius)
        {
            if (beginEllipse)
            {
                InitYOffsetForRadians(GetScaledRadians(satelliteLocation), adjustedRadius);
                beginEllipse = false;
            }
            double adjustedYOffset = ellipseYOffset + ((ellipseYOffset / adjustedRadius) * (radiusTime * radiusChange));
            ellipseCenter = GetEnemyCenter(satelliteDimensions) + new Vector2(ObjectConstants.zero, (int)adjustedYOffset);
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

        private void UpdateLocationOffsets(int adjustedRadius, double radiansToMove)
        {
            xOffset = adjustedRadius * Math.Cos(radiansToMove);
            yOffset = adjustedRadius * Math.Sin(radiansToMove) * ObjectConstants.PatraMinionEllipseRadiusRatio;
        }
    }
}
