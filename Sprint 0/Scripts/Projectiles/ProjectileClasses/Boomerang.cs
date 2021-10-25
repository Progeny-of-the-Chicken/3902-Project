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
        private double t = 0;
        private double startT = 0;
        private double tInitialOffset = ObjectConstants.boomerangTOffset;
        private double tBounceOffset = 0;

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
                    directionVector = new Vector2(1, 0);
                    break;
                case FacingDirection.Up:
                    directionVector = new Vector2(0, -1);
                    break;
                case FacingDirection.Left:
                    directionVector = new Vector2(-1, 0);
                    break;
                case FacingDirection.Down:
                    directionVector = new Vector2(0, 1);
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
            if (startT == 0)
            {
                startT = gt.TotalGameTime.TotalSeconds;
            }
            t = gt.TotalGameTime.TotalSeconds - startT + tInitialOffset + tBounceOffset;
            double posChange = (t * speedPerSecond + t * t * decelPerSecond);
            currentPos += directionVector * (float)posChange;
            if (!ReturnState && (posChange < 0))
            {
                ReturnState = true;
            }
            collider.Update(currentPos);
            // Delete on boomerang return
            if (directionVector.X * (currentPos.X - startPos.X) < 0 || directionVector.Y * (currentPos.Y - startPos.Y) < 0)
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
            tBounceOffset = 2 * Math.Abs(t - (speedPerSecond / (-1 * decelPerSecond)));
        }
    }
}
