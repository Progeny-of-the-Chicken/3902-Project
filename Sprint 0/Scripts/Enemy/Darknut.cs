using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Darknut : IEnemy
    {
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;
        private ISprite dependency;
        private Dictionary<FacingDirection, ISprite> directionDependencies;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.DarknutDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged); }

        public Darknut(Vector2 location)
        {
            stateMachine = new EnemyStateMachine(location, EnemyType.Darknut, (float)ObjectConstants.DarknutMoveTime, ObjectConstants.DarknutStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Darknut, stateMachine, this);
            invoker.ExecuteRandomCommand();

            directionDependencies = new Dictionary<FacingDirection, ISprite>();
            directionDependencies.Add(FacingDirection.Right, EnemySpriteFactory.Instance.CreateRightDarknutSprite());
            directionDependencies.Add(FacingDirection.Left, EnemySpriteFactory.Instance.CreateLeftDarknutSprite());
            directionDependencies.Add(FacingDirection.Up, EnemySpriteFactory.Instance.CreateBackDarknutSprite());
            directionDependencies.Add(FacingDirection.Down, EnemySpriteFactory.Instance.CreateFrontDarknutSprite());
            directionDependencies.TryGetValue(stateMachine.GetDirection, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.darknutBackFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));

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
            dependency.Update(t);
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, false);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // Darknut's armor is too heavy to suffer knockback
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
            dependency.Draw(sb, Position);
        }
    }
}
