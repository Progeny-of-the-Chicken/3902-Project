using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class MegaKeese : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.MegaKeeseDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public MegaKeese(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateMegaKeeseSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.MegaKeese, (float)ObjectConstants.MegaKeeseMoveTime, ObjectConstants.MegaKeeseMoveSpeed, ObjectConstants.MegaKeeseHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.MegaKeese, stateMachine, this);
            invoker.ExecuteRandomCommand();
            Point colliderHitbox = new Vector2((int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaKeeseScale), (int)(SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaKeeseScale)).ToPoint();
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), colliderHitbox));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }

            if (stateMachine.GetState != EnemyState.Knockback)
            {
                sprite.Update(gt);
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
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.MegaKeeseKnockbackTime, knockback);
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
