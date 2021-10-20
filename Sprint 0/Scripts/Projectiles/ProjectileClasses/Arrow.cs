﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Arrow : IProjectile
    {
        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private Vector2 popOffset;
        private bool delete = false;

        private double speedPerSecond = 150.0;
        private int maxDistance = 200;
        private double silverArrowSpeedCoef = 1.5;
        private bool pop = false;
        private double popDurationSeconds = 0.2;

        public Arrow(Vector2 spawnLoc, FacingDirection direction, bool silver)
        {
            startPos = currentPos = spawnLoc;
            if (silver)
            {
                maxDistance = (int) (maxDistance * silverArrowSpeedCoef);
            }
            SetSpriteVectors(direction, silver);
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            if (!pop)
            {
                UpdateArrow(gt);
            }
            else
            {
                UpdatePop(gt);
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

        private void SetSpriteVectors(FacingDirection direction, bool silver)
        {
            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = new Vector2(1, 0);
                    popOffset = new Vector2(4, -8);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Right, silver);
                    break;
                case FacingDirection.Up:
                    directionVector = new Vector2(0, -1);
                    popOffset = new Vector2(-8, -20);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Up, silver);
                    break;
                case FacingDirection.Left:
                    directionVector = new Vector2(-1, 0);
                    popOffset = new Vector2(-20, -8);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Left, silver);
                    break;
                case FacingDirection.Down:
                    directionVector = new Vector2(0, 1);
                    popOffset = new Vector2(-8, 4);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Down, silver);
                    break;
                default:
                    break;
            }
        }

        //----- Updates methods for individual sprites -----//

        private void UpdateArrow(GameTime gt)
        {
            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            // Delete based on distance
            if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
            {
                pop = true;
                currentPos += popOffset;
                sprite = ProjectileSpriteFactory.Instance.CreateArrowPopSprite();
            }
        }

        private void UpdatePop(GameTime gt)
        {
            popDurationSeconds -= gt.ElapsedGameTime.TotalSeconds;
            if (popDurationSeconds <= 0.0)
            {
                delete = true;
            }
        }
    }
}