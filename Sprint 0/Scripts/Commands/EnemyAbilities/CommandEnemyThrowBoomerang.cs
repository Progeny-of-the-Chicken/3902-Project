using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandEnemyThrowBoomerang : ICommand
    {
        private IEnemy enemy;
        private EnemyStateMachine stateMachine;

        public CommandEnemyThrowBoomerang(IEnemy enemy, EnemyStateMachine stateMachine)
        {
            this.enemy = enemy;
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            stateMachine.SetState(EnemyState.AbilityCast, stateMachine.enemyLifeTime + ObjectConstants.EnemyBoomerangTimeoutSeconds);
            ObjectsFromObjectsFactory.Instance.CreateBoomerangFromEnemy(stateMachine.Location, stateMachine.GetDirection, enemy);
        }
    }
}
