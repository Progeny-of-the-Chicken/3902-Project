using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        // TODO: Damaged state
        public enum State { Base, Knockback, Frozen};

        private EnemyMovementHandler movement;
        private State currentState = State.Base;

        private int health;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public FacingDirection GetDirection { get => DirectionVectorToFacingDirection(movement.DirectionVector); }

        public State GetState { get => currentState; }

        public int Health { get => health; }

        public bool CheckDelete { get => (health <= ObjectConstants.zero); }

        //----- Public methods -----//

        public EnemyStateMachine(Vector2 startLocation, EnemyType type, int health)
        {
            movement = EnemyMovementHandlerFactory.Instance.CreateMovementHandlerForEnemy(startLocation, type);
            this.health = health;
        }

        public void Update(GameTime gameTime)
        {
            if (!movement.DisruptionOccurring)
            {
                currentState = State.Base;
            }
            movement.Move(gameTime);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(Location, Effect.EffectType.Pop);
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
        }

        public void Displace(Vector2 direction)
        {
            movement.Displace(direction);
        }

        public void Knockback(Vector2 direction, float knockbackTime)
        {
            movement.SetDisruptionStrategy(MovementStrategyFactory.Instance.CreateKnockbackStrategy(direction, ObjectConstants.DefaultEnemyKnockbackSpeed), knockbackTime);
            currentState = State.Knockback;
        }

        public void Freeze(float freezeTime)
        {
            movement.SetDisruptionStrategy(MovementStrategyFactory.Instance.CreateFreezeStrategy(), freezeTime);
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
