using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Items
{
    public class ItemEntities
    {
        public HashSet<IItem> items;

        public HashSet<IItem> itemSet { get => items; }

        public ItemEntities()
        {
            items = new HashSet<IItem>();
        }

        public void Update(GameTime gameTime)
        {
            HashSet<IItem> itemsToRemove = new HashSet<IItem>();
            foreach (IItem item in items)
            {
                item.Update(gameTime);
                if (item.CheckDelete())
                {
                    itemsToRemove.Add(item);
                }

            }
            foreach (IItem item in itemsToRemove)
            {
                items.Remove(item);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (IItem item in items)
            {
                item.Draw(_spriteBatch);
            }
        }

        public void Add(IItem item)
        {
            items.Add(item);
        }
    }
}
