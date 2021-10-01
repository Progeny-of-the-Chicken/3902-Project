using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class Boomerang : IItem
    {
        public enum Direction { RIGHT, UP, LEFT, DOWN }

        private ISprite sprite;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private bool delete = false;

        private double speedPerSecond = 10.0;
        private double decelPerSecond = -5.0;
        private double magicalBoomerangSpeedCoef = 2.0;
        private double startT = 0;
        private double tOffset = 1;

        public Boomerang(Texture2D spritesheet, Vector2 spawnLoc, Direction dir, bool magical)
        {
            startPos = currentPos = spawnLoc;
            if (magical)
            {
                speedPerSecond = (int)(speedPerSecond * magicalBoomerangSpeedCoef);
            }

            switch (dir)
            {
                case Direction.RIGHT:
                    directionVector = new Vector2(1, 0);
                    break;
                case Direction.UP:
                    directionVector = new Vector2(0, 1);
                    break;
                case Direction.LEFT:
                    directionVector = new Vector2(-1, 0);
                    break;
                case Direction.DOWN:
                    directionVector = new Vector2(0, -1);
                    break;
                default:
                    break;
            }
            sprite = new BoomerangSprite(spritesheet, magical);
        }

        public void Update(GameTime gameTime)
        {
            // Movement control
            sprite.Update(gameTime);
            if (startT == 0)
            {
                startT = gameTime.TotalGameTime.TotalSeconds;
            }
            double t = gameTime.TotalGameTime.TotalSeconds - startT + tOffset;
            currentPos += directionVector * (float)(t * speedPerSecond + t * t * decelPerSecond);
            // Delete on boomerang return
            if (directionVector.X * (currentPos.X - startPos.X) < 0 || directionVector.Y * (currentPos.Y - startPos.Y) < 0)
            {
                delete = true;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            sprite.Draw(_spriteBatch, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
