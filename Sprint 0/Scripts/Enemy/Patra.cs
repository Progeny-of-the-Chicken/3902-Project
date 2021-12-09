using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Enemy
{
    public class Patra : IEnemy
    {
        private ISprite sprite;
        private EnemyStateMachine stateMachine;
        private EnemyRandomInvoker invoker;
        private IEnemyCollider collider;

        private HashSet<IEnemy> patraMinions = new HashSet<IEnemy>();
        private float minionSpawningCounter = ObjectConstants.zero_float;
        private int remainingPatraMinionsToSpawn = ObjectConstants.PatraStartingMinionCount;

        public (bool extended, bool ellipse) orbitState;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.PatraDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !stateMachine.IsDamaged; }

        public Patra(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreatePatraSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Patra, (float)ObjectConstants.PatraMoveTime, ObjectConstants.PatraMoveSpeed, ObjectConstants.PatraStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Patra, stateMachine, this);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.patraFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            stateMachine.SetState(EnemyState.Movement, (float)ObjectConstants.PatraMoveTime, ObjectConstants.zeroVector);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
            // Minion spawning
            if (remainingPatraMinionsToSpawn > ObjectConstants.zero)
            {
                UpdatePatraSpawning(gt);
            }
            if (stateMachine.GetState == EnemyState.NoAction)
            {
                invoker.ExecuteRandomCommand();
            }
            sprite.Update(gt);
            collider.Update(Position);
        }

        public void TakeDamage(int damage)
        {
            if (patraMinions.Count <= 0)
            {
                stateMachine.TakeDamage(damage, true);
            }
            else
            {
                SFXManager.Instance.PlayShieldDeflect();
            }
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            // No knockback
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
            stateMachine.Displace(knockback);
        }

        public void Freeze(float duration)
        {
            stateMachine.SetState(EnemyState.Freeze, duration);
        }

        public void ToggleOrbit(double radiusChange)
        {
            foreach (IEnemy patraMinion in patraMinions)
            {
                ((PatraMinion)patraMinion).ToggleOrbit(radiusChange);
            }
        }

        public void RemovePatraMinion(IEnemy patraMinion)
        {
            patraMinions.Remove(patraMinion);
        }

        public bool CheckDelete()
        {
            return stateMachine.IsDead;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

        //----- Patra minion spawning helper -----//

        private void UpdatePatraSpawning(GameTime gt)
        {
            minionSpawningCounter += (float)gt.ElapsedGameTime.TotalSeconds;
            if (minionSpawningCounter >= (float)(ObjectConstants.PatraStartingMinionCount - remainingPatraMinionsToSpawn) / ObjectConstants.PatraStartingMinionCount)
            {
                Vector2 center = SpawnHelper.Instance.CenterLocationOnSpawner(Position, ObjectConstants.PatraWidthHeight, ObjectConstants.PatraMinionWidthHeight);
                patraMinions.Add(ObjectsFromObjectsFactory.Instance.CreatePatraMinion(center + new Vector2(ObjectConstants.PatraMinionBaseOrbitRadius, 0), this));
                remainingPatraMinionsToSpawn--;
            }
        }
    }
}
