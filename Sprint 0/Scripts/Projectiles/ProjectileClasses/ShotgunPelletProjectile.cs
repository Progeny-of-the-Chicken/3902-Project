using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class ShotgunPelletProjectile : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.shotgunPelletSpeed;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.shotgunPelletDamage; }

        public IProjectileCollider Collider { get => collider; }

        public ShotgunPelletProjectile(Vector2 spawnLoc, FacingDirection direction)
        {
            currentPos = SpawnHelper.Instance.CenterLocationForShotgunBlast(spawnLoc, direction);
            SetSpriteVectors(direction);

            collider = ProjectileColliderFactory.Instance.CreateShotgunPelletCollider(this, direction);
            friendly = true;
            //TODO:Shotgun sound effect?
            SFXManager.Instance.PlayShotgunBang();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            collider.Update(currentPos);

            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
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
            delete = true;
        }

        private void SetSpriteVectors(FacingDirection direction)
        {

            Random rand = new Random();
            float randPrimaryAdjustment = (float)(rand.NextDouble() - ObjectConstants.halfAdjustment);
            float randSecondaryAdjustment = (float)(rand.NextDouble());

            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = ObjectConstants.RightUnitVector;
                    directionVector.X += randSecondaryAdjustment;
                    directionVector.Y += randPrimaryAdjustment;
                    break;
                case FacingDirection.Up:
                    directionVector = ObjectConstants.UpUnitVector;
                    directionVector.Y -= randSecondaryAdjustment;
                    directionVector.X += randPrimaryAdjustment;
                    break;
                case FacingDirection.Left:
                    directionVector = ObjectConstants.LeftUnitVector;
                    directionVector.X -= randSecondaryAdjustment;
                    directionVector.Y += randPrimaryAdjustment;
                    break;
                case FacingDirection.Down:
                    directionVector = ObjectConstants.DownUnitVector;
                    directionVector.Y += randSecondaryAdjustment;
                    directionVector.X += randPrimaryAdjustment;
                    break;
                default:
                    break;
            }
            sprite = ProjectileSpriteFactory.Instance.CreateShotgunPelletSprite(direction);
        }
    }
}
