using Microsoft.Xna.Framework;
using Sprint_0.Scripts.GameState;

namespace Sprint_0.Scripts
{
    public class LinkStateMachine
    {
        //TODO:switch link to run off of gametime instead of frame counters
        private FacingDirection linksDirection;
        private double damageCounter;
        private double usingItemCounter;
        private double movingCounter;
        private double swordCounter;
        private double turningCounter;
        private double knockbackCounter;
        private double pickUpItemCounter;
        private Vector2 knockbackVector;
        private Vector2 linksPosition;
        public double linkHealth;
        public int linkMaxHealth;
        private bool isSuspended;

        public LinkStateMachine()
        {
            linksDirection = FacingDirection.Down;
            ResetCountersCausedByPlayer();
            ResetCountersCausedByExternal();
            linksPosition = ObjectConstants.linkStartingPosition;
            linkHealth = ObjectConstants.linkStartingHealth;
            linkMaxHealth = ObjectConstants.linkStartingHealth;
            isSuspended = false;
        }

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            if (isSuspended)
            {
                ResetCountersCausedByPlayer();
                ResetCountersCausedByExternal();
            }
            if (IsMoving)
            {
                MoveInDirection(dt, linksDirection);
                movingCounter -= dt;
            }
            if (IsGettingKnockedBack)
            {
                MoveInKnockBackDirection(dt);
                knockbackCounter -= dt;
            }
            if (IsTakingDamage)
                damageCounter -= dt;
            if (IsUsingItem)
                usingItemCounter -= dt;
            if (SwordIsBeingUsed)
                swordCounter -= dt;
            if (IsTurning)
                turningCounter -= dt;
            if (IsPickingUpItem)
                pickUpItemCounter -= dt;
        }

        private void ResetCountersCausedByPlayer()
        {
            usingItemCounter = ObjectConstants.counterInitialVal_double;
            movingCounter = ObjectConstants.counterInitialVal_double;
            turningCounter = ObjectConstants.counterInitialVal_double;
            swordCounter = ObjectConstants.counterInitialVal_double;
            pickUpItemCounter = ObjectConstants.counterInitialVal_double;
        }

        private void ResetCountersCausedByExternal()
        {
            damageCounter = ObjectConstants.counterInitialVal_double;
            knockbackCounter = ObjectConstants.counterInitialVal_double;
        }

        public void GoInDirection(FacingDirection direction)
        {
            if (direction == linksDirection)
            {
                MoveInDirection(0, linksDirection);
                movingCounter = ObjectConstants.linkStdMoveTime;
            }
            else
            {
                SwitchToFaceNewDirection(direction);
                turningCounter = ObjectConstants.linkTurningCounterDebounce;
            }
        }

        public void MoveInKnockBackDirection(float dt)
        {
            float interval = (float)(dt / ObjectConstants.linkStdMoveTime);
            linksPosition += knockbackVector * interval;
        }

        public void ResetPosition(Vector2 newPosition)
        {
            linksPosition = newPosition;
        }

        private void MoveInDirection(float dt, FacingDirection direction)
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    linksPosition.X -= ObjectConstants.linkSpeed * dt;
                    break;
                case FacingDirection.Right:
                    linksPosition.X += ObjectConstants.linkSpeed * dt;
                    break;
                case FacingDirection.Up:
                    linksPosition.Y -= ObjectConstants.linkSpeed * dt;
                    break;
                case FacingDirection.Down:
                    linksPosition.Y += ObjectConstants.linkSpeed * dt;
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
                ResetCountersCausedByPlayer();
                damageCounter = ObjectConstants.linkTakeDamageTime;
                if (!Inventory.Instance.BlueRing)
                {
                    linkHealth -= damage;
                }
                else
                {
                    linkHealth -= (double)damage / ObjectConstants.oneInTwo;
                }
                SFXManager.Instance.PlayLinkHit();  //putting this here so it doesn't play continuously while link stands in a fire
                if (linkHealth <= ObjectConstants.zero)
                {
                    damageCounter += ObjectConstants.linkDeathCounter;
                    SFXManager.Instance.StopMusic();    //not sure where else to put this
                    SFXManager.Instance.PlayLinkDeath(); 
                }

                if(linkHealth <= linkMaxHealth / ObjectConstants.lowHealthThreshold)
                {
                    SFXManager.Instance.PlayLowHealth();
                }
            }
        }

        public void PushBackBy(Vector2 direction, double time)
        {
            ResetCountersCausedByPlayer();
            if (time == ObjectConstants.zero_double)
            {
                linksPosition += direction;
            }
            else
            {
                knockbackCounter = ObjectConstants.linkStdMoveTime;
                knockbackVector = direction;
            }
        }

        public void StopMoving()
        {
            movingCounter = ObjectConstants.zero;
        }

        public void UseSword()
        {
            if (CanDoNewThing())
                swordCounter = ObjectConstants.linkUseItemTime;
        }

        public void UseItem()
        {
            if (CanDoNewThing())
                usingItemCounter = ObjectConstants.linkUseItemTime;
        }

        public void PickUpItem()
        {
            ResetCountersCausedByPlayer();
            pickUpItemCounter = ObjectConstants.linkPickUpItemTime;
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
            return IsUsingItem || IsTakingDamage || IsMoving || SwordIsBeingUsed || IsGettingKnockedBack || IsTurning || IsPickingUpItem;
        }

        public bool CanDoNewThing()
        {
            return !(IsUsingItem || IsMoving || SwordIsBeingUsed || IsGettingKnockedBack || IsTurning || DeathAnimation || IsPickingUpItem);
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

        public bool IsMoving { get => movingCounter > ObjectConstants.zero_double; }
        public bool IsGettingKnockedBack { get => knockbackCounter > ObjectConstants.zero_double; }

        public bool IsTakingDamage { get => damageCounter > ObjectConstants.zero_double; }

        public bool SwordIsBeingUsed { get => swordCounter > ObjectConstants.zero_double; }

        public bool IsUsingItem { get => usingItemCounter > ObjectConstants.zero_double; }
        public bool IsPickingUpItem { get => pickUpItemCounter > ObjectConstants.zero_double; }

        public bool IsTurning { get => turningCounter > ObjectConstants.zero_double; }

        public bool IsAlive { get => linkHealth > ObjectConstants.zero_int || damageCounter > ObjectConstants.zero_int; }

        public bool DeathAnimation { get => linkHealth <= ObjectConstants.zero_double && IsTakingDamage; }

        public bool IsSuspended { get => isSuspended; }
    }
}