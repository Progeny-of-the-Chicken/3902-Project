using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using System;

namespace Sprint_0
{

    public class Link : ILink
    {
        ISprite LinkSprite;
        LinkStateMachine linkState;

        public Link()
        {
            linkState = new LinkStateMachine();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            LinkSprite.Draw(sb, linkState.Position);
        }

        public void Update(GameTime gt)
        {
            linkState.Update();
            if (!linkState.DoingSomething())
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            LinkSprite.Update(gt);
        }

        public void GoInDirection(FacingDirection direction)
        {
            linkState.GoInDirection(direction);
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void TakeDamage()
        {
            linkState.TakeDamage();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void BounceBackInDirection(FacingDirection direction)
        {
            linkState.BounceBackInDirection(direction);
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

        public void UseItem()
        {
            linkState.UseItem();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public FacingDirection FacingDirection
        {
            get
            {
                return linkState.FacingDirection;
            }
        }

        public Vector2 Position
        {
            get
            {
                return linkState.Position;
            }
        }

        public Vector2 ItemSpawnPosition
        {
            get
            {
                return linkState.ItemSpawnPosition;
            }
        }

        public bool IsAlive
        {
            get
            {
                return linkState.IsAlive;
            }
        }

        public bool DeathAnimation
        {
            get
            {
                return linkState.DeathAnimation;
            }
        }
    }

    public class LinkStateMachine
    {
        private FacingDirection linksDirection;
        private int damageCounter;
        private int usingItemCounter;
        private int movingCounter;
        private int swordCounter;
        private int turningCounter;
        private Vector2 linksPosition;
        private const int linkSpeed = 1;
        private int linkHealth;
        private const int linkStartingHealth = 6;

        public LinkStateMachine()
        {
            linksDirection = FacingDirection.Down;
            ResetCounters();
            linksPosition = new Vector2(200, 200); //generic starting position
            linkHealth = linkStartingHealth;
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
            if (turningCounter > 0)
                turningCounter--;
            if (IsMoving)
                MoveInCurrentDirection();
        }

        public void ResetCounters()
        {
            damageCounter = 0;
            usingItemCounter = 0;
            movingCounter = 0;
            turningCounter = 0;

        }

        public void GoInDirection(FacingDirection direction)
        {
            if (!IsMoving && !IsTurning)
            {
                if (direction == linksDirection)
                {
                    MoveInCurrentDirection();
                    movingCounter = 30;
                }
                else
                {
                    SwitchToFaceNewDirection(direction);
                    turningCounter = 10;
                }
            }
        }

        private void MoveInCurrentDirection()
        {
            switch (linksDirection)
            {
                case FacingDirection.Left:
                    linksPosition.X -= linkSpeed;
                    break;
                case FacingDirection.Right:
                    linksPosition.X += linkSpeed;
                    break;
                case FacingDirection.Up:
                    linksPosition.Y -= linkSpeed;
                    break;
                case FacingDirection.Down:
                    linksPosition.Y += linkSpeed;
                    break;
            }
        }

        private void SwitchToFaceNewDirection(FacingDirection direction)
        {
            linksDirection = direction;
        }

        public void TakeDamage()
        {
            if (!IsTakingDamage)
            {
                ResetCounters();
                damageCounter = 30;
                linkHealth--;
            }
        }

        public void BounceBackInDirection(FacingDirection direction)
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    linksPosition.X += linkSpeed * 30 * 3;
                    break;
                case FacingDirection.Right:
                    linksPosition.X -= linkSpeed * 30 * 3;
                    break;
                case FacingDirection.Up:
                    linksPosition.Y -= linkSpeed * 30 * 3;
                    break;
                case FacingDirection.Down:
                    linksPosition.Y += linkSpeed * 30 * 3;
                    break;
            }
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

        public Vector2 ItemSpawnPosition
        {
            get
            {
                float xDisp = 0, yDisp = 0;
                switch (linksDirection)
                {
                    case FacingDirection.Left:
                        yDisp += 24;
                        break;
                    case FacingDirection.Right:
                        xDisp += 48;
                        yDisp += 24;
                        break;
                    case FacingDirection.Up:
                        xDisp += 24;
                        break;
                    case FacingDirection.Down:
                        xDisp += 24;
                        yDisp += 48;
                        break;
                }
                return new Vector2(linksPosition.X + xDisp, linksPosition.Y + yDisp);
            }
        }

        public FacingDirection FacingDirection
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

        public bool IsTurning
        {
            get
            {
                return turningCounter > 0;
            }
        }

        public bool IsAlive
        {
            get
            {
                return linkHealth > 0;
            }
        }

        public bool DeathAnimation
        {
            get
            {
                return linkHealth == 0 && damageCounter > 0;
            }
        }
    }
}
