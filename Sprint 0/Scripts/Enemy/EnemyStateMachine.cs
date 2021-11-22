using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private MovementHandler movement;
        private Vector2 location;

        public EnemyStateMachine()
        {
        }

        public void Knockback(Vector2 direction)
        {
            movement.Knockback(direction);
        }
    }
}
