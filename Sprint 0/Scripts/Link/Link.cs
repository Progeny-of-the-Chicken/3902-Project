using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
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
    }

    public class LinkStateMachine
    {
        public enum Direction { Up, Down, Left, Right};
        public enum Item {Sword, Arrow, Boomerang, Bomb, Fire};
        private Direction linksDirection;
        private bool isMoving;
        private bool usingItem;
        private int damageCounter;
        private Vector2 linksPosition;
        private const int linkSpeed = 1;

        public LinkStateMachine()
        {
            linksDirection = Direction.Down;
            isMoving = true;
            damageCounter = 0;
            usingItem = false;
            linksPosition = new Vector2(200, 200); //generic starting position
        }

        public void Update()
        {
            if (damageCounter > 0)
                damageCounter--;
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

        public Vector2 LinksPosition
        {
            get
            {
                return linksPosition;
            }
        }

        public Direction LinksDirection
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
    }
}
