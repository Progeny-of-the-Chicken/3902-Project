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
        private ISprite bodySprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;
        private HashSet<(Vector2 offset, ISprite sprite, IEnemyCollider collider)> headSet = new HashSet<(Vector2 offset, ISprite sprite, IEnemyCollider collider)>();

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.ManhandlaHeadDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !(stateMachine.IsDamaged || stateMachine.GetState == EnemyState.Knockback); }

        public Manhandla(Vector2 location)
        {
            bodySprite = EnemySpriteFactory.Instance.CreateManhandlaBodySprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Manhandla, (float)ObjectConstants.ManhandlaMoveTime, ObjectConstants.ManhandlaPlaceholderHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Manhandla, stateMachine, this);
            invoker.ExecuteRandomCommand();

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), new Point(ObjectConstants.ManhandlaComponentWidthHeight)));
            InitializeHeads(location);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }

            if (stateMachine.GetState != EnemyState.Knockback)
            {
                bodySprite.Update(gt);
            }
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
            // TODO: Displace heads too
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
            bodySprite.Draw(sb, Position);
        }

        //----- Helper method for generating heads -----//

        private void InitializeHeads(Vector2 location)
        {
            Point headSize = new Vector2(ObjectConstants.ManhandlaComponentWidthHeight).ToPoint();
            Vector2 headLocation = location * ObjectConstants.RightUnitVector;
            headSet.Add((headLocation, EnemySpriteFactory.Instance.CreateManhandlaRightHeadSprite(), new GenericEnemyCollider(this, new Rectangle(headLocation.ToPoint(), headSize))));
            headLocation = location * ObjectConstants.UpUnitVector;
            headSet.Add((headLocation, EnemySpriteFactory.Instance.CreateManhandlaUpHeadSprite(), new GenericEnemyCollider(this, new Rectangle(headLocation.ToPoint(), headSize))));
            headLocation = location * ObjectConstants.LeftUnitVector;
            headSet.Add((headLocation, EnemySpriteFactory.Instance.CreateManhandlaLeftHeadSprite(), new GenericEnemyCollider(this, new Rectangle(headLocation.ToPoint(), headSize))));
            headLocation = location * ObjectConstants.DownUnitVector;
            headSet.Add((headLocation, EnemySpriteFactory.Instance.CreateManhandlaDownHeadSprite(), new GenericEnemyCollider(this, new Rectangle(headLocation.ToPoint(), headSize))));
        }
    }
}
