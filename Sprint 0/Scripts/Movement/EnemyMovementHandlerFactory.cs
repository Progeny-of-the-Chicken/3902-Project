using System.Collections.Generic;
using Microsoft.Xna.Framework;

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

        public EnemyMovementHandler CreateStalfosEnemyHandler(IMovementStrategy movementStrategy)
        {
            return new EnemyMovementHandler(movementStrategy, (float)ObjectConstants.StalfosMoveTime, CardinalVectors);
        }

        public EnemyMovementHandler CreateGelMovementHandler(IMovementStrategy movementStrategy)
        {
            return new EnemyMovementHandler(movementStrategy, (float)ObjectConstants.GelMoveTime, CardinalVectors);
        }

        public EnemyMovementHandler CreateZolMovementHandler(IMovementStrategy movementStrategy)
        {
            return new EnemyMovementHandler(movementStrategy, (float)ObjectConstants.ZolMoveTime, CardinalVectors);
        }
    }
}
