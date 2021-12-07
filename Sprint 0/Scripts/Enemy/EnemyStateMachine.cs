using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private Stack<(EnemyState state, float stateEndTime)> stateStack;
        private (bool damaged, float damagedEndTime) damagedState = (false, 0);
        private EnemyMovementHandler movement;
        private Vector2 directionVector;
        private Vector2 lastMovementVector;
        private EnemyState lastState = EnemyState.NoAction;

        public float enemyLifeTime = ObjectConstants.counterInitialVal_float;
        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        public float moveTime;

        private EnemyType enemyType;
        private int health;
        private float knockbackSpeed = ObjectConstants.DefaultEnemyKnockbackSpeed;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public FacingDirection GetDirection { get => DirectionVectorToFacingDirection(directionVector); }

        public EnemyState GetState { get => stateStack.Peek().state; }

        public bool StateChange { get; set; }

        public int Health { get => health; }

        public bool IsDamaged { get => damagedState.damaged; }

        public bool IsDead { get => (health <= ObjectConstants.zero); }

        //----- Public methods -----//

        public EnemyStateMachine(Vector2 startLocation, EnemyType type, float moveTime, int health)
        {
            enemyType = type;
            this.health = health;
            this.moveTime = moveTime;

            stateStack = new Stack<(EnemyState state, float stateEndTime)>();
            movement = new EnemyMovementHandler(startLocation);
        }

        public void Update(GameTime gameTime)
        {
            movement.Move(gameTime);
            enemyLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GetState == EnemyState.Movement)
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
            UpdateStateChangeFlag();
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

        public void SetState(EnemyState state, float duration, IEnemy enemy, int radius, double radiusChange)
        {
            // Hard coded to patra minion for now, can be dynamic by making radius and radiuschange public members of passed enemy
            timeSinceMove = ObjectConstants.zero_float;
            stateStack.Push((state, duration));
            movement.SetStrategy(MovementStrategyFactory.Instance.CreateOrbitEnemyStrategy(enemy, radius, radiusChange, ObjectConstants.PatraMinionWidthHeight));
        }

        public void SetState(EnemyState state, float duration, IEnemy enemy, Vector2 offset)
        {
            timeSinceMove = ObjectConstants.zero_float;
            stateStack.Push((state, duration));
            movement.SetStrategy(MovementStrategyFactory.Instance.CreateOffsetFromEnemyStrategy(enemy, offset));
        }

        public void TakeDamage(int damage, bool isBoss)
        {
            health -= damage;
            damagedState = (true, enemyLifeTime + ObjectConstants.DefaultEnemyDamagedTime);
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(Location, Effect.EffectType.Pop);
                PlayDeathSound(isBoss);
            }
            PlayHitSound(isBoss);
        }

        public void Displace(Vector2 direction)
        {
            movement.Displace(direction);
        }

        public void EndState()
        {
            stateStack.Pop();
            if (stateStack.Count == 0)
            {
                SetState(EnemyState.NoAction, enemyLifeTime);
            }
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
                EnemyState.Chase => MovementStrategyFactory.Instance.CreateChaseStrategyForEnemy(lastMovementVector, enemyType),
                EnemyState.NoAction => MovementStrategyFactory.Instance.CreateFreezeStrategy(),
                // Should never happen
                _ => MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType)
            };
        }

        private void UpdateMove(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= stateStack.Peek().stateEndTime)
            {
                stateStack.Pop();
                SetState(EnemyState.NoAction, enemyLifeTime);
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

        private void UpdateStateChangeFlag()
        {
            StateChange = lastState == GetState;
            lastState = GetState;
        }

        //----- Helper method for sound control -----//

        private void PlayDeathSound(bool isBoss)
        {
            if (isBoss)
            {
                SFXManager.Instance.PlayBossScream1();
            }
            else
            {
                SFXManager.Instance.PlayEnemyDeath();
            }
        }

        private void PlayHitSound(bool isBoss)
        {
            if (isBoss)
            {
                SFXManager.Instance.PlayBossHit();
            }
            else
            {
                SFXManager.Instance.PlayEnemyHit();
            }
        }
    }
}
