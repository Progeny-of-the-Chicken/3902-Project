using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandShootMagicProjectileTowardLink : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandShootMagicProjectileTowardLink(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            // TODO: Implement projectile
            stateMachine.SetState(EnemyState.AbilityCast, ObjectConstants.ManhandlaHeadReloadTime);
        }
    }
}
