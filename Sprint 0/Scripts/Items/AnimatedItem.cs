using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class AnimatedItem : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public AnimatedItem(ISprite itemSprite, Vector2 spawnLoc)
        {
            sprite = itemSprite;
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            // No deletion criteria
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
