using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Movement
{
    public class EnemyMovementHandler
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        private List<Vector2> possibleVectors;

        private IMovementStrategy defaultStrategy;
        private IMovementStrategy selectedStrategy;
        private Vector2 location;
        private Vector2 directionVector;

        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        private float timeSinceDisruption = ObjectConstants.counterInitialVal_float;
        private float moveTime;
        private EnemyType enemyType;
        private float disruptionTime;
        private bool disruptionOccurring = false;

        public Vector2 Location { get => location; }

        public Vector2 DirectionVector { get => directionVector; }

        public bool DisruptionOccurring { get => disruptionOccurring; }

        public EnemyMovementHandler(float moveTime, Vector2 location, List<Vector2> possibleVectors, EnemyType type)
        {
            this.moveTime = moveTime;
            this.location = location;
            this.possibleVectors = possibleVectors;
            enemyType = type;

            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            directionVector = GetRandomDirection();
            defaultStrategy = selectedStrategy = MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType);
        }

        public void Move(GameTime gameTime)
        {
            location = selectedStrategy.Move(gameTime, location);
            if (!disruptionOccurring)
            {
                CountDownMove(gameTime);
            }
            else
            {
                CountDownDisruption(gameTime);
            }
        }

        public void SetDisruptionStrategy(IMovementStrategy strategy, float duration)
        {
            selectedStrategy = strategy;
            disruptionTime = duration;
            disruptionOccurring = true;
        }

        public void Displace(Vector2 direction)
        {
            location += direction;
        }

        //----- Helper methods for movement transition -----//

        private void CountDownMove(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                directionVector = GetRandomDirection();
                selectedStrategy = MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType);
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
        }

        private void CountDownDisruption(GameTime gameTime)
        {
            timeSinceDisruption += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceDisruption >= disruptionTime)
            {
                selectedStrategy = defaultStrategy;
                disruptionOccurring = false;
                disruptionTime = ObjectConstants.counterInitialVal_float;
                timeSinceDisruption = ObjectConstants.counterInitialVal_float;
            }
        }

        //----- Random helper -----//

        private Vector2 GetRandomDirection()
        {
            randomDir.GetBytes(random);
            return possibleVectors[random[ObjectConstants.firstInArray] % possibleVectors.Count];
        }
    }
}
