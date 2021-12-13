using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class Manhandla : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;
        private HashSet<IEnemy> headSet = new HashSet<IEnemy>();

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.ManhandlaHeadDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Manhandla(Vector2 location)
        {
            InitializeHeads(location);
            sprite = EnemySpriteFactory.Instance.CreateManhandlaBodySprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Manhandla, (float)ObjectConstants.ManhandlaMoveTime, ObjectConstants.ManhandlaMoveSpeed, ObjectConstants.ManhandlaPlaceholderHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Manhandla, stateMachine, this);
            invoker.ExecuteRandomCommand();
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), new Point(ObjectConstants.ManhandlaComponentWidthHeight)));
            
            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }
            sprite.Update(gt);
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            // Does not take damage to body
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // Does not take knockback
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
            foreach (IEnemy head in headSet)
            {
                ((ManhandlaHead)head).DisplaceWithBody(knockback);
            }
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public void RemoveHead(IEnemy head)
        {
            headSet.Remove(head);
            stateMachine.moveSpeed += ObjectConstants.ManhandlaSpeedPerDeadHead;
            stateMachine.moveTime = ObjectConstants.ManhandlaMoveSpeed / stateMachine.moveSpeed;
        }

        public bool CheckDelete()
        {
            return headSet.Count == ObjectConstants.zero;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

        //----- Helper method for generating heads -----//

        private void InitializeHeads(Vector2 location)
        {
            headSet.Add(ObjectsFromObjectsFactory.Instance.CreateManhandlaHead(location, FacingDirection.Right, this));
            headSet.Add(ObjectsFromObjectsFactory.Instance.CreateManhandlaHead(location, FacingDirection.Up, this));
            headSet.Add(ObjectsFromObjectsFactory.Instance.CreateManhandlaHead(location, FacingDirection.Left, this));
            headSet.Add(ObjectsFromObjectsFactory.Instance.CreateManhandlaHead(location, FacingDirection.Down, this));
        }
    }
}
