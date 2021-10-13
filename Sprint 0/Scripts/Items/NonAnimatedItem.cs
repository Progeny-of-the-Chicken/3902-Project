using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class NonAnimatedItem : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public NonAnimatedItem(ISprite itemSprite, Vector2 spawnLoc)
        {
            sprite = itemSprite;
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            // No animation
            sprite.Update(gt);
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
