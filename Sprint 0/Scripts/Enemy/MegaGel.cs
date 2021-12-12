using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Enemy
{
    class MegaGel : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        private Vector2 lastKnockbackVector = ObjectConstants.LeftUnitVector;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.MegaGelDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public MegaGel(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreateMegaGelSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.MegaGel, (float)ObjectConstants.MegaGelMoveTime + (float)ObjectConstants.MegaGelPauseTime, ObjectConstants.MegaGelHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.MegaGel, stateMachine, this);
            invoker.ExecuteRandomCommand();
            Point colliderHitbox = new Vector2((int)(SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2().X * ObjectConstants.MegaGelScale), (int)(SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2().Y * ObjectConstants.MegaGelScale)).ToPoint();
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
                SpawnZols();
            }
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            knockback.Normalize();
            lastKnockbackVector = knockback;
            stateMachine.SetState(EnemyState.Knockback, (float)ObjectConstants.MegaGelKnockbackTime, knockback);
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

        //----- Helper method for spawning Zols -----//

        private void SpawnZols()
        {
            IEnemy firstZol = ObjectsFromObjectsFactory.Instance.CreateZolFromMegaGel(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), SpriteRectangles.zolFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale));
            IEnemy secondZol = ObjectsFromObjectsFactory.Instance.CreateZolFromMegaGel(SpawnHelper.Instance.CenterLocationOnSpawner(Position, collider.Hitbox.Size.ToVector2(), SpriteRectangles.zolFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale));
            if (lastKnockbackVector == ObjectConstants.RightUnitVector || lastKnockbackVector == ObjectConstants.LeftUnitVector)
            {
                firstZol.GradualKnockBack(ObjectConstants.UpLeftUnitVector);
                secondZol.GradualKnockBack(ObjectConstants.DownUnitVector);
            }
            else
            {
                firstZol.GradualKnockBack(ObjectConstants.RightUnitVector);
                secondZol.GradualKnockBack(ObjectConstants.LeftUnitVector);
            }
        }
    }
}
