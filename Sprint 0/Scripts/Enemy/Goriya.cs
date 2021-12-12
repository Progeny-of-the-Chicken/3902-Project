using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Goriya : IEnemy
    {
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;
        private ISprite dependency;
        private Dictionary<FacingDirection, ISprite> directionDependencies;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.StalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public bool BoomerangCaught { get; set; }

        public Goriya(Vector2 location)
        {
            stateMachine = new EnemyStateMachine(location, EnemyType.Goriya, (float)ObjectConstants.GoriyaMoveTime, ObjectConstants.GoriyaStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Goriya, stateMachine, this);
            invoker.ExecuteRandomCommand();

            directionDependencies = new Dictionary<FacingDirection, ISprite>();
            directionDependencies.Add(FacingDirection.Right, EnemySpriteFactory.Instance.CreateRightGoriyaSprite());
            directionDependencies.Add(FacingDirection.Left, EnemySpriteFactory.Instance.CreateLeftGoriyaSprite());
            directionDependencies.Add(FacingDirection.Up, EnemySpriteFactory.Instance.CreateBackGoriyaSprite());
            directionDependencies.Add(FacingDirection.Down, EnemySpriteFactory.Instance.CreateFrontGoriyaSprite());
            directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), new Point(ObjectConstants.GoriyaWidthHeight * ObjectConstants.scale)));
            BoomerangCaught = false;

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            stateMachine.Update(t);
            if (stateMachine.StateChange)
            {
                directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);
            }
            if (BoomerangCaught && stateMachine.GetState == EnemyState.AbilityCast)
            {
                stateMachine.EndState();
                BoomerangCaught = false;
            }
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }
            if (stateMachine.GetState != EnemyState.Knockback)
            {
                dependency.Update(t);
            }
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, false);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime, knockback);
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public void ChangeDirection()
        {
            if (stateMachine.GetState == EnemyState.Movement)
            {
                stateMachine.EndState();
                invoker.ExecuteRandomCommand();
            }
        }

        public bool CheckDelete()
        {
            return stateMachine.IsDead;
        }

        public void Draw(SpriteBatch sb)
        {
            dependency.Draw(sb, Position);
        }
    }
}

