using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;

namespace Sprint_0.Scripts.Enemy
{
    public class PatraMinion : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private IEnemyCollider collider;
        private IEnemy patra;

        private int radius = ObjectConstants.PatraMinionBaseOrbitRadius;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.PatraMinionDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !stateMachine.IsDamaged; }

        public PatraMinion(Vector2 location, IEnemy patra)
        {
            sprite = EnemySpriteFactory.Instance.CreatePatraMinionSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.PatraMinion, (float)ObjectConstants.PatraMoveTime, ObjectConstants.PatraMinionStartingHealth);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.patraMinionFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            stateMachine.SetState(EnemyState.Movement, (float)ObjectConstants.PatraMoveTime, patra, radius, ObjectConstants.zero_double);
            this.patra = patra;
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                stateMachine.SetState(EnemyState.Movement, (float)ObjectConstants.PatraMoveTime, patra, radius, ObjectConstants.zero_double);
            }
            sprite.Update(gt);
            collider.Update(Position);

            if (stateMachine.IsDead)
            {
                ((Patra)patra).RemovePatraMinion(this);
            }
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

        public void ToggleOrbit(double radiusChange)
        {
            stateMachine.SetState(EnemyState.Movement, (float)ObjectConstants.PatraMoveTime, patra, radius, radiusChange);
            // Set new radius for after change
            if (((Patra)patra).orbitState.extended)
            {
                radius = ObjectConstants.PatraMinionExtendedOrbitRadius;
            }
            else
            {
                radius = ObjectConstants.PatraMinionBaseOrbitRadius;
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
