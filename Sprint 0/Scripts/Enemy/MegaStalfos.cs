using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Enemy
{
    public class MegaStalfos : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        private Vector2 lastKnockbackVector = ObjectConstants.LeftUnitVector;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.MegaStalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public MegaStalfos(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateMegaStalfosSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.MegaStalfos, (float)ObjectConstants.MegaStalfosMoveTime, ObjectConstants.MegaStalfosHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Stalfos, stateMachine, this);
            invoker.ExecuteRandomCommand();
            Point colliderHitbox = new Vector2((int)(SpriteRectangles.stalfosFrame.Size.ToVector2().X * ObjectConstants.MegaStalfosScale), (int)(SpriteRectangles.stalfosFrame.Size.ToVector2().Y * ObjectConstants.MegaStalfosScale)).ToPoint();
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
            SpawnStalfosForDamage(damage);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            lastKnockbackVector = knockback;
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.MegaStalfosKnockbackTime, knockback);
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
            sprite.Draw(sb, Position);
        }

        //----- Helper method for regular stalfos spawning -----//

        private void SpawnStalfosForDamage(int damage)
        {
            while (damage > 0)
            {
                IEnemy stalfos = ObjectsFromObjectsFactory.Instance.CreateStalfosFromMegaStalfos(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), SpriteRectangles.stalfosFrame.Size.ToVector2() * ObjectConstants.scale));
                stalfos.GradualKnockBack(lastKnockbackVector);
                damage--;
            }
        }
    }
}
