﻿using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using System.Collections.Generic;

namespace Sprint_0.Scripts.Enemy
{
    public class Dodongo : IEnemy
    {
        ISprite sprite;

        public IEnemyCollider Collider { get => dependency.collider; }
        public IEnemyCollider DetectionCollider { get => detectionCollider; }
        IEnemyCollider detectionCollider;

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;
        public int Damage { get => ObjectConstants.DodongoDamage; }
        int health = ObjectConstants.DodongoStartingHealth;
        bool delete = false;
        bool stunned = false;
        
        FacingDirection direction;
        Vector2 location;
        (Vector2 directionVector, ISprite walkSprite, ISprite explodeSprite, IEnemyCollider collider) dependency;

        Dictionary<FacingDirection, (Vector2, ISprite, ISprite, IEnemyCollider)> directionDependencies;

        public Dodongo(Vector2 location)
        {
            this.location = location;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            
            directionDependencies = new Dictionary<FacingDirection, (Vector2, ISprite, ISprite, IEnemyCollider)>();
            GenericEnemyCollider HCollision = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.dodongoRightFrames[ObjectConstants.firstInArray].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            GenericEnemyCollider VCollision = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.dodongoDownFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            directionDependencies.Add(FacingDirection.Right, (ObjectConstants.RightUnitVector, EnemySpriteFactory.Instance.CreateDodongoRightSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeRightSprite(), HCollision));
            directionDependencies.Add(FacingDirection.Left, (ObjectConstants.LeftUnitVector, EnemySpriteFactory.Instance.CreateDodongoLeftSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeLeftSprite(), HCollision));
            directionDependencies.Add(FacingDirection.Up, (ObjectConstants.UpUnitVector, EnemySpriteFactory.Instance.CreateDodongoUpSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeUpSprite(), VCollision));
            directionDependencies.Add(FacingDirection.Down, (ObjectConstants.DownUnitVector, EnemySpriteFactory.Instance.CreateDodongoDownSprite(), EnemySpriteFactory.Instance.CreateDodongoExplodeDownSprite(), VCollision));
            SetRandomDirection();
            detectionCollider = new DodongoDetectionCollider(this, new Rectangle((location + dependency.directionVector * ObjectConstants.scaledStdWidthHeight).ToPoint(), (Vector2.One * ObjectConstants.scaledStdWidthHeight).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            if (!stunned)
            {
                Move(gt);
            }
            else
            {
                GetKnockedBack(gt);
            }
            sprite.Update(gt);
            dependency.collider.Update(location);
            if (direction == FacingDirection.Right) 
                detectionCollider.Update(location + Vector2.UnitX * SpriteRectangles.dodongoRightFrames[ObjectConstants.firstFrame].Width * ObjectConstants.scale);
            else 
                detectionCollider.Update(location + dependency.directionVector * ObjectConstants.scaledStdWidthHeight);
        }

        void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= ObjectConstants.DodongoMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            location += dependency.directionVector * ObjectConstants.DodongoMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        void GetKnockedBack(GameTime t)
        {
            timeSinceKnockback += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceKnockback >= ObjectConstants.DodongoStunTime)
            {
                stunned = false;
                timeSinceKnockback = 0;
                sprite = dependency.walkSprite;
            }
        }


        void SetRandomDirection()
        {
            randomDir.GetBytes(random);
            direction = (FacingDirection)(random[ObjectConstants.firstInArray] % ObjectConstants.oneInFour);
            directionDependencies.TryGetValue(direction, out dependency);
            sprite = dependency.walkSprite;
        }
        public void TakeDamage(int damage)
        {
            if (stunned)
            {
                health -= damage;
                if (health <= ObjectConstants.zero)
                {
                    ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Pop);
                    delete = true;
                    SFXManager.Instance.PlayBossScream1();
                }
                SFXManager.Instance.PlayBossHit();
            }
            else
            {
                SFXManager.Instance.PlayShieldDeflect();
            }
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //Unused
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public void Stun()
        {
            stunned = true;
            TakeDamage(ObjectConstants.basicSwordDamage);
            sprite = dependency.explodeSprite;
        }
        public bool CheckDelete()
        {
            return delete;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}