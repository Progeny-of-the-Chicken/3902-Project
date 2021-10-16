using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items.ItemClasses
{
    public class Fairy : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public Fairy(Vector2 spawnLoc)
        {
            sprite = ItemSpriteFactory.Instance.CreateFairySprite();
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
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

        public void Despawn()
        {
            delete = true;
        }
    }
}
