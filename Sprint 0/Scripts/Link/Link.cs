using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint_0
{
    public enum Item { Sword, Arrow, Boomerang, Bomb, Fire, None };
    public enum Direction { Up, Down, Left, Right };

    public class Link : ILink
    {
        ISprite LinkSprite;
        LinkStateMachine linkState;
        private int linkHealth;
        private const int linkStartingHealth = 3;

        public Link()
        {
            linkState = new LinkStateMachine();
            linkHealth = linkStartingHealth;
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            LinkSprite.Draw(sb, gt);
        }

        public void Update()
        {
            linkState.Update();
            if(!linkState.DoingSomething())
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            LinkSprite.Update();
        }

        public void GoInDirection(Direction direction)
        {
            linkState.GoInDirection(direction);
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void TakeDamage()
        {
            if (!linkState.IsTakingDamage)
            {
                linkHealth--;
                linkState.TakeDamage();
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            }
        }

        public bool IsMoving()
        {
            return linkState.IsMoving;
        }
        
        public void UseSword()
        {
            linkState.UseSword();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

    }

    public class LinkStateMachine
    {
        private Direction linksDirection;
        private int damageCounter;
        private int usingItemCounter;
        private int movingCounter;
        private int swordCounter;
        private Vector2 linksPosition;
        private const int linkSpeed = 16;

        public LinkStateMachine()
        {
            linksDirection = Direction.Down;
            damageCounter = 0;
            usingItemCounter = 0;
            movingCounter = 0;
            linksPosition = new Vector2(200, 200); //generic starting position
        }

        public void Update()
        {
            if (damageCounter > 0)
                damageCounter--;
            if (usingItemCounter > 0)
                usingItemCounter--;
            if (movingCounter > 0)
                movingCounter--;
            if (swordCounter > 0)
                swordCounter--;
        }


        public void GoInDirection(Direction direction)
        {
            if(direction == linksDirection)
            {
                MoveInCurrentDirection();
            }
            else
            {
                SwitchToFaceNewDirection(direction);
            }
        }

        private void MoveInCurrentDirection()
        {
            switch(linksDirection)
            {
                case Direction.Left:
                    linksPosition.X -= linkSpeed;
                    break;
                case Direction.Right:
                    linksPosition.X += linkSpeed;
                    break;
                case Direction.Up:
                    linksPosition.Y -= linkSpeed;
                    break;
                case Direction.Down:
                    linksPosition.Y += linkSpeed;
                    break;
            }
            movingCounter = 30;
        }

        private void SwitchToFaceNewDirection(Direction direction)
        {
            linksDirection = direction;
        }

        public void TakeDamage()
        {
            if (!DoingSomething())
                damageCounter = 30;
        }

        public void UseSword()
        { 
            if (!DoingSomething())
                swordCounter = 30;
        }

        public void UseItem()
        {
            if (!DoingSomething())
                usingItemCounter = 30;
        }

        public bool DoingSomething()
        {
            return usingItemCounter != 0 || damageCounter != 0 || movingCounter != 0 || swordCounter != 0;
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
                return movingCounter > 0;
            }
        }

        public bool IsTakingDamage
        {
            get
            {
                return damageCounter > 0;
            }
        }

        public bool SwordIsBeingUsed
        {
            get
            {
                return swordCounter > 0;
            }
        }

        public bool IsUsingItem
        {
            get
            {
                return usingItemCounter > 0;
            }
        }
    }
}
