using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandMove : ICommand
    {
        private EnemyStateMachine stateMachine;
        private Vector2 direction;

        public CommandMove(EnemyStateMachine stateMachine, Vector2 direction)
        {
            this.stateMachine = stateMachine;
            this.direction = direction;
        }

        public void Execute()
        {
            // TODO: Add direction
            stateMachine.SetState(EnemyState.Movement, stateMachine.moveTime);
        }
    }
}
