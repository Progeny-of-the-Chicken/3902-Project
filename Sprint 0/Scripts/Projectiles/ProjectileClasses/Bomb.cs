﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Bomb : IProjectile
    {
        private ISprite sprite;
        private Vector2 pos;
        private int displacement = 50;
        private bool delete = false;
        private double startTime = 0;
        private double fuseDurationSeconds = 2.0;
        private bool explode = false;
        private double explodeDurationSeconds = 0.3;

        public Bomb(Vector2 spawnLoc, FacingDirection direction)
        {
            pos = spawnLoc;
            switch (direction)
            {
                case FacingDirection.Right:
                    pos.X += displacement;
                    break;
                case FacingDirection.Up:
                    pos.Y -= displacement;
                    break;
                case FacingDirection.Left:
                    pos.X -= displacement;
                    break;
                case FacingDirection.Down:
                    pos.Y += displacement;
                    break;
                default:
                    break;
            }
            sprite = ProjectileSpriteFactory.Instance.CreateBombSprite();
        }

        public void Update(GameTime gt)
        {
            // Animation control
            sprite.Update(gt);
            if (!explode)
            {
                UpdateBomb(gt);
            }
            else
            {
                UpdateExplode(gt);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            delete = true;
        }

        //----- Updates methods for individual sprites -----//

        private void UpdateBomb(GameTime gt)
        {
            startTime += gt.ElapsedGameTime.TotalSeconds;
            if (startTime > fuseDurationSeconds)
            {
                explode = true;
                sprite = ProjectileSpriteFactory.Instance.CreateBombExplodeSprite();
                startTime = 0.0;
            }
        }

        private void UpdateExplode(GameTime gt)
        {
            startTime += gt.ElapsedGameTime.TotalSeconds;
            if (startTime > explodeDurationSeconds)
            {
                delete = true;
            }
        }
    }
}