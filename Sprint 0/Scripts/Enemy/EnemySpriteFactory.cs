using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.ProjectileSprites;
using Sprint_0.Scripts.Sprite.EnemySprites;
using Sprint_0.Scripts.Sprites.EnemySprites;

namespace Sprint_0.Scripts.Enemy
{
    class EnemySpriteFactory
    {
        Texture2D enemySprites;
        Texture2D npcSprites;
        Texture2D bossSprites;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        { }

        public void LoadAllTextures(ContentManager content)
        {
            enemySprites = content.Load<Texture2D>(ObjectConstants.enemiesFile);
            npcSprites = content.Load<Texture2D>(ObjectConstants.npcFile);
            bossSprites = content.Load<Texture2D>(ObjectConstants.bossesFile);
        }

        public ISprite CreateStalfosSprite()
        {
            return new FlippingSprite(SpriteRectangles.stalfosFrame, enemySprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }

        public ISprite CreateRightRopeSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.ropeFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateLeftRopeSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.ropeFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateDodongoRightSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.dodongoRightFrames, bossSprites, ObjectConstants.scale);
        }
        public ISprite CreateDodongoLeftSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.dodongoRightFrames, bossSprites, ObjectConstants.scale);
        }
        public ISprite CreateDodongoDownSprite()
        {
            return new FlippingSprite(SpriteRectangles.dodongoDownFrame, bossSprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }
        public ISprite CreateDodongoUpSprite()
        {
            return new FlippingSprite(SpriteRectangles.dodongoUpFrame, bossSprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }
        public ISprite CreateDodongoExplodeRightSprite()
        {
            return new UnanimatedEnemySprite(SpriteRectangles.dodongoExplodeRightFrame, bossSprites);
        }
        public ISprite CreateDodongoExplodeLeftSprite()
        {
            return new UnanimatedFlippedSprite(SpriteRectangles.dodongoExplodeRightFrame, bossSprites);
        }
        public ISprite CreateDodongoExplodeDownSprite()
        {
            return new UnanimatedEnemySprite(SpriteRectangles.dodongoExplodeDownFrame, bossSprites);
        }
        public ISprite CreateDodongoExplodeUpSprite()
        {
            return new FlippingSprite(SpriteRectangles.dodongoExplodeUpFrame, bossSprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }
        public ISprite CreateMerchantSprite()
        {
            return new UnanimatedEnemySprite(SpriteRectangles.merchantFrame, npcSprites);
        }
        public ISprite CreateOldManSprite()
        {
            return new UnanimatedEnemySprite(SpriteRectangles.oldManFrame, npcSprites);
        }
        public ISprite CreateGelSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.gelFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateZolSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.zolFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateAquamentusMoveSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.aquamentusMoveFrames, bossSprites, ObjectConstants.scale);
        }
        public ISprite CreateAquamentusShootSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.aquamentusShootFrames, bossSprites, ObjectConstants.scale);
        }
        public ISprite CreateKeeseSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.keeseFrames, enemySprites, ObjectConstants.scale);
        }
        //TODO: fix the magic projectile sprite to not take rectangles
        public ISprite CreateMagicProjectileSprite()
        {
            return new MagicProjectileSprite(SpriteRectangles.magicProjectileFrames, bossSprites);
        }
        public ISprite CreateFrontGoriyaSprite()
        {
            return new FlippingSprite(SpriteRectangles.goriyaFrontFrame, enemySprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }
        public ISprite CreateBackGoriyaSprite()
        {
            return new FlippingSprite(SpriteRectangles.goriyaBackFrame, enemySprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }
        public ISprite CreateRightGoriyaSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.goriyaRightFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateLeftGoriyaSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.goriyaRightFrames, enemySprites, ObjectConstants.scale);
        }
        public ISprite CreateWallmasterOpenSprite()
        {
            return new WallmasterOpenSprite(SpriteRectangles.wallMasterOpenFrame, enemySprites);
        }
        public ISprite CreateWallmasterCloseSprite()
        {
            return new WallmasterCloseSprite(SpriteRectangles.wallMasterCloseFrame, enemySprites);
        }

        public ISprite CreateSpikeTrapSprite()
        {
            return new SpikeTrapSprite(SpriteRectangles.spikeTrapFrame, enemySprites);
        }

        public ISprite CreateBubbleSprite()
        {
            return new FlippingSprite(SpriteRectangles.bubbleFrame, enemySprites, ObjectConstants.BubbleFramesPerSecond, ObjectConstants.scale);
        }

        public ISprite CreateFrontDarknutSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.darknutFrontFrames, enemySprites, ObjectConstants.scale);
        }

        public ISprite CreateBackDarknutSprite()
        {
            return new FlippingSprite(SpriteRectangles.darknutBackFrame, enemySprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.scale);
        }

        public ISprite CreateRightDarknutSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.darknutRightFrames, enemySprites, ObjectConstants.scale);
        }

        public ISprite CreateLeftDarknutSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.darknutRightFrames, enemySprites, ObjectConstants.scale);
        }

        public ISprite CreateMegaStalfosSprite()
        {
            return new FlippingSprite(SpriteRectangles.stalfosFrame, enemySprites, ObjectConstants.DefaultEnemyFramesPerSecond, ObjectConstants.MegaStalfosScale);
        }

        public ISprite CreateMegaGelSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.gelFrames, enemySprites, ObjectConstants.MegaGelScale);
        }

        public ISprite CreateMegaZolSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.zolFrames, enemySprites, ObjectConstants.MegaZolScale);
        }

        public ISprite CreateMegaKeeseSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.keeseFrames, enemySprites, ObjectConstants.MegaKeeseScale);
        }
    }
}
