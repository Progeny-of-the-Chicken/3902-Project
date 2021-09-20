using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public enum Item { Sword, Arrow, Boomerang, Bomb, Fire, None };
    public enum Direction { Up, Down, Left, Right };
    class Link : ILink
    {
        ISprite LinkSprite;
        LinkStateMachine linkState;
        private int linkHealth;
        private const int linkStartingHealth = 3;

        public Link()
        {
            linkState = new LinkStateMachine();
            linkHealth = linkStartingHealth;
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            LinkSprite.Draw(sb, gt);
        }

        public void LoadContent(ContentManager cm)
        {
            LinkSprite.LoadContent(cm);
        }

        public void Update()
        {
            linkState.Update();
        }

        public void GoLeft()
        {
            linkState.GoLeft();
        }

        public void GoRight()
        {
            linkState.GoRight();
        }

        public void GoUp()
        {
            linkState.GoUp();
        }

        public void GoDown()
        {
            linkState.GoDown();
        }

        public void NotMoving()
        {
            linkState.NotMoving();
        }

        public void TakeDamage()
        {
            if (!linkState.IsTakingDamage)
            {
                linkHealth--;
                linkState.TakeDamage();
            }
        }
        
        public void UseSword()
        {
            if(linkState.WhichItemIsBeingUsed == Item.None)
            {
                linkState.UseSword();
            }
        }
        
        public void UseArrow()
        {
            if(linkState.WhichItemIsBeingUsed == Item.None)
            {
                linkState.UseArrow();
            }
        }
        
        public void UseBoomerang()
        {
            if(linkState.WhichItemIsBeingUsed == Item.None)
            {
                linkState.UseBoomerang();
            }
        }
        
        public void UseBomb()
        {
            if(linkState.WhichItemIsBeingUsed == Item.None)
            {
                linkState.UseBomb();
            }
        }
        
        public void UseFire()
        {
            if(linkState.WhichItemIsBeingUsed == Item.None)
            {
                linkState.UseFire();
            }
        }

        
    }

    public class LinkStateMachine
    {
        private Direction linksDirection;
        private bool isMoving;
        private int damageCounter;
        private int usingItemCounter;
        private Item itemBeingUsed;
        private Vector2 linksPosition;
        private const int linkSpeed = 1;

        public LinkStateMachine()
        {
            linksDirection = Direction.Down;
            isMoving = false;
            damageCounter = 0;
            usingItemCounter = 0;
            itemBeingUsed = Item.None;
            linksPosition = new Vector2(200, 200); //generic starting position
        }

        public void Update()
        {
            if (usingItemCounter == 0)
                itemBeingUsed = Item.None;
            if (damageCounter > 0)
                damageCounter--;
            if (usingItemCounter > 0)
                usingItemCounter--;
        }

        //TODO: once we test and thing works, we could probably make one generic method to handle and change in direction
        public void GoLeft()
        {
            linksDirection = Direction.Left;
            isMoving = true;
            linksPosition.X -= linkSpeed;
        }

        public void GoRight()
        {
            linksDirection = Direction.Right;
            isMoving = true;
            linksPosition.X += linkSpeed;
        }

        public void GoUp()
        {
            linksDirection = Direction.Up;
            isMoving = true;
            linksPosition.Y -= linkSpeed;
        }

        public void GoDown()
        {
            linksDirection = Direction.Down;
            isMoving = true;
            linksPosition.Y += linkSpeed;
        }

        public void NotMoving()
        {
            isMoving = false;
        }

        public void TakeDamage()
        {
            if (damageCounter == 0)
                damageCounter = 30;
        }

        public void UseSword()
        {
            if (itemBeingUsed != Item.None)
            {
                itemBeingUsed = Item.Sword;
                usingItemCounter = 30;
            }
        }

        public void UseArrow()
        {
            if (itemBeingUsed != Item.None)
            {
                itemBeingUsed = Item.Arrow;
                usingItemCounter = 30;
            }
        }

        public void UseBoomerang()
        {
            if (itemBeingUsed != Item.None)
            {
                itemBeingUsed = Item.Boomerang;
                usingItemCounter = 30;
            }
        }

        public void UseBomb()
        {
            if (itemBeingUsed != Item.None)
            {
                itemBeingUsed = Item.Bomb;
                usingItemCounter = 30;
            }
        }

        public void UseFire()
        {
            if (itemBeingUsed != Item.None)
            {
                itemBeingUsed = Item.Fire;
                usingItemCounter = 30;
            }
        }

        public Vector2 Position
        {
            get
            {
                return linksPosition;
            }
        }

        public Direction FacingDirection
        {
            get
            {
                return linksDirection;
            }
        }

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
        }

        public bool IsTakingDamage
        {
            get
            {
                return damageCounter > 0;
            }
        }

        public Item WhichItemIsBeingUsed
        {
            get
            {
                return itemBeingUsed;
            }
        }
    }
}
