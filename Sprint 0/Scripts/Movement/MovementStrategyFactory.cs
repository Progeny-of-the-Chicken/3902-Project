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

        public IMovementStrategy CreateMovementStrategyForEnemy(Vector2 directionVector, float moveSpeed, EnemyType type)
        {
            return type switch
            {
                EnemyType.Gel => new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.GelPauseTime),
                EnemyType.Zol => new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.ZolPauseTime),
                EnemyType.MegaGel => new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.MegaGelPauseTime),
                EnemyType.MegaZol => new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.MegaZolPauseTime),
                EnemyType.MegaKeese => CreateTrackLinkStrategy(moveSpeed),
                _ => new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime)
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

        public IMovementStrategy CreateChaseStrategyForEnemy(Vector2 directionVector, EnemyType type)
        {
            return type switch
            {
                EnemyType.Rope => new MoveInDirectionStrategy(directionVector, ObjectConstants.RopeChaseSpeed, ObjectConstants.zeroPauseTime),
                EnemyType.MegaDarknut => new MoveInDirectionStrategy(directionVector, ObjectConstants.MegaDarknutChaseSpeed, ObjectConstants.zeroPauseTime),
                _ => CreateFreezeStrategy()
            };
        }

        public IMovementStrategy CreateTrackLinkStrategy(float moveSpeed)
        {
            // Can be flexible with enums if more enemies use track link strategy
            return new TrackLinkStrategy(moveSpeed, new Vector2((int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaKeeseScale), (int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaKeeseScale)));
        }

        public IMovementStrategy CreateOrbitEnemyStrategy(IEnemy centerEnemy, int radius, double radiusChange, Vector2 satelliteDimensions)
        {
            // Can be changed to take enemy enum to make constants dynamic if needed
            return new OrbitEnemyStrategy(centerEnemy, (float)ObjectConstants.PatraMinionOrbitTimeRadians, radius, radiusChange, satelliteDimensions);
        }

        public IMovementStrategy CreateOffsetFromEnemyStrategy(IEnemy centerEnemy, Vector2 offset)
        {
            return new OffsetFromEnemyStrategy(centerEnemy, offset);
        }
    }
}
