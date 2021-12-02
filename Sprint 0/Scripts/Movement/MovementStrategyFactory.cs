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
                EnemyType.Keese => CreateKeeseMovementStrategy(directionVector),
                EnemyType.Goriya => CreateGoriyaMovementStrategy(directionVector),
                EnemyType.Gel => CreateGelMovementStrategy(directionVector),
                EnemyType.Zol => CreateZolMovementStrategy(directionVector),
                EnemyType.Aquamentus => CreateAquamentusMovementStrategy(directionVector),
                EnemyType.Rope => CreateRopeMovementStrategy(directionVector),
                EnemyType.Dodongo => CreateDodongoMovementStrategy(directionVector),
                EnemyType.OldMan => CreateFreezeStrategy(),
                EnemyType.Merchant => CreateFreezeStrategy(),
                EnemyType.Bubble => CreateBubbleMovementStrategy(directionVector),
                EnemyType.Darknut => CreateDarknutMovementStrategy(directionVector),
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

        public IMovementStrategy CreateChaseStrategy(Vector2 directionVector)
        {
            // If multiple enemies could chase, this can be turned into a switch case with an EnemyType enum parameter
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.RopeChaseSpeed, ObjectConstants.zeroPauseTime);
        }

        //----- Enemy disambiguation strategies creator methods -----//

        private IMovementStrategy CreateStalfosMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.StalfosMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateKeeseMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.KeeseMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateGoriyaMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.GoriyaMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateGelMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.GelMoveSpeed, (float)ObjectConstants.GelPauseTime);
        }

        private IMovementStrategy CreateZolMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.ZolMoveSpeed, (float)ObjectConstants.ZolPauseTime);
        }

        private IMovementStrategy CreateAquamentusMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.AquamentusMoveSpeed, (int)ObjectConstants.AquamentusMoveDistance);
        }

        private IMovementStrategy CreateRopeMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.RopeMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateDodongoMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.DodongoMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateBubbleMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.BubbleMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateDarknutMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.DarknutMoveSpeed, ObjectConstants.zeroPauseTime);
        }
    }
}
