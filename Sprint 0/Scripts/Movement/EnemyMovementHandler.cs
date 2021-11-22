using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement
{
    public class EnemyMovementHandler
    {
        private IMovementStrategy defaultStrategy;
        private IMovementStrategy selectedStrategy;
        private Vector2 location;

        public Vector2 Location { get => location; }

        public EnemyMovementHandler(IMovementStrategy defaultStrategy, Vector2 location)
        {
            this.defaultStrategy = selectedStrategy = defaultStrategy;
            this.location = location;
        }

        public void Move(GameTime gameTime)
        {
            location = selectedStrategy.Move(gameTime, location);
        }

        public void ResumeMovementStrategy()
        {
            selectedStrategy = defaultStrategy;
        }

        public void SetMovementStrategy(IMovementStrategy strategy)
        {
            defaultStrategy = selectedStrategy = strategy;
        }

        public void SetDisruptionStrategy(IMovementStrategy strategy)
        {
            selectedStrategy = strategy;
        }

        public void Displace(Vector2 direction)
        {
            location += direction;
        }
    }
}
