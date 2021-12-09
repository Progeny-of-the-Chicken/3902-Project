﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class MegaDarknut : IEnemy
    {
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;
        private (ISprite sprite, IEnemyCollider detectionCollider) dependency;
        private Dictionary<FacingDirection, (ISprite sprite, IEnemyCollider detectionCollider)> directionDependencies;

        public IEnemyCollider Collider { get => collider; }
        public IEnemyCollider ChaseCollider { get => dependency.detectionCollider; }

        public int Damage { get => ObjectConstants.MegaDarknutDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged); }

        public MegaDarknut(Vector2 location)
        {
            stateMachine = new EnemyStateMachine(location, EnemyType.MegaDarknut, (float)ObjectConstants.MegaDarknutMoveTime, ObjectConstants.MegaDarknutMoveSpeed, ObjectConstants.MegaDarknutHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.MegaDarknut, stateMachine, this);
            invoker.ExecuteRandomCommand();

            Vector2 darknutDimensions = new Vector2((int)(SpriteRectangles.darknutBackFrame.Size.ToVector2().X * ObjectConstants.MegaDarknutScale), (int)(SpriteRectangles.darknutBackFrame.Size.ToVector2().Y * ObjectConstants.MegaDarknutScale));
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), darknutDimensions.ToPoint()));

            directionDependencies = new Dictionary<FacingDirection, (ISprite sprite, IEnemyCollider detectionCollider)>();
            directionDependencies.Add(FacingDirection.Right, (EnemySpriteFactory.Instance.CreateRightMegaDarknutSprite(), new ChaseDetectionCollider(this, new Rectangle((location + ObjectConstants.RightUnitVector * darknutDimensions.X).ToPoint(), new Point(ObjectConstants.roomWidth, (int)darknutDimensions.Y)))));
            directionDependencies.Add(FacingDirection.Left, (EnemySpriteFactory.Instance.CreateLeftMegaDarknutSprite(), new ChaseDetectionCollider(this, new Rectangle(0, (int)location.Y, (int)location.X, (int)darknutDimensions.Y))));
            directionDependencies.Add(FacingDirection.Up, (EnemySpriteFactory.Instance.CreateBackMegaDarknutSprite(), new ChaseDetectionCollider(this, ObjectConstants.nullRectangle)));
            directionDependencies.Add(FacingDirection.Down, (EnemySpriteFactory.Instance.CreateFrontMegaDarknutSprite(), new ChaseDetectionCollider(this, ObjectConstants.nullRectangle)));
            directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            stateMachine.Update(t);
            if (stateMachine.StateChange)
            {
                directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);
            }
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }
            dependency.sprite.Update(t);
            collider.Update(Position);
            dependency.detectionCollider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            // Unused for mega darknut
        }

        public void TryTakeDamage(int damage, Vector2 damageVector)
        {
            damageVector.Normalize();
            if (DoDeflection(damageVector))
            {
                stateMachine.TakeDamage(damage, false);
            }
            else
            {
                // Short term invulnerability
                stateMachine.TakeDamage(ObjectConstants.zero, false);
                SFXManager.Instance.PlayShieldDeflect();
            }
        }

        public void ChaseLink()
        {
            if (stateMachine.GetState == EnemyState.Movement)
            {
                if (stateMachine.GetDirection == FacingDirection.Left)
                {
                    stateMachine.SetState(EnemyState.Chase, (float)ObjectConstants.MegaDarknutChaseTimeoutTime, ObjectConstants.LeftUnitVector);
                }
                else if (stateMachine.GetDirection == FacingDirection.Right)
                {
                    stateMachine.SetState(EnemyState.Chase, (float)ObjectConstants.MegaDarknutChaseTimeoutTime, ObjectConstants.RightUnitVector);
                }
            }
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // Mega darknut's armor is too heavy to suffer knockback
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public bool CheckDelete()
        {
            return stateMachine.IsDead;
        }

        public void Draw(SpriteBatch sb)
        {
            dependency.sprite.Draw(sb, Position);
        }

        //----- Helper method for damage deflection -----//

        public bool DoDeflection(Vector2 damageVector)
        {
            return damageVector switch
            {
                Vector2(1, 0) => stateMachine.GetDirection != FacingDirection.Left,
                Vector2(0, -1) => stateMachine.GetDirection != FacingDirection.Down,
                Vector2(-1, 0) => stateMachine.GetDirection != FacingDirection.Right,
                Vector2(0, 1) => stateMachine.GetDirection != FacingDirection.Up,
                // Should never happen
                _ => false
            };
        }
    }
}
