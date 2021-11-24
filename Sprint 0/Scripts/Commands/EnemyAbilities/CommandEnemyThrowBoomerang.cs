using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandEnemyThrowBoomerang : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandEnemyThrowBoomerang(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            stateMachine.SetState(EnemyState.AbilityCast, ObjectConstants.EnemyBoomerangTimeoutSeconds);
            // TODO: Find a way to send the Goriya to the factory
            ObjectsFromObjectsFactory.Instance.CreateBoomerangFromEnemy(stateMachine.Location, FacingDirection.Right, new Goriya(stateMachine.Location));
        }
    }
}
