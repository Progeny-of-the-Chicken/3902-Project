using Sprint_0.Scripts.Sprite.LinkSprites;
using Sprint_0.Scripts.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState;

namespace Sprint_0.Scripts.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private Texture2D baseSpriteSheet;
        private Texture2D blueLinkSpriteSheet;

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            baseSpriteSheet = content.Load<Texture2D>(ObjectConstants.linkFile);
            blueLinkSpriteSheet = content.Load<Texture2D>(ObjectConstants.blueLinkFile);
        }

        public Texture2D GetBaseSpriteSheet()
        {
            return baseSpriteSheet;
        }

        public Texture2D GetBlueSpriteSheet()
        {
            return blueLinkSpriteSheet;
        }

        public ISprite GetSpriteForState(LinkStateMachine linkState)
        {
            if (Inventory.Instance.BlueRing)
                return GetSpriteForBlueLink(linkState);
            else
                return GetSpriteForBaseLink(linkState);
        }

        //----- Helper methods for discerning link color -----//

        private ISprite GetSpriteForBaseLink(LinkStateMachine linkState)
        {
            if (linkState.DeathAnimation)
                return new LinkDeathSprite(linkState);
            if (linkState.IsMoving)
                return new LinkMovingSprite(linkState);
            if (linkState.SwordIsBeingUsed)
                return new LinkSwordSprite(linkState);
            if (linkState.IsTakingDamage)
                return new LinkTakingDamageSprite(linkState);
            if (linkState.IsUsingItem)
                return new LinkUsingItemSprite(linkState);
            if (linkState.IsPickingUpItem)
                return new LinkPickUpSprite(linkState);
            else
                return new LinkStandingSprite(linkState);
        }

        private ISprite GetSpriteForBlueLink(LinkStateMachine linkState)
        {
            if (linkState.DeathAnimation)
                return new BlueLinkDeathSprite(linkState);
            if (linkState.IsMoving)
                return new BlueLinkMovingSprite(linkState);
            if (linkState.SwordIsBeingUsed)
                return new BlueLinkSwordSprite(linkState);
            if (linkState.IsTakingDamage)
                return new BlueLinkTakingDamageSprite(linkState);
            if (linkState.IsUsingItem)
                return new BlueLinkUsingItemSprite(linkState);
            if (linkState.IsPickingUpItem)
                return new BlueLinkPickUpSprite(linkState);
            else
                return new BlueLinkStandingSprite(linkState);
        }


    }
}
