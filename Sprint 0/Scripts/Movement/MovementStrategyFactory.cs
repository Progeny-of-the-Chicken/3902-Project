using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement.MovementStrategy;

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

        public IMovementStrategy CreateKnockbackStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.DefaultEnemyKnockbackSpeed, ObjectConstants.zeroPauseTime);
        }

        public IMovementStrategy CreateFreezeStrategy()
        {
            return new IdleStrategy();
        }

        public IMovementStrategy CreateZolMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.ZolMoveSpeed, (float)ObjectConstants.ZolPauseTime);
        }

        public IMovementStrategy CreateGelMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.GelMoveSpeed, (float)ObjectConstants.GelPauseTime);
        }
    }
}
