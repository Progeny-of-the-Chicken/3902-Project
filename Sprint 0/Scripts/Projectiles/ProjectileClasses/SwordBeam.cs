using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordBeam : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private Vector2 popOffset;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.swordBeamSpeedPerSecond;
        private int maxDistance = ObjectConstants.swordBeamMaxDistance;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.swordBeamDamage; }

        public IProjectileCollider Collider { get => collider; }

        public SwordBeam(Vector2 spawnLoc, FacingDirection direction)
        {
            startPos = currentPos = spawnLoc;
            SetSpriteVectors(direction);
            sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamSprite(direction);

            // TODO: Create collider
            collider = ProjectileColliderFactory.Instance.CreateArrowCollider(this, direction);
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
            // TODO: Spawn effects here
            delete = true;
        }

        // TODO: Simplify switch if it doesn't need a pop offset
        private void SetSpriteVectors(FacingDirection direction)
        {
            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = ObjectConstants.RightUnitVector;
                    popOffset = ObjectConstants.rightArrowPopOffset;
                    break;
                case FacingDirection.Up:
                    directionVector = ObjectConstants.UpUnitVector;
                    popOffset = ObjectConstants.upArrowPopOffset;
                    break;
                case FacingDirection.Left:
                    directionVector = ObjectConstants.LeftUnitVector;
                    popOffset = ObjectConstants.leftArrowPopOffset;
                    break;
                case FacingDirection.Down:
                    directionVector = ObjectConstants.DownUnitVector;
                    popOffset = ObjectConstants.downArrowPopOffset;
                    break;
                default:
                    break;
            }
        }
    }
}
