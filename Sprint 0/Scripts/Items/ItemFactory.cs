using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Items
{
    public class ItemFactory
    {
        private static ItemFactory instance = new ItemFactory();

        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemFactory()
        {
        }

        public IItem CreateArrow(Vector2 location, Arrow.Direction direction, bool silver)
        {
            return new Arrow(location, direction, silver);
        }

        public IItem CreateBoomerang(Vector2 location, Boomerang.Direction direction, bool magical)
        {
            return new Boomerang(location, direction, magical);
        }

        public IItem CreateBomb(Vector2 location, Bomb.Direction direction)
        {
            return new Bomb(location, direction);
        }

        public IItem CreateFireSpell(Vector2 location, FireSpell.Direction direction)
        {
            return new FireSpell(location, direction);
        }
    }
}
