using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class FireSpell : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.fireSpellSpeedPerSecond;
        private int maxDistance = ObjectConstants.fireSpellMaxDistance;
        private double lingerDuration = ObjectConstants.fireSpellLingerDuration;

        public bool linger = false;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.fireSpellDamage; }

        public IProjectileCollider Collider { get => collider; }

        public FireSpell(Vector2 spawnLoc, FacingDirection direction)
        {
            startPos = currentPos = SpawnHelper.Instance.CenterLocationOnSpawner(spawnLoc, new Vector2(ObjectConstants.linkWidthHeight), new Vector2(ObjectConstants.fireSpellWidthHeight));
            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = ObjectConstants.RightUnitVector;
                    break;
                case FacingDirection.Up:
                    directionVector = ObjectConstants.UpUnitVector;
                    break;
                case FacingDirection.Left:
                    directionVector = ObjectConstants.LeftUnitVector;
                    break;
                case FacingDirection.Down:
                    directionVector = ObjectConstants.DownUnitVector;
                    break;
                case FacingDirection.None:
                    directionVector = ObjectConstants.zeroVector;
                    break;
                default:
                    break;
            }
            sprite = ProjectileSpriteFactory.Instance.CreateFireSpellSprite();

            collider = ProjectileColliderFactory.Instance.CreateFireSpellCollider(this);
            friendly = true;
            SFXManager.Instance.PlayFireCandle();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            if (!linger)
            {
                UpdateFireSpellMotion(gt);
            }
            else
            {
                UpdateFireSpellLinger(gt);
            }
            collider.Update(currentPos);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        //----- Updates methods for individual sprites -----//

        private void UpdateFireSpellMotion(GameTime gt)
        {
            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            // Distance based
            if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
            {
                linger = true;
            }
        }

        private void UpdateFireSpellLinger(GameTime gt)
        {
            lingerDuration -= gt.ElapsedGameTime.TotalSeconds;
            if (lingerDuration <= ObjectConstants.zero_double)
            {
                delete = true;
            }
        }

        public void Despawn()
        {
            delete = true;
        }
    }
}
