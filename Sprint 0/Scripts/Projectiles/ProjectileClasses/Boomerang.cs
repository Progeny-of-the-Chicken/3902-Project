using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Enemy;

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
        private double startT = 0;
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
            if (startT == 0)
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
            // Delete on boomerang return
            // TODO: Delete this after properly despawned by thrower
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
        }

        //----- Helper methods for boomerang state -----//

        private void InitializeObject(Vector2 spawnLoc, FacingDirection direction, bool magical)
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
            ReturnState = false;
        }

        private void ThrowUpdate(GameTime gt)
        {
            double t = gt.TotalGameTime.TotalSeconds - startT + tInitialOffset;
            double posChange = (t * speedPerSecond + t * t * decelPerSecond);
            currentPos += directionVector * (float)posChange;
            if (!ReturnState && (posChange < 0))
            {
                ReturnState = true;
            }
        }

        private void ReturnUpdate(GameTime gt)
        {
            Vector2 distanceVector;
            if (friendly)
            {
                distanceVector = linkOwner.Position - currentPos;
            }
            else
            {
                distanceVector = enemyOwner.Collider.Hitbox.Location.ToVector2() - currentPos;
            }
            Vector2 abs = new Vector2(Math.Abs(distanceVector.X), Math.Abs(distanceVector.Y));
            Vector2 xyScale = new Vector2(distanceVector.X / (abs.X + abs.Y), distanceVector.Y / (abs.X + abs.Y));
            currentPos += new Vector2((float)speedPerSecond) * xyScale;
            // currentPos -= directionVector * (float)((gt.TotalGameTime.TotalSeconds - startT) * speedPerSecond);
        }
    }
}
