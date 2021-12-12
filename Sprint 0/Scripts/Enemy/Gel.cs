using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.GelDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Gel(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Gel, (float)ObjectConstants.GelMoveTime + (float)ObjectConstants.GelPauseTime, ObjectConstants.GelStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Gel, stateMachine, this);
            invoker.ExecuteRandomCommand();
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            stateMachine.Update(t);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }

            if (stateMachine.GetState != EnemyState.Knockback)
            {
                sprite.Update(t);
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
            sprite.Draw(sb, Position);
        }
    }
}
