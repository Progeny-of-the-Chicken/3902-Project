﻿using System.Collections.Generic;
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

        public HashSet<IEnemy> patraMinions = new HashSet<IEnemy>();
        private float timeUntilNextSpawn = ObjectConstants.zero_float;
        private int remainingPatraMinionsToSpawn = ObjectConstants.PatraStartingMinionCount;

        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.PatraDamage; }

        public Vector2 Position { get => stateMachine.Location; }

        public bool CanBeAffectedByPlayer { get => !stateMachine.IsDamaged; }

        public Patra(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.CreatePatraSprite();
            stateMachine = new EnemyStateMachine(location, EnemyType.Patra, (float)ObjectConstants.PatraMoveTime, ObjectConstants.PatraStartingHealth);
            invoker = EnemyRandomInvokerFactory.Instance.CreateInvokerForEnemy(EnemyType.Patra, stateMachine, this);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.patraFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            // Minion spawning
            stateMachine.SetState(EnemyState.Movement, (float)ObjectConstants.PatraMoveTime, ObjectConstants.zeroVector);

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            stateMachine.Update(gt);
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
            stateMachine.TakeDamage(damage, true);
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
            timeUntilNextSpawn -= (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeUntilNextSpawn <= ObjectConstants.zero_float)
            {
                Vector2 center = SpawnHelper.Instance.CenterLocationOnSpawner(Position, ObjectConstants.PatraWidthHeight, ObjectConstants.PatraMinionWidthHeight);
                patraMinions.Add(ObjectsFromObjectsFactory.Instance.CreatePatraMinion(center + new Vector2(ObjectConstants.PatraMinionBaseOrbitRadius, 0), this));
                remainingPatraMinionsToSpawn--;
                timeUntilNextSpawn = (float)ObjectConstants.PatraMoveTime / ObjectConstants.PatraStartingMinionCount;
            }
        }
    }
}
