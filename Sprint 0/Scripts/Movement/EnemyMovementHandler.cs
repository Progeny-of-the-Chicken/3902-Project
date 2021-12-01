using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement
{
    public class EnemyMovementHandler
    {
        private IMovementStrategy strategy;
        private Vector2 location;

        public Vector2 Location { get => location; }

        public EnemyMovementHandler(Vector2 location)
        {
            this.location = location;
        }

        public void Move(GameTime gameTime)
        {
            location = strategy.Move(gameTime, location);
        }

        public void SetStrategy(IMovementStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Displace(Vector2 direction)
        {
            location += direction;
        }
    }
}
