using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class Rope : IEnemy
    {
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        ISprite leftSprite;
        ISprite rightSprite;

        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }
        public IEnemyCollider ChaseCollider { get => dependency.chaseCollider; }

        IEnemyCollider leftCollider;
        IEnemyCollider rightCollider;

        public int Damage { get => ObjectConstants.RopeDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => true; }

        (Vector2 directionVector, ISprite sprite, IEnemyCollider chaseCollider, Vector2 colliderOffset) dependency;

        Dictionary<FacingDirection, (Vector2, ISprite, IEnemyCollider, Vector2)> directionDependencies;

        public Rope(Vector2 location)
        {
            stateMachine = new EnemyStateMachine(location, EnemyType.Rope, (float)ObjectConstants.RopeMoveTime, ObjectConstants.RopeStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Rope, stateMachine, this);
            invoker.ExecuteRandomCommand();

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.ropeFrames[ObjectConstants.zero].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            leftCollider = rightCollider = new ChaseDetectionCollider(this, new Rectangle(0, 0, ObjectConstants.roomWidth, ObjectConstants.scaledStdWidthHeight));
            
            leftSprite = EnemySpriteFactory.Instance.CreateLeftRopeSprite();
            rightSprite = EnemySpriteFactory.Instance.CreateRightRopeSprite();

            directionDependencies = new Dictionary<FacingDirection, (Vector2, ISprite, IEnemyCollider, Vector2)>();
            directionDependencies.Add(FacingDirection.Left, (ObjectConstants.LeftUnitVector, leftSprite, leftCollider, ObjectConstants.LeftUnitVector * ObjectConstants.roomWidth));
            directionDependencies.Add(FacingDirection.Right, (ObjectConstants.RightUnitVector, rightSprite, rightCollider, ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight));
            directionDependencies.Add(FacingDirection.Up, (ObjectConstants.UpUnitVector, rightSprite, rightCollider, ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight));
            directionDependencies.Add(FacingDirection.Down, (ObjectConstants.DownUnitVector, rightSprite, rightCollider, ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight));
            directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.StateChange)
            {
                directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);
            }
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }
            if (stateMachine.GetState != EnemyState.Knockback)
            {
                dependency.sprite.Update(gt);
            }
            collider.Update(Position);
            dependency.chaseCollider.Update(Position + dependency.colliderOffset);
        }
        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, false);
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime, knockback);
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public void ChaseLink()
        {
            if (stateMachine.GetState == EnemyState.Movement)
            {
                if (stateMachine.GetDirection == FacingDirection.Left)
                {
                    stateMachine.SetState(EnemyState.Chase, (float)ObjectConstants.RopeChaseTimeoutTime, ObjectConstants.LeftUnitVector);
                }
                else
                {
                    stateMachine.SetState(EnemyState.Chase, (float)ObjectConstants.RopeChaseTimeoutTime, ObjectConstants.RightUnitVector);
                }
            }
        }

        public bool CheckDelete()
        {
            return stateMachine.IsDead;
        }

        public void Draw(SpriteBatch sb)
        {
            dependency.sprite.Draw(sb, stateMachine.Location);
        }
    }
}
