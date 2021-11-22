using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

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
        private float disruptionTime = ObjectConstants.counterInitialVal_float;
        private bool disruptionOccurring = false;

        public Vector2 Location { get => location; }

        public Vector2 DirectionVector { get => directionVector; }

        public bool DisruptionOccurring { get => disruptionOccurring; }

        public EnemyMovementHandler(IMovementStrategy movementStrategy, float moveTime, List<Vector2> possibleVectors)
        {
            defaultStrategy = selectedStrategy = movementStrategy;
            this.moveTime = moveTime;
            this.possibleVectors = possibleVectors;

            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            directionVector = GetRandomDirection();
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

        public void SetStrategy(IMovementStrategy strategy)
        {
            selectedStrategy = strategy;
        }

        public void Displace(Vector2 direction)
        {
            location += direction;
        }

        public void Knockback(Vector2 direction, float knockbackTime)
        {
            selectedStrategy = MovementStrategyFactory.Instance.CreateKnockbackStrategy(direction);
            disruptionTime = (float)knockbackTime;
        }

        public void Freeze(float freezeTime)
        {
            selectedStrategy = MovementStrategyFactory.Instance.CreateFreezeStrategy();
            if (freezeTime > disruptionTime)
            {
                disruptionTime = freezeTime;
            }
        }

        //----- Helper methods for movement transition -----//

        private void CountDownMove(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                directionVector = GetRandomDirection();
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
