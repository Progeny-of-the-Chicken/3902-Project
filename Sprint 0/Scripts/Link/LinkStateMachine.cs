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
        private double shotgunCounter;
        private double turningCounter;
        private double knockbackCounter;
        private double pickUpItemCounter;
        private double swordSheathCounter;
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
                if (!IsMoving)
                {
                    RoundPosition();
                }
            }
            if (IsGettingKnockedBack)
            {
                MoveInKnockBackDirection(dt);
                knockbackCounter -= dt;
                if (!IsGettingKnockedBack)
                {
                    RoundPosition();
                }
            }
            if (IsTakingDamage)
                damageCounter -= dt;
            if (IsUsingItem)
                usingItemCounter -= dt;
            if (SwordIsBeingUsed)
                swordCounter -= dt;
            if (ShotgunIsBeingUsed)
                shotgunCounter -= dt;
            if (IsTurning)
                turningCounter -= dt;
            if (IsPickingUpItem)
                pickUpItemCounter -= dt;
            if (SwordIsSheathed)
                swordSheathCounter -= dt;
        }

        private void RoundPosition()
        {
            //Transform position in pixels to position in half-blocks
            float numHalfBlocksX = (linksPosition.X - ObjectConstants.xOffsetForRoom) * 2 / ObjectConstants.scaledStdWidthHeight;
            float numHalfBlocksY = (linksPosition.Y - ObjectConstants.yOffsetForRoom) * 2 / ObjectConstants.scaledStdWidthHeight;

            //Round the number of half-blocks
            numHalfBlocksX = (int) System.Math.Round(numHalfBlocksX);
            numHalfBlocksY = (int) System.Math.Round(numHalfBlocksY);

            //Tansform position back to pixels
            linksPosition.X = numHalfBlocksX * ObjectConstants.scaledStdWidthHeight / 2 + ObjectConstants.xOffsetForRoom;
            linksPosition.Y = numHalfBlocksY * ObjectConstants.scaledStdWidthHeight / 2 + ObjectConstants.yOffsetForRoom;
        }

        private void ResetCountersCausedByPlayer()
        {
            usingItemCounter = ObjectConstants.counterInitialVal_double;
            movingCounter = ObjectConstants.counterInitialVal_double;
            turningCounter = ObjectConstants.counterInitialVal_double;
            swordCounter = ObjectConstants.counterInitialVal_double;
            shotgunCounter = ObjectConstants.counterInitialVal_double;
            pickUpItemCounter = ObjectConstants.counterInitialVal_double;
        }

        private void ResetCountersCausedByExternal()
        {
            damageCounter = ObjectConstants.counterInitialVal_double;
            knockbackCounter = ObjectConstants.counterInitialVal_double;
            swordSheathCounter = ObjectConstants.counterInitialVal_double;
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

                if (linkHealth <= linkMaxHealth / ObjectConstants.lowHealthThreshold)
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

        public void UseShotgun()
        {
            if (CanDoNewThing())
                shotgunCounter = ObjectConstants.linkUseItemTime;
        }

        public void PickUpItem()
        {
            ResetCountersCausedByPlayer();
            pickUpItemCounter = ObjectConstants.linkPickUpItemTime;
        }

        public void SheathSword()
        {
            swordSheathCounter = ObjectConstants.linkSwordSheathTime;
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
            return IsUsingItem || IsTakingDamage || IsMoving || SwordIsBeingUsed || ShotgunIsBeingUsed || IsGettingKnockedBack || IsTurning || IsPickingUpItem;
        }

        public bool CanDoNewThing()
        {
            return !(IsUsingItem || IsMoving || SwordIsBeingUsed || ShotgunIsBeingUsed || IsGettingKnockedBack || IsTurning || DeathAnimation || IsPickingUpItem);
        }

        public void HealBy(int health)
        {
            if (linkHealth + health >= linkMaxHealth)
                linkHealth = linkMaxHealth;
            else
                linkHealth += health;
        }

        public Vector2 Position { get => linksPosition; }

        public FacingDirection FacingDirection { get => linksDirection; }

        public bool IsMoving { get => movingCounter > ObjectConstants.zero_double; }
        public bool IsGettingKnockedBack { get => knockbackCounter > ObjectConstants.zero_double; }

        public bool IsTakingDamage { get => damageCounter > ObjectConstants.zero_double; }

        public bool SwordIsBeingUsed { get => swordCounter > ObjectConstants.zero_double; }
        public bool ShotgunIsBeingUsed { get => shotgunCounter > ObjectConstants.zero_double; }

        public bool IsUsingItem { get => usingItemCounter > ObjectConstants.zero_double; }
        public bool IsPickingUpItem { get => pickUpItemCounter > ObjectConstants.zero_double; }

        public bool IsTurning { get => turningCounter > ObjectConstants.zero_double; }

        public bool SwordIsSheathed { get => swordSheathCounter > ObjectConstants.zero_double; }

        public bool IsAlive { get => linkHealth > ObjectConstants.zero_int || damageCounter > ObjectConstants.zero_int; }

        public bool DeathAnimation { get => linkHealth <= ObjectConstants.zero_double && IsTakingDamage; }

        public bool IsSuspended { get => isSuspended; }
    }
}