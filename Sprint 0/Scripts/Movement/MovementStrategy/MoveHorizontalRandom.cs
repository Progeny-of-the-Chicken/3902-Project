using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class MoveHorizontalRandom : IMovementStrategy
    {
        private float speed;
        private int moveDistance;
        private Vector2 startLocation;
        private Vector2 directionVector;

        public MoveHorizontalRandom(Vector2 directionVector, float speed, int moveDistance)
        {
            this.directionVector = directionVector;
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
