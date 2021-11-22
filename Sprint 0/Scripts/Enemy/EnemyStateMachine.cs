using System.Collections.Generic;
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
        private State currentState = State.Base;

        private int health;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public FacingDirection GetDirection { get => DirectionVectorToFacingDirection(movement.DirectionVector); }

        public int Health { get => health; }

        public bool CheckDelete { get => currentState == State.Dead; }

        //----- Public methods -----//

        public EnemyStateMachine(EnemyMovementHandler movementHandler, float moveTime)
        {
            stateDurations.Add(State.Base, moveTime);
            stateDurations.Add(State.Frozen, (float)ObjectConstants.clockFreezeSeconds);
            stateDurations.Add(State.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime);
            stateDurations.Add(State.Dead, ObjectConstants.counterInitialVal_float);

            // TODO: Decide whether to pass an enum for enemy and declare movement handler here
            movement = movementHandler;
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
            movement.Knockback(direction, stateDurations[State.Knockback]);
            currentState = State.Knockback;
        }

        public void Freeze(float freezeTime)
        {
            movement.Freeze(freezeTime);
            currentState = State.Frozen;
        }

        //----- Helper method for sprites -----//

        private FacingDirection DirectionVectorToFacingDirection(Vector2 directionVector)
        {
            return directionVector switch
            {
                Vector2(1, 0) => FacingDirection.Right,
                Vector2(0, -1) => FacingDirection.Up,
                Vector2(-1, 0) => FacingDirection.Left,
                Vector2(0, 1) => FacingDirection.Down,
                // Default case are flying enemies
                _ => FacingDirection.Right
            };
        }
    }
}
