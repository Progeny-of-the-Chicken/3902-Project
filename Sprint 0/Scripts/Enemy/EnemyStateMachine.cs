using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private enum State { Base, Knockback, Frozen, Dead};
        private Dictionary<State, float> stateDurations = new Dictionary<State, float>();

        private EnemyMovementHandler movement;
        private Vector2 directionVector;
        private State currentState = State.Base;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;

        private int health;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public int Health { get => health; }

        public bool CheckDelete { get => currentState == State.Dead; }

        //----- Public methods -----//

        public EnemyStateMachine(float moveTime)
        {
            stateDurations.Add(State.Base, moveTime);
            stateDurations.Add(State.Frozen, (float)ObjectConstants.clockFreezeSeconds);
            stateDurations.Add(State.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime);
            stateDurations.Add(State.Dead, ObjectConstants.counterInitialVal_float);
        }

        public void Update(GameTime gameTime)
        {
            movement.Move(gameTime);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                // TODO: Maybe move these back to enemy class
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(Location, Effect.EffectType.Pop);
                currentState = State.Dead;
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
        }

        public void Displace(Vector2 direction)
        {
            movement.Displace(direction);
        }

        public void Knockback(Vector2 direction)
        {
            movement.Knockback(direction);
            currentState = State.Knockback;
        }

        public void Freeze()
        {
            movement.Freeze();
            currentState = State.Frozen;
        }

        private void ResetState()
        {
            if (currentState == State.Base)
            {
                
            }
            currentState = State.Base;
        }

        //----- Helper methods for sprites -----//
    }
}
