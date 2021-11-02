using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Boomerang : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.boomerangSpeedPerSecond;
        private double decelPerSecond = ObjectConstants.boomerangDecelPerSecond;
        private double magicalBoomerangSpeedCoef = ObjectConstants.magicalBoomerangSpeedCoef;
        private double t = ObjectConstants.counterInitialVal_double;//TODO: more desciptive name here
        private double startT = ObjectConstants.counterInitialVal_double;
        private double tInitialOffset = ObjectConstants.boomerangTOffset;
        private double tBounceOffset = ObjectConstants.counterInitialVal_double;

        public bool ReturnState { get; set; }

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.boomerangDamage; }

        public IProjectileCollider Collider { get => collider; }

        public Boomerang(Vector2 spawnLoc, FacingDirection direction, bool magical, bool friendly)
        {
            startPos = currentPos = spawnLoc;
            if (magical)
            {
                speedPerSecond = (int)(speedPerSecond * magicalBoomerangSpeedCoef);
            }

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
                default:
                    break;
            }
            sprite = ProjectileSpriteFactory.Instance.CreateBoomerangSprite(magical);

            collider = ProjectileColliderFactory.Instance.CreateBoomerangCollider(this);
            this.friendly = friendly;
            ReturnState = false;
        }

        public void Update(GameTime gt)
        {
            // Movement control
            sprite.Update(gt);
            if (startT == ObjectConstants.counterInitialVal_double)
            {
                startT = gt.TotalGameTime.TotalSeconds;
            }
            t = gt.TotalGameTime.TotalSeconds - startT + tInitialOffset + tBounceOffset;
            double posChange = (t * speedPerSecond + t * t * decelPerSecond);
            currentPos += directionVector * (float)posChange;
            if (!ReturnState && (posChange < ObjectConstants.zero_double))
            {
                ReturnState = true;
            }
            collider.Update(currentPos);
            // Delete on boomerang return
            if (directionVector.X * (currentPos.X - startPos.X) < ObjectConstants.zero_float || directionVector.Y * (currentPos.Y - startPos.Y) < ObjectConstants.zero_float)
            {
                delete = true;
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
            delete = true;
        }

        public void BounceOffWall()
        {
            ReturnState = true;
            tBounceOffset = ObjectConstants.doubleTheValue * Math.Abs(t - (speedPerSecond / (ObjectConstants.adjustByNegativeOne * decelPerSecond)));
        }
    }
}
