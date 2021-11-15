using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkPickUpSprite : ISprite
    {
        private Texture2D sheet;
        private float changeFrameCounter;
        private int frameNum;

        private Rectangle[] frames;
        private Rectangle currentFrame;

        public LinkPickUpSprite(LinkStateMachine state)
        {
            sheet = LinkSpriteFactory.Instance.GetBaseSpriteSheet();
            frames = SpriteRectangles.linkPickUpItemFrames;
            frameNum = ObjectConstants.firstFrame;
            currentFrame = frames[frameNum];
            changeFrameCounter = ObjectConstants.counterInitialVal_float;
        }

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            changeFrameCounter += dt;
            bool changeFrame = changeFrameCounter > ObjectConstants.linkItemPickUpFrameChangeFreq;
            if (changeFrame)
            {
                changeFrameCounter = ObjectConstants.counterInitialVal_float;
                frameNum += ObjectConstants.nextInArray;
                frameNum %= frames.Length;
                currentFrame = frames[frameNum];
            }
        }
        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (frameNum == ObjectConstants.firstFrame)
            {
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale), currentFrame, Color.White, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
            }
            else
            {
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale), currentFrame, Color.White);
            }
        }
    }
}
