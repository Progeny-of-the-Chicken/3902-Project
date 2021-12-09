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
                EnemyType.Stalfos => CreateStalfosMovementStrategy(directionVector, moveSpeed),
                EnemyType.Keese => CreateKeeseMovementStrategy(directionVector, moveSpeed),
                EnemyType.Goriya => CreateGoriyaMovementStrategy(directionVector, moveSpeed),
                EnemyType.Gel => CreateGelMovementStrategy(directionVector, moveSpeed),
                EnemyType.Zol => CreateZolMovementStrategy(directionVector, moveSpeed),
                EnemyType.Aquamentus => CreateAquamentusMovementStrategy(directionVector, moveSpeed),
                EnemyType.Rope => CreateRopeMovementStrategy(directionVector, moveSpeed),
                EnemyType.Dodongo => CreateDodongoMovementStrategy(directionVector, moveSpeed),
                EnemyType.OldMan => CreateFreezeStrategy(),
                EnemyType.Merchant => CreateFreezeStrategy(),
                EnemyType.Bubble => CreateBubbleMovementStrategy(directionVector, moveSpeed),
                EnemyType.Darknut => CreateDarknutMovementStrategy(directionVector, moveSpeed),
                EnemyType.Patra => CreatePatraMovementStrategy(directionVector, moveSpeed),
                EnemyType.MegaStalfos => CreateMegaStalfosMovementStrategy(directionVector, moveSpeed),
                EnemyType.MegaGel => CreateMegaGelMovementStrategy(directionVector, moveSpeed),
                EnemyType.MegaZol => CreateMegaZolMovementStrategy(directionVector, moveSpeed),
                EnemyType.MegaKeese => CreateTrackLinkStrategy(moveSpeed),
                EnemyType.MegaDarknut => CreateMegaDarknutMovementStrategy(directionVector, moveSpeed),
                EnemyType.Manhandla => CreateManhandlaMovementStrategy(directionVector, moveSpeed),
                EnemyType.ManhandlaHead => CreateFreezeStrategy(),
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

        //----- Enemy disambiguation strategies creator methods -----//

        private IMovementStrategy CreateStalfosMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateKeeseMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateGoriyaMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateGelMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.GelPauseTime);
        }

        private IMovementStrategy CreateZolMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.ZolPauseTime);
        }

        private IMovementStrategy CreateAquamentusMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, (int)ObjectConstants.AquamentusMoveDistance);
        }

        private IMovementStrategy CreateRopeMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateDodongoMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateBubbleMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateDarknutMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreatePatraMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateMegaStalfosMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateMegaGelMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.MegaGelPauseTime);
        }

        private IMovementStrategy CreateMegaZolMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, (float)ObjectConstants.MegaZolPauseTime);
        }

        private IMovementStrategy CreateMegaDarknutMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateManhandlaMovementStrategy(Vector2 directionVector, float moveSpeed)
        {
            return new MoveInDirectionStrategy(directionVector, moveSpeed, ObjectConstants.zeroPauseTime);
        }
    }
}
