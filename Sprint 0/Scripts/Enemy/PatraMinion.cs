using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class PatraMinion : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.PatraMinionDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !stateMachine.IsDamaged; }

        public PatraMinion(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreatePatraSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Patra, (float)ObjectConstants.PatraMoveTime, ObjectConstants.PatraMinionStartingHealth);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.patraMinionFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            sprite.Update(gt);
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, true);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // No knockback
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            // No displacement
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
    }
}
