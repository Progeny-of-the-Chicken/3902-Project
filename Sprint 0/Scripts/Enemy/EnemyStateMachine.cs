using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private enum State { Base, Knockback, Frozen, Dead};
        private Dictionary<State, float> stateDurations = new Dictionary<State, float>
        {
            { State.Frozen, (float)ObjectConstants.clockFreezeSeconds },
            { State.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime }
        };

        private EnemyMovementHandler movement;
        private State currentState = State.Base;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;

        private int health;

        public Vector2 Location { get => movement.Location; }

        public int Health { get => health; }

        public bool CheckDelete { get => currentState == State.Dead; }

        public EnemyStateMachine()
        {
        }

        public void Update(GameTime gameTime)
        {
            movement.Move(gameTime);
            if (currentState == State.Knockback || currentState == State.Frozen)
            {
                CountDownState(gameTime);
            }
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

        //----- Helper methods for state transitions -----//

        private void CountDownState(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= stateDurations[currentState])
            {
                currentState = State.Base;
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
        }
    }
}
