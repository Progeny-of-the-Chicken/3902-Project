using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement.MovementStrategy;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Movement
{
    public class MovementStrategyFactory
    {
        private static MovementStrategyFactory instance = new MovementStrategyFactory();

        public static MovementStrategyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MovementStrategyFactory()
        {
        }

        public IMovementStrategy CreateMovementStrategyForEnemy(Vector2 directionVector, EnemyType type)
        {
            return type switch
            {
                EnemyType.Stalfos => CreateStalfosMovementStrategy(directionVector),
                EnemyType.Gel => CreateGelMovementStrategy(directionVector),
                EnemyType.Zol => CreateZolMovementStrategy(directionVector),
                _ => CreateFreezeStrategy()
            };
        }

        public IMovementStrategy CreateKnockbackStrategy(Vector2 directionVector, float knockbackSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, knockbackSpeed, ObjectConstants.zeroPauseTime);
        }

        public IMovementStrategy CreateFreezeStrategy()
        {
            return new IdleStrategy();
        }

        // TODO: Decide whether to make these private

        public IMovementStrategy CreateStalfosMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.StalfosMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        public IMovementStrategy CreateGelMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.GelMoveSpeed, (float)ObjectConstants.GelPauseTime);
        }

        public IMovementStrategy CreateZolMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.ZolMoveSpeed, (float)ObjectConstants.ZolPauseTime);
        }
    }
}
