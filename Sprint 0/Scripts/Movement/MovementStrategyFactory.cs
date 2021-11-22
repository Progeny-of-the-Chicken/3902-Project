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

        public IMovementStrategy CreateIdleStrategy()
        {
            return new IdleStrategy();
        }

        public IMovementStrategy CreateKnockbackStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.DefaultEnemyKnockbackSpeed, ObjectConstants.zeroPauseTime);
        }
    }
}
