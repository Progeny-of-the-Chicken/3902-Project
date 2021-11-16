using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordBeam : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private Vector2 explosionOffset;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.swordBeamSpeedPerSecond;
        private int maxDistance = ObjectConstants.swordBeamMaxDistance;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.swordBeamDamage; }

        public IProjectileCollider Collider { get => collider; }

        public SwordBeam(Vector2 spawnLoc, FacingDirection direction)
        {
            startPos = currentPos = SpawnHelper.Instance.CenterLocationOnLinkSword(spawnLoc, direction, new Vector2(ObjectConstants.linkWidthHeight), ObjectConstants.swordBeamWidthHeight);
            SetSpriteVectors(direction);
            sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamSprite(direction);

            collider = ProjectileColliderFactory.Instance.CreateSwordBeamCollider(this, direction);
            friendly = true;
            SFXManager.Instance.PlaySwordShoot();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            collider.Update(currentPos);

            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            // Delete based on distance
            if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
            {
                Despawn();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            ObjectsFromObjectsFactory.Instance.CreateSwordBeamExplosion(currentPos + explosionOffset);
            delete = true;
        }

        private void SetSpriteVectors(FacingDirection direction)
        {
            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = ObjectConstants.RightUnitVector;
                    explosionOffset = ObjectConstants.swordBeamExplosionRightOffset;
                    break;
                case FacingDirection.Up:
                    directionVector = ObjectConstants.UpUnitVector;
                    explosionOffset = ObjectConstants.swordBeamExplosionUpOffset;
                    break;
                case FacingDirection.Left:
                    directionVector = ObjectConstants.LeftUnitVector;
                    explosionOffset = ObjectConstants.swordBeamExplosionLeftOffset;
                    break;
                case FacingDirection.Down:
                    directionVector = ObjectConstants.DownUnitVector;
                    explosionOffset = ObjectConstants.swordBeamExplosionDownOffset;
                    break;
                default:
                    break;
            }
        }
    }
}
