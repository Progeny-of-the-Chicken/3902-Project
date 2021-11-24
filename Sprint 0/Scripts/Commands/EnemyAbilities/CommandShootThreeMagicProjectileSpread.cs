using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandShootThreeMagicProjectileSpread : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandShootThreeMagicProjectileSpread(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            // TODO: Generalize ObjectsFromObjects method, create all three here with Aquamentus parameter
            ObjectsFromObjectsFactory.Instance.CreateThreeMagicProjectilesFromEnemy(stateMachine.Location, stateMachine.GetDirection);
        }
    }
}
