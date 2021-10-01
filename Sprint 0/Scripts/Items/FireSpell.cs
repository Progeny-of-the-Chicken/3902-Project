﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class FireSpell : IItem
    {
        public enum Direction { RIGHT, UP, LEFT, DOWN }

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

        public FireSpell(Texture2D spritesheet, Vector2 spawnLoc, Direction dir)
        {
            startPos = currentPos = spawnLoc;
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
            sprite = new FireSpellSprite(spritesheet);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (!linger)
            {
                currentPos += directionVector * (float)(gameTime.ElapsedGameTime.TotalSeconds * speedPerSecond);
                // Distance based
                if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
                {
                    linger = true;
                }
            }
            else
            {
                startLingerTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (startLingerTime > lingerDuration)
                {
                    delete = true;
                }
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
