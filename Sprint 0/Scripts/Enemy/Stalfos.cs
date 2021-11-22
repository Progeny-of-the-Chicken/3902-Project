using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Movement;

namespace Sprint_0.Scripts.Enemy
{
    public class Stalfos : IEnemy
    {
        ISprite sprite;
        private EnemyStateMachine stateMachine;
        IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.StalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public Stalfos(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            stateMachine = EnemyStateMachineFactory.Instance.CreateStateMachineForEnemy(location, EnemyType.Stalfos, (float)ObjectConstants.StalfosMoveTime, ObjectConstants.StalfosStartingHealth);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.stalfosFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState != EnemyStateMachine.EnemyState.Knockback)
            {
                sprite.Update(gt);
            }
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            stateMachine.Knockback(knockback, (float)ObjectConstants.DefaultEnemyKnockbackTime);
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
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
