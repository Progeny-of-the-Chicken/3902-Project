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
                EnemyType.Patra => CreatePatraMovementStrategy(directionVector),
                EnemyType.MegaStalfos => CreateMegaStalfosMovementStrategy(directionVector),
                EnemyType.MegaGel => CreateMegaGelMovementStrategy(directionVector),
                EnemyType.MegaZol => CreateMegaZolMovementStrategy(directionVector),
                EnemyType.MegaKeese => CreateTrackLinkStrategy(),
                EnemyType.MegaDarknut => CreateMegaDarknutMovementStrategy(directionVector),
                EnemyType.Manhandla => CreateManhandlaMovementStrategy(directionVector),
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

        public IMovementStrategy CreateTrackLinkStrategy()
        {
            // Can be flexible with enums if more enemies use track link strategy
            return new TrackLinkStrategy(ObjectConstants.MegaKeeseMoveSpeed, new Vector2((int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaKeeseScale), (int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaKeeseScale)));
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

        private IMovementStrategy CreatePatraMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.PatraMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateMegaStalfosMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.MegaStalfosMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateMegaGelMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.MegaGelMoveSpeed, (float)ObjectConstants.MegaGelPauseTime);
        }

        private IMovementStrategy CreateMegaZolMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.MegaZolMoveSpeed, (float)ObjectConstants.MegaZolPauseTime);
        }

        private IMovementStrategy CreateMegaDarknutMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.MegaDarknutMoveSpeed, ObjectConstants.zeroPauseTime);
        }

        private IMovementStrategy CreateManhandlaMovementStrategy(Vector2 directionVector)
        {
            return new MoveInDirectionStrategy(directionVector, ObjectConstants.ManhandlaMoveSpeed, ObjectConstants.zeroPauseTime);
        }
    }
}
