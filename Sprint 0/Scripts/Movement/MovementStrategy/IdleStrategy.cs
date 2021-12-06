using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class IdleStrategy : IMovementStrategy
    {
        public IdleStrategy()
        {
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            // No change to location
            return location;
        }
    }
}
