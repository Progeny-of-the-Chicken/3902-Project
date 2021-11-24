using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private Stack<(EnemyState state, float stateEndTime)> stateStack;
        private (bool damaged, float damagedEndTime) damagedState = (false, 0);
        private EnemyRandomInvoker invoker;
        private EnemyMovementHandler movement;
        private Vector2 directionVector;
        private Vector2 lastMovementVector;

        private float enemyLifeTime = ObjectConstants.counterInitialVal_float;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        public float moveTime;

        private EnemyType enemyType;
        private int health;
        private float knockbackSpeed = ObjectConstants.DefaultEnemyKnockbackSpeed;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public FacingDirection GetDirection { get => DirectionVectorToFacingDirection(directionVector); }

        public EnemyState GetState { get => stateStack.Peek().state; }

        public int Health { get => health; }

        public bool IsDamaged { get => damagedState.damaged; }

        public bool IsDead { get => (health <= ObjectConstants.zero); }

        //----- Public methods -----//

        public EnemyStateMachine(Vector2 startLocation, EnemyType type, float moveTime, int health, IEnemy enemy)
        {
            enemyType = type;
            this.health = health;
            this.moveTime = moveTime;

            stateStack = new Stack<(EnemyState state, float stateEndTime)>();
            movement = new EnemyMovementHandler(startLocation);

            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(type, this, enemy);
            invoker.ExecuteRandomCommand();
        }

        public void Update(GameTime gameTime)
        {
            enemyLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (stateStack.Peek().state == EnemyState.Movement)
            {
                UpdateMove(gameTime);
            }
            else
            {
                UpdateState();
            }

            if (damagedState.damaged)
            {
                UpdateDamaged();
            }

            movement.Move(gameTime);
        }

        public void SetState(EnemyState state, float duration, Vector2 direction)
        {
            if (state == EnemyState.Movement)
            {
                stateStack.Push((state, duration));
                directionVector = direction;
                movement.SetStrategy(GetStrategyForState(state));
            }
            else
            {
                lastMovementVector = direction;
                SetState(state, duration);
            }
        }

        public void SetState(EnemyState state, float duration)
        {
            stateStack.Push((state, enemyLifeTime + duration));
            movement.SetStrategy(GetStrategyForState(state));
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            damagedState = (true, enemyLifeTime + ObjectConstants.DefaultEnemyDamagedTime);
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(Location, Effect.EffectType.Pop);
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
        }

        public void Knockback(Vector2 knockback)
        {
            lastMovementVector = knockback;
            SetState(EnemyState.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime);
        }

        public void Displace(Vector2 direction)
        {
            movement.Displace(direction);
        }

        //----- Helper methods for movement transition -----//

        private IMovementStrategy GetStrategyForState(EnemyState state)
        {
            return state switch
            {
                EnemyState.Movement => MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType),
                EnemyState.Knockback => MovementStrategyFactory.Instance.CreateKnockbackStrategy(lastMovementVector, knockbackSpeed),
                EnemyState.Freeze => MovementStrategyFactory.Instance.CreateFreezeStrategy(),
                EnemyState.Stun => MovementStrategyFactory.Instance.CreateFreezeStrategy(),
                EnemyState.AbilityCast => MovementStrategyFactory.Instance.CreateFreezeStrategy(),
                // Should never happen
                _ => MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType)
            };
        }

        private void UpdateMove(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                invoker.ExecuteRandomCommand();
                // movement.SetStrategy(GetStrategyForState(stateStack.Peek().state));
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
        }

        private void UpdateState()
        {
            if (enemyLifeTime >= stateStack.Peek().stateEndTime)
            {
                stateStack.Pop();
                movement.SetStrategy(GetStrategyForState(stateStack.Peek().state));
            }
        }

        private void UpdateDamaged()
        {
            if (enemyLifeTime >= damagedState.damagedEndTime)
            {
                damagedState.damaged = false;
            }
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
