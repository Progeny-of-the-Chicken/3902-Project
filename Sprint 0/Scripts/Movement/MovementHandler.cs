using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement
{
    public class MovementHandler
    {
        private IMovementStrategy selectedStrategy;

        public MovementHandler(IMovementStrategy startingStrategy)
        {
            selectedStrategy = startingStrategy;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            return selectedStrategy.Move(gameTime, location);
        }

        public bool CheckFinish()
        {
            return selectedStrategy.CheckFinish();
        }

        public void SetStrategy(IMovementStrategy strategy)
        {
            selectedStrategy = strategy;
        }
    }
}
