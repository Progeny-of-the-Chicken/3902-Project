using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Movement;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        // TODO: Implement damaged state
        public enum EnemyState { Movement, Knockback, Frozen};
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        private List<Vector2> possibleVectors;
        private Vector2 directionVector;
        private EnemyMovementHandler movement;
        private EnemyState currentState = EnemyState.Movement;

        private float timeSinceMove = ObjectConstants.counterInitialVal_float;
        private float timeSinceDisruption = ObjectConstants.counterInitialVal_float;
        private float moveTime;
        private float disruptionTime;

        private EnemyType enemyType;
        private int health;
        private float knockbackSpeed = ObjectConstants.DefaultEnemyKnockbackSpeed;

        //----- Public properties -----//

        public Vector2 Location { get => movement.Location; }

        public FacingDirection GetDirection { get => DirectionVectorToFacingDirection(directionVector); }

        public EnemyState GetState { get => currentState; }

        public int Health { get => health; }

        public bool IsDead { get => (health <= ObjectConstants.zero); }

        //----- Public methods -----//

        public EnemyStateMachine(Vector2 startLocation, EnemyType type, float moveTime, int health, List<Vector2> possibleVectors)
        {
            enemyType = type;
            this.health = health;
            this.moveTime = moveTime;
            this.possibleVectors = possibleVectors;

            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
            directionVector = GetRandomDirection();
            movement = new EnemyMovementHandler(MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, type), startLocation);
        }

        public void Update(GameTime gameTime)
        {
            if (currentState == EnemyState.Movement)
            {
                CountDownMove(gameTime);
            }
            else
            {
                CountDownDisruption(gameTime);
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
            movement.SetDisruptionStrategy(MovementStrategyFactory.Instance.CreateKnockbackStrategy(direction, knockbackSpeed));
            disruptionTime = knockbackTime;
            currentState = EnemyState.Knockback;
        }

        public void Freeze(float freezeTime)
        {
            movement.SetDisruptionStrategy(MovementStrategyFactory.Instance.CreateFreezeStrategy());
            disruptionTime = freezeTime;
            currentState = EnemyState.Frozen;
        }

        //----- Helper methods for movement transition -----//

        private void CountDownMove(GameTime gameTime)
        {
            timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                directionVector = GetRandomDirection();
                movement.SetMovementStrategy(MovementStrategyFactory.Instance.CreateMovementStrategyForEnemy(directionVector, enemyType));
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
        }

        private void CountDownDisruption(GameTime gameTime)
        {
            timeSinceDisruption += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceDisruption >= disruptionTime)
            {
                movement.ResumeMovementStrategy();
                currentState = EnemyState.Movement;
                disruptionTime = ObjectConstants.counterInitialVal_float;
                timeSinceDisruption = ObjectConstants.counterInitialVal_float;
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
