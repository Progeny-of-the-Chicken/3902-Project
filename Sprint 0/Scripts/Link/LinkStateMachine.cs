using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts
{
    public class LinkStateMachine
    {
        private FacingDirection linksDirection;
        private int damageCounter;
        private int usingItemCounter;
        private int movingCounter;
        private int swordCounter;
        private int turningCounter;
        private Vector2 linksPosition;
        private int linkHealth;
        private bool isSuspended;

        public LinkStateMachine()
        {
            linksDirection = FacingDirection.Down;
            ResetCounters();
            linksPosition = new Vector2(200, 200); //generic starting position
            linkHealth = ObjectConstants.linkStartingHealth;
            isSuspended = false;
        }

        public void Update()
        {
            if(isSuspended)
            {
                ResetCounters();
            }
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
            swordCounter = 0;
        }

        public void GoInDirection(FacingDirection direction)
        {
            if (direction == linksDirection)
            {
                MoveInCurrentDirection();
                movingCounter = ObjectConstants.defaultCounterLength;
            }
            else
            {
                SwitchToFaceNewDirection(direction);
                turningCounter = 10;
            }
        }

        public void ResetPosition(Vector2 newPosition)
        {
            linksPosition = newPosition;
        }

        private void MoveInCurrentDirection()
        {
            switch (linksDirection)
            {
                case FacingDirection.Left:
                    linksPosition.X -= ObjectConstants.linkSpeed;
                    break;
                case FacingDirection.Right:
                    linksPosition.X += ObjectConstants.linkSpeed;
                    break;
                case FacingDirection.Up:
                    linksPosition.Y -= ObjectConstants.linkSpeed;
                    break;
                case FacingDirection.Down:
                    linksPosition.Y += ObjectConstants.linkSpeed;
                    break;
            }
        }

        private void SwitchToFaceNewDirection(FacingDirection direction)
        {
            linksDirection = direction;
        }

        public void TakeDamage(int damage)
        {
            if (!IsTakingDamage)
            {
                ResetCounters();

                damageCounter = ObjectConstants.defaultCounterLength;
                linkHealth -= damage;

                if (linkHealth <= 0)
                {
                    damageCounter += 90;
                    SFXManager.Instance.StopMusic();    //not sure where else to put this
                    SFXManager.Instance.PlayLinkDeath(); 
                }
            }
        }

        public void PushBackBy(Vector2 direction)
        {
            linksPosition += direction;
        }

        public void StopMoving()
        {
            movingCounter = 0;
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

        public void Suspend()
        {
            isSuspended = true;
        }

        public void UnSuspend()
        {
            isSuspended = false;
        }

        public bool DoingSomething()
        {
            return usingItemCounter != 0 || damageCounter != 0 || movingCounter != 0 || swordCounter != 0;
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

        public Vector2 Position { get => linksPosition; }

        public FacingDirection FacingDirection { get => linksDirection; }

        public bool IsMoving { get => movingCounter > 0; }

        public bool IsTakingDamage { get => damageCounter > 0; }

        public bool SwordIsBeingUsed { get => swordCounter > 0; }

        public bool IsUsingItem { get => usingItemCounter > 0; }

        public bool IsTurning { get => turningCounter > 0; }

        public bool IsAlive { get => linkHealth > 0 || damageCounter > 0; }

        public bool DeathAnimation { get => linkHealth == 0 && damageCounter > 0; }

        public bool IsSuspended { get => isSuspended; }
    }
}