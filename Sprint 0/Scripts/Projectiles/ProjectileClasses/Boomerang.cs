using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Boomerang : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.boomerangSpeedPerSecond;
        private double decelPerSecond = ObjectConstants.boomerangDecelPerSecond;
        private double magicalBoomerangSpeedCoef = ObjectConstants.magicalBoomerangSpeedCoef;
        private double returnSpeedPerSecond = ObjectConstants.boomerangReturnSpeedPerSecond;
        private double startT = ObjectConstants.counterInitialVal_double;
        private double tInitialOffset = ObjectConstants.boomerangTOffset;
        private Link linkOwner;
        private IEnemy enemyOwner;

        public bool ReturnState { get; set; }

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.boomerangDamage; }

        public IProjectileCollider Collider { get => collider; }

        public Boomerang(Vector2 spawnLoc, FacingDirection direction, bool magical, Link link)
        {
            linkOwner = link;
            friendly = true;
            InitializeObject(spawnLoc, direction, magical);
            SFXManager.Instance.PlayFireArrowBoomerang();
        }
        public Boomerang(Vector2 spawnLoc, FacingDirection direction, bool magical, IEnemy enemy)
        {
            enemyOwner = enemy;
            friendly = false;
            InitializeObject(spawnLoc, direction, magical);
        }

        public void Update(GameTime gt)
        {
            // Movement control
            sprite.Update(gt);
            if (startT == ObjectConstants.counterInitialVal_double)
            {
                startT = gt.TotalGameTime.TotalSeconds;
            }
            if (!ReturnState)
            {
                ThrowUpdate(gt);
            }
            else
            {
                ReturnUpdate(gt);
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

        public void Despawn()
        {
            if (Friendly)
            {
                Link.Instance.BoomerangReady = true;
            }
            delete = true;
        }

        public void BounceOffWall()
        {
            ReturnState = true;
        }

        //----- Helper methods for boomerang state -----//

        private void InitializeObject(Vector2 spawnLoc, FacingDirection direction, bool magical)
        {
            currentPos = (ObjectConstants.boomerangRotationOffset * ObjectConstants.scale) + SpawnHelper.Instance.CenterLocationOnSpawner(spawnLoc, new Vector2(ObjectConstants.linkWidthHeight), new Vector2(ObjectConstants.boomerangWidthHeight));
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
            ReturnState = false;
        }

        private void ThrowUpdate(GameTime gt)
        {
            double t = gt.TotalGameTime.TotalSeconds - startT + tInitialOffset;
            double posChange = (t * speedPerSecond + t * t * decelPerSecond);
            currentPos += directionVector * (float)posChange;
            if (!ReturnState && (posChange < ObjectConstants.zero_double))
            {
                ReturnState = true;
            }
        }

        private void ReturnUpdate(GameTime gt)
        {
            Vector2 distanceVector;
            if (friendly)
            {
                distanceVector = SpawnHelper.Instance.CenterLocationOnSpawner(linkOwner.Position, new Vector2(ObjectConstants.linkWidthHeight), new Vector2(ObjectConstants.boomerangWidthHeight)) - currentPos;
            }
            else
            {
                distanceVector = SpawnHelper.Instance.CenterLocationOnSpawner(enemyOwner.Position, enemyOwner.Collider.Hitbox.Size.ToVector2(), new Vector2(ObjectConstants.boomerangWidthHeight))  - currentPos;
            }
            Vector2 abs = new Vector2(Math.Abs(distanceVector.X), Math.Abs(distanceVector.Y));
            Vector2 xyScale = new Vector2(distanceVector.X / (abs.X + abs.Y), distanceVector.Y / (abs.X + abs.Y));
            currentPos += new Vector2((float)returnSpeedPerSecond) * xyScale;
        }
    }
}
