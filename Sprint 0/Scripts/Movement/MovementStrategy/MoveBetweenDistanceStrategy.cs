using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class MoveBetweenDistanceStrategy : IMovementStrategy
    {
        private Vector2 startVector;
        private float speed;
        private int moveDistance;
        private Vector2 startLocation = ObjectConstants.zeroVector;
        private Vector2 directionVector;

        public MoveBetweenDistanceStrategy(Vector2 startVector, float speed, int moveDistance)
        {
            this.startVector = startVector;
            this.speed = speed;
            this.moveDistance = moveDistance;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            if (location.X < startLocation.X - moveDistance || location.X > startLocation.X)
            {
                directionVector *= ObjectConstants.vectorFlip;
            }
            return location += speed * directionVector * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
