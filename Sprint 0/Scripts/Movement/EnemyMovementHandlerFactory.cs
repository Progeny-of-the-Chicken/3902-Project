using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Movement
{
    public class EnemyMovementHandlerFactory
    {
        private List<Vector2> FlyVectors;
        private List<Vector2> CardinalVectors;
        private List<Vector2> HorizontalVectors;
        private List<Vector2> IdleVectors;
        
        private static EnemyMovementHandlerFactory instance = new EnemyMovementHandlerFactory();

        public static EnemyMovementHandlerFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyMovementHandlerFactory()
        {
            FlyVectors = new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.UpRightUnitVector,
                ObjectConstants.UpUnitVector,
                ObjectConstants.UpLeftUnitVector,
                ObjectConstants.LeftUnitVector,
                ObjectConstants.DownLeftUnitVector,
                ObjectConstants.DownUnitVector,
                ObjectConstants.DownRightUnitVector,
                ObjectConstants.zeroVector
            };
            CardinalVectors = new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.UpUnitVector,
                ObjectConstants.LeftUnitVector,
                ObjectConstants.DownUnitVector,
            };
            HorizontalVectors = new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.LeftUnitVector
            };
            IdleVectors = new List<Vector2>
            {
                ObjectConstants.zeroVector
            };
        }

        public EnemyMovementHandler CreateMovementHandlerForEnemy(Vector2 location, EnemyType type)
        {
            return type switch
            {
                EnemyType.Stalfos => new EnemyMovementHandler((float)ObjectConstants.StalfosMoveTime, location, CardinalVectors, type),
                EnemyType.Gel => new EnemyMovementHandler((float)ObjectConstants.GelMoveTime, location, CardinalVectors, type),
                EnemyType.Zol => new EnemyMovementHandler((float)ObjectConstants.ZolMoveTime, location, CardinalVectors, type),
                EnemyType.Aquamentus => new EnemyMovementHandler((float)ObjectConstants.DefaultEnemyMoveTime, location, HorizontalVectors, type),
                // Default only happens upon missing enemy movement handler implementation
                _ => null
            };
        }
    }
}
