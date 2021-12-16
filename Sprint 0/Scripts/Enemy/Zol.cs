using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Enemy
{
    public class Zol : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.StalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Zol(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Zol, (float)ObjectConstants.ZolMoveTime + (float)ObjectConstants.ZolPauseTime, ObjectConstants.ZolMoveSpeed, ObjectConstants.ZolStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Zol, stateMachine, this);
            invoker.ExecuteRandomCommand();
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.zolFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));

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
            if (stateMachine.IsDead)
            {
                IEnemy gel = ObjectsFromObjectsFactory.Instance.CreateGelFromZol(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), new Vector2(ObjectConstants.GelWidthHeight)));
                // Give gels short immunity
                gel.TakeDamage(ObjectConstants.zero);
                gel = ObjectsFromObjectsFactory.Instance.CreateGelFromZol(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), new Vector2(ObjectConstants.GelWidthHeight)));
                gel.TakeDamage(ObjectConstants.zero);
            }
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            //Don't move if you're going to be deleted so the Gels spawn properly
            if (!stateMachine.IsDead)
            {
                knockback.Normalize();
                stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime, knockback);
            }
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
