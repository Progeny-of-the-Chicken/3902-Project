using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Commands.EnemyAbilities;

namespace Sprint_0.Scripts.Enemy
{
    public class Aquamentus : IEnemy
    {
        private ISprite sprite;
        private ISprite moveSprite;
        private ISprite shootSprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private ICommand shootCommand;
        private IEnemyCollider collider;

        private (int left, int right) movementBarrier;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.AquamentusDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Aquamentus(Vector2 location)
        {
            movementBarrier = ((int)location.X - ObjectConstants.AquamentusBarrierLength, (int)location.X + ObjectConstants.AquamentusBarrierLength);

            moveSprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite();
            shootSprite = EnemySpriteFactory.Instance.CreateAquamentusShootSprite();
            sprite = moveSprite;

            stateMachine = new EnemyStateMachine(location, EnemyType.Aquamentus, (float)ObjectConstants.AquamentusMoveTime, ObjectConstants.AquamentusMoveSpeed, ObjectConstants.AquamentusStartingHealth);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.aquamentusMoveFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Aquamentus, stateMachine, this);
            invoker.ExecuteRandomCommand();
            shootCommand = new CommandShootThreeMagicProjectileSpread(stateMachine);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
            SFXManager.Instance.PlayBossScream1();
        }
        public void Update(GameTime t)
        {
            stateMachine.Update(t);
            FitToBarrier();
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
                shootCommand.Execute();
            }
            if (stateMachine.StateChange)
            {
                if (stateMachine.GetState == EnemyState.Movement)
                {
                    sprite = moveSprite;
                }
                else
                {
                    sprite = shootSprite;
                }
            }
            sprite.Update(t);
            collider.Update(Position);
        }
        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, true);
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //Aquamentus doesn't get knocked back when hit
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
            sprite.Draw(sb, stateMachine.Location);
        }

        //----- Helper for restricting movement -----//

        private void FitToBarrier()
        {
            if (Position.X < movementBarrier.left)
            {
                stateMachine.Displace(new Vector2(movementBarrier.left - Position.X, 0));
                ChangeDirection();
            }
            else if (Position.X > movementBarrier.right)
            {
                stateMachine.Displace(ObjectConstants.adjustByNegativeOne * new Vector2(Position.X - movementBarrier.right, 0));
                ChangeDirection();
            }
        }
    }
}
