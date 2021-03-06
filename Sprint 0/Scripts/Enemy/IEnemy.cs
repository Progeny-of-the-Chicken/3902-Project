using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    public interface IEnemy
    {
        public int Damage { get; }
        public IEnemyCollider Collider { get; }
        public Vector2 Position { get; }
        public bool CanBeAffectedByPlayer { get; }
        public void Update(GameTime t);

        void Draw(SpriteBatch sb);

        public void TakeDamage(int damage);

        public void SuddenKnockBack(Vector2 knockback);

        public void GradualKnockBack(Vector2 knockback);

        public void Freeze(float duration);

        public void ChangeDirection();

        public bool CheckDelete();
    }
}
