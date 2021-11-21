using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class ChaseLinkStrategy : IMovementStrategy
    {
        private bool finishedMovement = false;

        public ChaseLinkStrategy()
        {
            // TODO: Add movement constants
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            // TODO: Add movement implementation
            return location;
        }

        public bool CheckFinish()
        {
            return finishedMovement;
        }
    }
}
