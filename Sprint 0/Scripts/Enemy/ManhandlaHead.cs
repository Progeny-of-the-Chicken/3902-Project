using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class ManhandlaHead : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyMoveAndShootInvoker invoker;
        private IEnemyCollider collider;
        private IEnemy manhandla;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.ManhandlaHeadDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public ManhandlaHead(Vector2 location, FacingDirection side, IEnemy manhandla)
        {
            this.manhandla = manhandla;
            sprite = GetSpriteForSide(side);
            stateMachine = new EnemyStateMachine(location, EnemyType.ManhandlaHead, (float)ObjectConstants.ManhandlaMoveTime, ObjectConstants.ManhandlaHeadHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateMoveAndShootInvokerForEnemy(EnemyType.ManhandlaHead, stateMachine, this);
            invoker.ExecuteRandomMoveCommand();

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), new Point(ObjectConstants.ManhandlaComponentWidthHeight)));
            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomMoveCommand();
                invoker.ExecuteAbility();
            }
            if (!stateMachine.IsDamaged)
            {
                sprite.Update(gt);
            }
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage, true);
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // Does not take knockback
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            manhandla.SuddenKnockBack(knockback);
        }

        public void DisplaceWithBody(Vector2 knockback)
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

        //----- Helper method for sprite initialization -----//

        private ISprite GetSpriteForSide(FacingDirection side)
        {
            return side switch
            {
                FacingDirection.Right => EnemySpriteFactory.Instance.CreateManhandlaRightHeadSprite(),
                FacingDirection.Up => EnemySpriteFactory.Instance.CreateManhandlaUpHeadSprite(),
                FacingDirection.Left => EnemySpriteFactory.Instance.CreateManhandlaLeftHeadSprite(),
                FacingDirection.Down => EnemySpriteFactory.Instance.CreateManhandlaDownHeadSprite(),
                // Should never happen
                _ => EnemySpriteFactory.Instance.CreateManhandlaRightHeadSprite()
            };
        }
    }
}
