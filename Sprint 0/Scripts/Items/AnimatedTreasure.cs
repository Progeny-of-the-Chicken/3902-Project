using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class AnimatedTreasure : IItem
    {
        private ISprite sprite;
        private Vector2 location;
        private bool delete = false;

        public AnimatedTreasure(ISprite treasureType, Vector2 spawnLoc)
        {
            sprite = treasureType;
            location = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            // No deletion criteria
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
