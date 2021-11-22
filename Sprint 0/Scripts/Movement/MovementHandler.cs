using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement
{
    public class MovementHandler
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        private List<Vector2> possibleVectors;

        private IMovementStrategy defaultStrategy;
        private IMovementStrategy selectedStrategy;
        public Vector2 location;

        public MovementHandler(IMovementStrategy startingStrategy)
        {
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];

            defaultStrategy = selectedStrategy = startingStrategy;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Move(GameTime gameTime, Vector2 location)
        {
            this.location = selectedStrategy.Move(gameTime, location);
        }

        public void SetStrategy(IMovementStrategy strategy)
        {
            selectedStrategy = strategy;
        }

        public void SetStrategyToDefault()
        {
            selectedStrategy = defaultStrategy;
        }

        public void Displace(Vector2 direction)
        {
            location += direction;
        }

        public void Knockback(Vector2 direction)
        {
            selectedStrategy = MovementStrategyFactory.Instance.CreateKnockbackStrategy(direction);
        }

        //----- Random helper -----//

        private Vector2 GetRandomDirection()
        {
            randomDir.GetBytes(random);
            return possibleVectors[random[ObjectConstants.firstInArray] % possibleVectors.Count];
        }
    }
}
