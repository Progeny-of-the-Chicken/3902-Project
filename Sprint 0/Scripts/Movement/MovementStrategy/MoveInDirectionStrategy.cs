using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class MoveInDirectionStrategy : IMovementStrategy
    {
        private float speed;
        private Vector2 directionVector;

        public MoveInDirectionStrategy(Vector2 directionVector, float speed)
        {
            this.directionVector = directionVector;
            this.speed = speed;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            return location += directionVector * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
