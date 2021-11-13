using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts
{
    public class LinkStateMachine
    {
        //TODO:switch link to run off of gametime instead of frame counters
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
            linksPosition = ObjectConstants.linkStartingPosition;
            linkHealth = ObjectConstants.linkStartingHealth;
            isSuspended = false;
        }

        public void Update()
        {
            if (isSuspended)
            {
                ResetCounters();
            }
            if (damageCounter > ObjectConstants.zero_int)
                damageCounter--;
            if (usingItemCounter > ObjectConstants.zero_int)
                usingItemCounter--;
            if (movingCounter > ObjectConstants.zero_int)
                movingCounter--;
            if (swordCounter > ObjectConstants.zero_int)
                swordCounter--;
            if (turningCounter > ObjectConstants.zero_int)
                turningCounter--;
            if (IsMoving)
                MoveInCurrentDirection();
        }

        public void ResetCounters()
        {
            damageCounter = ObjectConstants.zero;
            usingItemCounter = ObjectConstants.zero;
            movingCounter = ObjectConstants.zero;
            turningCounter = ObjectConstants.zero;
            swordCounter = ObjectConstants.zero;
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
                turningCounter = ObjectConstants.linkTurningCounterDebounce;
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
                SFXManager.Instance.PlayLinkHit();  //putting this here so it doesn't play continuously while link stands in a fire
                if (linkHealth <= ObjectConstants.zero)
                {
                    damageCounter += ObjectConstants.linkDeathCounter;
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
            movingCounter = ObjectConstants.zero;
        }

        public void UseSword()
        {
            if (!DoingSomething())
                swordCounter = ObjectConstants.defaultCounterLength;
        }

        public void UseItem()
        {
            if (!DoingSomething())
                usingItemCounter = ObjectConstants.defaultCounterLength;
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
            return usingItemCounter != ObjectConstants.zero_int || damageCounter != ObjectConstants.zero_int ||
                movingCounter != ObjectConstants.zero_int || swordCounter != ObjectConstants.zero_int;
        }

        public Vector2 ItemSpawnPosition
        {
            get
            {
                float xDisp = ObjectConstants.zero_float, yDisp = ObjectConstants.zero_float;
                switch (linksDirection)
                {
                    //TODO: need to come up with design for the item spawning, magic numbers will be refactored then
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

        public bool IsMoving { get => movingCounter > ObjectConstants.zero_int; }

        public bool IsTakingDamage { get => damageCounter > ObjectConstants.zero_int; }

        public bool SwordIsBeingUsed { get => swordCounter > ObjectConstants.zero_int; }

        public bool IsUsingItem { get => usingItemCounter > ObjectConstants.zero_int; }

        public bool IsTurning { get => turningCounter > ObjectConstants.zero_int; }

        public bool IsAlive { get => linkHealth > ObjectConstants.zero_int || damageCounter > ObjectConstants.zero_int; }

        public bool DeathAnimation { get => linkHealth <= ObjectConstants.zero_int && damageCounter > ObjectConstants.zero_int; }

        public bool IsSuspended { get => isSuspended; }
    }
}