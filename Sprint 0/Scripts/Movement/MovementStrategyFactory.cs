using Sprint_0.Scripts.Movement.MovementStrategy;

namespace Sprint_0.Scripts.Movement
{
    public class MovementStrategyFactory
    {
        private MovementStrategyFactory instance = new MovementStrategyFactory();

        public MovementStrategyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MovementStrategyFactory()
        {
        }
    }
}
