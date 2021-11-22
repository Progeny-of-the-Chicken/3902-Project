using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Movement;


namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private IEnemyCollider collider;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.StalfosDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public Gel(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            stateMachine = EnemyStateMachineFactory.Instance.CreateStateMachineForEnemy(location, EnemyType.Gel, (float)ObjectConstants.GelMoveTime + (float)ObjectConstants.GelPauseTime, ObjectConstants.GelStartingHealth);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            stateMachine.Update(t);
            if (stateMachine.GetState != EnemyStateMachine.EnemyState.Knockback)
            {
                sprite.Update(t);
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
