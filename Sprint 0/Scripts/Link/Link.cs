using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using System;
using System.Diagnostics;

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
        private bool needsStandingSprite = false;

        public Link()
        {
            linkState = new LinkStateMachine();
            linkHealth = linkStartingHealth;
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            LinkSprite.Draw(sb, linkState.Position);
        }

        public void Update(GameTime gt)
        {

            linkState.Update();

            if (!linkState.DoingSomething() && needsStandingSprite)
            {
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
                needsStandingSprite = false;
            }
                
            LinkSprite.Update(gt);
        }

        public void GoInDirection(Direction direction)
        {
            if (!linkState.DoingSomething())
            {
                linkState.GoInDirection(direction);
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            }

            needsStandingSprite = true;
        }

        public void TakeDamage()
        {
            if (!linkState.IsTakingDamage)
            {
                linkHealth--;
                linkState.TakeDamage();
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            }


            needsStandingSprite = true;
        }

        public bool IsMoving()
        {
            return linkState.IsMoving;
        }
        
        public void UseSword()
        {
            bool linkUsingSword = linkState.SwordIsBeingUsed;
            linkState.UseSword();

            if (!linkUsingSword)
            {
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            }

            needsStandingSprite = true;
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
        private const int linkSpeed = 3;

        private bool _IsMoving = false;
        private bool _SwordIsBeingUsed = false;
        private bool _IsTakingDamage = false;
        private bool _IsUsingItem = false;

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
            {
                if (damageCounter == 1)
                {
                    _IsTakingDamage = false;
                }
                damageCounter--;
            }
            if (usingItemCounter > 0)
            {
                if (usingItemCounter == 1)
                {
                    _IsUsingItem = false;
                }
                usingItemCounter--;
            }
            if (movingCounter > 0)
            {
                MoveInCurrentDirection();
                if (movingCounter == 1)
                {
                    _IsMoving = false;
                }
                movingCounter--;
            }
            if (swordCounter > 0)
            {
                if (swordCounter == 1)
                {
                    _SwordIsBeingUsed = false;
                }
                swordCounter--;
            }
        }


        public void GoInDirection(Direction direction)
        {
            if (movingCounter == 0)
            {
                _IsMoving = true;
                movingCounter = 16;
            }

            linksDirection = direction;
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
        }

        public void TakeDamage()
        {
            if (!DoingSomething())
            {
                _IsTakingDamage = true;
                damageCounter = 30;
            }
        }

        public void UseSword()
        { 
            if (!DoingSomething())
            {
                _SwordIsBeingUsed = true;
                swordCounter = 30;
            }
        }

        public void UseItem()
        {
            if (!DoingSomething())
            {
                _IsUsingItem = true;
                usingItemCounter = 30;
            }
        }

        public bool DoingSomething()
        {
            return _IsUsingItem || _IsTakingDamage || _IsMoving || _SwordIsBeingUsed;
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
                return _IsMoving;
            }
        }

        public bool IsTakingDamage
        {
            get
            {
                return _IsTakingDamage;
            }
        }

        public bool SwordIsBeingUsed
        {
            get
            {
                return _SwordIsBeingUsed;
            }
        }

        public bool IsUsingItem
        {
            get
            {
                return _IsUsingItem;
            }
        }
    }
}
