using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Enemy
{
    class MegaZol : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        private Vector2 lastKnockbackVector = ObjectConstants.LeftUnitVector;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.MegaZolDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public MegaZol(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateMegaZolSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.MegaZol, (float)ObjectConstants.MegaZolMoveTime + (float)ObjectConstants.MegaZolPauseTime, ObjectConstants.MegaZolHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.MegaGel, stateMachine, this);
            invoker.ExecuteRandomCommand();
            Point colliderHitbox = new Vector2((int)(SpriteRectangles.zolFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaZolScale), (int)(SpriteRectangles.zolFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaZolScale)).ToPoint();
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), colliderHitbox));

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
                SpawnMegaGels();
            }
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            lastKnockbackVector = knockback;
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.MegaZolKnockbackTime, knockback);
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

        //----- Helper method for spawning MegaGels -----//

        private void SpawnMegaGels()
        {
            Vector2 megaGelDimensions = new Vector2((int)(SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaGelScale), (int)(SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaGelScale));
            IEnemy firstMegaGel = ObjectsFromObjectsFactory.Instance.CreateMegaGelFromMegaZol(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), megaGelDimensions));
            IEnemy secondMegaGel = ObjectsFromObjectsFactory.Instance.CreateMegaGelFromMegaZol(Position);
            if (lastKnockbackVector == ObjectConstants.RightUnitVector || lastKnockbackVector == ObjectConstants.LeftUnitVector)
            {
                firstMegaGel.GradualKnockBack(ObjectConstants.UpLeftUnitVector);
                secondMegaGel.GradualKnockBack(ObjectConstants.DownUnitVector);
            }
            else
            {
                firstMegaGel.GradualKnockBack(ObjectConstants.RightUnitVector);
                secondMegaGel.GradualKnockBack(ObjectConstants.LeftUnitVector);
            }
        }
    }
}
