using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class Dodongo : IEnemy
    {
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider detectionCollider;
        private ISprite sprite;
        private (Vector2 directionVector, ISprite walkSprite, ISprite explodeSprite, IEnemyCollider collider) dependency;
        private Dictionary<FacingDirection, (Vector2, ISprite, ISprite, IEnemyCollider)> directionDependencies;

        public IEnemyCollider Collider { get => dependency.collider; }

        public IEnemyCollider DetectionCollider { get => detectionCollider; }

        public int Damage { get => ObjectConstants.StalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Dodongo(Vector2 location)
        {
            stateMachine = new EnemyStateMachine(location, EnemyType.Dodongo, (float)ObjectConstants.DodongoMoveTime, ObjectConstants.DodongoMoveSpeed, ObjectConstants.DodongoStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Dodongo, stateMachine, this);
            invoker.ExecuteRandomCommand();

            directionDependencies = new Dictionary<FacingDirection, (Vector2, ISprite, ISprite, IEnemyCollider)>();
            GenericEnemyCollider HCollision = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.dodongoRightFrames[ObjectConstants.firstInArray].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            GenericEnemyCollider VCollision = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.dodongoDownFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            directionDependencies.Add(FacingDirection.Right, (ObjectConstants.RightUnitVector, EnemySpriteFactory.Instance.CreateDodongoRightSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeRightSprite(), HCollision));
            directionDependencies.Add(FacingDirection.Left, (ObjectConstants.LeftUnitVector, EnemySpriteFactory.Instance.CreateDodongoLeftSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeLeftSprite(), HCollision));
            directionDependencies.Add(FacingDirection.Up, (ObjectConstants.UpUnitVector, EnemySpriteFactory.Instance.CreateDodongoUpSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeUpSprite(), VCollision));
            directionDependencies.Add(FacingDirection.Down, (ObjectConstants.DownUnitVector, EnemySpriteFactory.Instance.CreateDodongoDownSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeDownSprite(), VCollision));
            detectionCollider = new DodongoDetectionCollider(this, new Rectangle((location + dependency.directionVector * ObjectConstants.scaledStdWidthHeight).ToPoint(), (Vector2.One * ObjectConstants.scaledStdWidthHeight).ToPoint()));
            directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);
            sprite = dependency.walkSprite;

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.StateChange)
            {
                directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);
                if (stateMachine.GetState == EnemyState.Stun)
                {
                    sprite = dependency.explodeSprite;
                }
                else
                {
                    sprite = dependency.walkSprite;
                }
            }
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }

            sprite.Update(gt);
            dependency.collider.Update(Position);
            if (stateMachine.GetDirection == FacingDirection.Right) 
                detectionCollider.Update(Position + Vector2.UnitX * SpriteRectangles.dodongoRightFrames[ObjectConstants.firstFrame].Width * ObjectConstants.scale);
            else 
                detectionCollider.Update(Position + dependency.directionVector * ObjectConstants.scaledStdWidthHeight);
        }

        public void TakeDamage(int damage)
        {
            if (stateMachine.GetState == EnemyState.Stun)
            {
                stateMachine.TakeDamage(damage, true);
            }
            else
            {
                SFXManager.Instance.PlayShieldDeflect();
            }
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //Unused
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public void Stun()
        {
            stateMachine.SetState(EnemyState.Stun, (float)ObjectConstants.DodongoStunTime);
            TakeDamage(ObjectConstants.basicSwordDamage);
        }

        public bool CheckDelete()
        {
            return stateMachine.IsDead;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}
