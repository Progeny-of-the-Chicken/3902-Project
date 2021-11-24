using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        private List<Vector2> possibleVectors;
        private Vector2 directionVector;
        private Vector2 lastKnockbackVector;
        private EnemyMovementHandler movement;
        private Stack<(EnemyState state, float stateEndTime)> stateStack;
        private (bool damaged, float damagedEndTime) damagedState = (false, 0);
        
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

        public EnemyStateMachine(Vector2 startLocation, EnemyType type, float moveTime, int health, List<Vector2> possibleVectors)
        {
            enemyType = type;
            this.health = health;
            this.moveTime = moveTime;
            this.possibleVectors = possibleVectors;

            stateStack = new Stack<(EnemyState state, float stateEndTime)>();
            stateStack.Push((EnemyState.Movement, moveTime));

            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
            directionVector = GetRandomDirection();
            movement = new EnemyMovementHandler(MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, type), startLocation);
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
            lastKnockbackVector = knockback;
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
                EnemyState.Knockback => MovementStrategyFactory.Instance.CreateKnockbackStrategy(lastKnockbackVector, knockbackSpeed),
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
                directionVector = GetRandomDirection();
                movement.SetStrategy(GetStrategyForState(stateStack.Peek().state));
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

        //----- Random helper -----//

        private Vector2 GetRandomDirection()
        {
            randomDir.GetBytes(random);
            return possibleVectors[random[ObjectConstants.firstInArray] % possibleVectors.Count];
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
