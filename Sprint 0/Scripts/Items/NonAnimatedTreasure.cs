using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class NonAnimatedTreasure : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public NonAnimatedTreasure(ISprite treasureSprite, Vector2 spawnLoc)
        {
            sprite = treasureSprite;
            pos = spawnLoc;
            delete = false;
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
