using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Items
{
    public class ItemEntities
    {
        private Game1 game;
        public HashSet<IItem> items;

        public TreasureCycle sprint2Cycle;
        public IItem sprint2Item;

        public ItemEntities(Game1 game)
        {
            this.game = game;
            items = new HashSet<IItem>();

            sprint2Cycle = new TreasureCycle(game.GetCenterScreen());
        }

        public void Update(GameTime gameTime)
        {
            HashSet<IItem> itemsToRemove = new HashSet<IItem>();
            foreach (IItem item in items)
            {
                if (item.Update(gameTime))
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (IItem item in itemsToRemove)
            {
                items.Remove(item);
            }

            sprint2Item.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (IItem item in items)
            {
                item.Draw(_spriteBatch);
            }

            sprint2Item.Draw(_spriteBatch);
        }
    }
}
