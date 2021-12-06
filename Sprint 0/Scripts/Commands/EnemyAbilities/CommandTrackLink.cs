using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandTrackLink : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandTrackLink(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            stateMachine.SetState(EnemyState.Movement, stateMachine.moveTime, ObjectConstants.zeroVector);
        }
    }
}
