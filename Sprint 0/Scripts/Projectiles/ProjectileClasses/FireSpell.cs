using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class FireSpell : IProjectile
    {
        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;

        private bool linger = false;
        private double speedPerSecond = 150.0;
        private int maxDistance = 200;
        private double startLingerTime = 0;
        private double lingerDuration = 2.0;

        public FireSpell(Vector2 spawnLoc, FacingDirection direction)
        {
            startPos = currentPos = spawnLoc;
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
            sprite = ProjectileSpriteFactory.Instance.CreateFireSpellSprite();
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
            startLingerTime += gt.ElapsedGameTime.TotalSeconds;
            if (startLingerTime > lingerDuration)
            {
                delete = true;
            }
        }
    }
}
