﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items.ItemClasses
{
    public class BasicKey : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public BasicKey(Vector2 spawnLoc)
        {
            sprite = ItemSpriteFactory.Instance.CreateBasicKeySprite();
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            // Deletion criteria implemented by collision logic
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
