using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandTogglePatraEllipse : ICommand
    {
        private IEnemy patra;
        private EnemyStateMachine stateMachine;

        public CommandTogglePatraEllipse(IEnemy patra, EnemyStateMachine stateMachine)
        {
            this.patra = patra;
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            /*
            ((Patra)patra).ToggleEllipse();
            */
            stateMachine.SetState(EnemyState.AbilityCast, stateMachine.moveTime);
        }
    }
}
