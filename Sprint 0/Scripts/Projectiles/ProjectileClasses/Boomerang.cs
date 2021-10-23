using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Boomerang : IProjectile
    {
        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;

        private double speedPerSecond = ObjectConstants.boomerangSpeedPerSecond;
        private double decelPerSecond = ObjectConstants.boomerangDecelPerSecond;
        private double magicalBoomerangSpeedCoef = ObjectConstants.magicalBoomerangSpeedCoef;
        private double startT = 0;
        private double tOffset = ObjectConstants.boomerangTOffset;

        public int damage { get => ObjectConstants.boomerangDamage; }

        public Boomerang(Vector2 spawnLoc, FacingDirection direction, bool magical)
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
        }

        public void Update(GameTime gt)
        {
            // Movement control
            sprite.Update(gt);
            if (startT == 0)
            {
                startT = gt.TotalGameTime.TotalSeconds;
            }
            double t = gt.TotalGameTime.TotalSeconds - startT + tOffset;
            currentPos += directionVector * (float)(t * speedPerSecond + t * t * decelPerSecond);
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
            // Should never need to be called
            delete = true;
        }
    }
}
