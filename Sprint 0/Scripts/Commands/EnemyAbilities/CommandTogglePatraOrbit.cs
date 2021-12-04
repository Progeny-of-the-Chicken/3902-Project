using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandTogglePatraOrbit : ICommand
    {
        private IEnemy patra;
        private EnemyStateMachine stateMachine;

        public CommandTogglePatraOrbit(IEnemy patra, EnemyStateMachine stateMachine)
        {
            this.patra = patra;
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            ((Patra)patra).ToggleOrbit();
            stateMachine.SetState(EnemyState.AbilityCast, stateMachine.moveTime);
        }
    }
}
