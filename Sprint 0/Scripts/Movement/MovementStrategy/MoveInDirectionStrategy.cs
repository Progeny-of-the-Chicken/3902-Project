using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Security.Cryptography;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class MoveInDirectionStrategy : IMovementStrategy
    {
        private float speed;
        private float pauseTime;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        private Vector2 directionVector;

        public MoveInDirectionStrategy(Vector2 directionVector, float speed, float pauseTime)
        {
            this.directionVector = directionVector;
            this.speed = speed;
            this.pauseTime = pauseTime;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            Vector2 returnLocation = location;
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= pauseTime)
            {
                returnLocation += directionVector * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            return returnLocation;
        }
    }
}
