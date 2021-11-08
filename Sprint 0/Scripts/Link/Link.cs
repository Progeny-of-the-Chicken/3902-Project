using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts
{

    public class Link : ILink
    {
        ISprite LinkSprite;
        LinkStateMachine linkState;
        private LinkCollider _collider;
        public IPlayerCollider collider { get => _collider; }

        public Link()
        {
            linkState = new LinkStateMachine();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);

            Rectangle spawnHitbox = new Rectangle(linkState.Position.ToPoint(), new Point(ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            _collider = new LinkCollider(this, spawnHitbox);
        }

        public void Draw(SpriteBatch sb)
        {
            LinkSprite.Draw(sb, linkState.Position);
        }

        public void Update(GameTime gt)
        {
            linkState.Update();
            if (!linkState.DoingSomething())
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);

            LinkSprite.Update(gt);
            _collider.Update(linkState.Position);
        }

        public void GoInDirection(FacingDirection direction)
        {
            if (!linkState.IsMoving && !linkState.IsTurning)
            {
                linkState.GoInDirection(direction);
                LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            }
        }

        public void TakeDamage(int damage)
        {
            linkState.TakeDamage(damage);
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            SFXManager.Instance.PlayLinkHit();
        }

        public void PushBackBy(Vector2 direction)
        {
            linkState.PushBackBy(direction);
        }

        public bool IsMoving()
        {
            return linkState.IsMoving;
        }

        public void StopMoving()
        {
            linkState.StopMoving();
        }

        public void UseSword()
        {
            linkState.UseSword();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
            ObjectsFromObjectsFactory.Instance.CreateSwordAttackHitboxFromLink(Position, FacingDirection);
        }

        public void UseItem()
        {
            linkState.UseItem();
            LinkSprite = LinkSpriteFactory.Instance.GetSpriteForState(linkState);
        }

        public void ResetPosition(Vector2 newPosition)
        {
            linkState.ResetPosition(newPosition);
        }

        public void Suspend()
        {
            linkState.Suspend();
        }

        public void UnSuspend()
        {
            linkState.UnSuspend();
        }

        public FacingDirection FacingDirection { get => linkState.FacingDirection; }

        public Vector2 Position { get => linkState.Position; }

        public Vector2 ItemSpawnPosition { get => linkState.ItemSpawnPosition; }

        public bool IsAlive { get => linkState.IsAlive; }

        public bool DeathAnimation { get => linkState.DeathAnimation; }

        public bool IsSuspended { get => linkState.IsSuspended; }

        public bool CanBeAffectedByEnemy { get => !linkState.IsTakingDamage; }
    }

}
