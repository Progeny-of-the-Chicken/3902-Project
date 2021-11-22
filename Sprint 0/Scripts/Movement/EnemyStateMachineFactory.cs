using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Movement
{
    public class EnemyStateMachineFactory
    {
        private List<Vector2> FlyVectors;
        private List<Vector2> CardinalVectors;
        private List<Vector2> HorizontalVectors;
        private List<Vector2> IdleVectors;
        
        private static EnemyStateMachineFactory instance = new EnemyStateMachineFactory();

        public static EnemyStateMachineFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyStateMachineFactory()
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

        public EnemyStateMachine CreateStateMachineForEnemy(Vector2 location, EnemyType type, float moveTime, int health)
        {
            return type switch
            {
                EnemyType.Stalfos => new EnemyStateMachine(location, type, moveTime, health, CardinalVectors),
                EnemyType.Gel => new EnemyStateMachine(location, type, moveTime, health, CardinalVectors),
                EnemyType.Zol => new EnemyStateMachine(location, type, moveTime, health, CardinalVectors),
                EnemyType.Aquamentus => new EnemyStateMachine(location, type, moveTime, health, HorizontalVectors),
                // Default only happens upon missing enemy movement handler implementation
                _ => null
            };
        }
    }
}
