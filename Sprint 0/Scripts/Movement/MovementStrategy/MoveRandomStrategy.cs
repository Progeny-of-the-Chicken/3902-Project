using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Security.Cryptography;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class MoveRandomStrategy : IMovementStrategy
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;

        private float speed;
        private float moveTime;
        private float pauseTime;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        private Vector2 directionVector;
        private List<Vector2> possibleVectors;

        public MoveRandomStrategy(List<Vector2> possibleVectors, float speed, float moveTime, float pauseTime)
        {
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            directionVector = GetRandomDirection();

            this.possibleVectors = possibleVectors;
            this.speed = speed;
            this.moveTime = moveTime;
            this.pauseTime = pauseTime;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            Vector2 returnLocation = location;
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= moveTime + pauseTime)
            {
                directionVector = GetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            if (timeSinceMove >= pauseTime)
            {
                returnLocation += directionVector * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            return returnLocation;
        }

        //----- Random helper -----//

        private Vector2 GetRandomDirection()
        {
            randomDir.GetBytes(random);
            return possibleVectors[random[ObjectConstants.firstInArray] % possibleVectors.Count];
        }
    }
}
