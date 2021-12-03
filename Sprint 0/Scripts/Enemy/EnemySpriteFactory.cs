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
            return new FlippingSprite(SpriteRectangles.stalfosFrame, enemySprites);
        }

        public ISprite CreateRightRopeSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.ropeFrames, enemySprites);
        }
        public ISprite CreateLeftRopeSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.ropeFrames, enemySprites);
        }
        public ISprite CreateDodongoRightSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.dodongoRightFrames, bossSprites);
        }
        public ISprite CreateDodongoLeftSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.dodongoRightFrames, bossSprites);
        }
        public ISprite CreateDodongoDownSprite()
        {
            return new FlippingSprite(SpriteRectangles.dodongoDownFrame, bossSprites);
        }
        public ISprite CreateDodongoUpSprite()
        {
            return new FlippingSprite(SpriteRectangles.dodongoUpFrame, bossSprites);
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
            return new FlippingSprite(SpriteRectangles.dodongoExplodeUpFrame, bossSprites);
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
            return new AnimatedEnemySprite(SpriteRectangles.gelFrames, enemySprites);
        }
        public ISprite CreateZolSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.zolFrames, enemySprites);
        }
        public ISprite CreateAquamentusMoveSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.aquamentusMoveFrames, bossSprites);
        }
        public ISprite CreateAquamentusShootSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.aquamentusShootFrames, bossSprites);
        }
        public ISprite CreateKeeseSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.keeseFrames, enemySprites);
        }
        //TODO: fix the magic projectile sprite to not take rectangles
        public ISprite CreateMagicProjectileSprite()
        {
            return new MagicProjectileSprite(SpriteRectangles.magicProjectileFrames, bossSprites);
        }
        public ISprite CreateFrontGoriyaSprite()
        {
            return new FlippingSprite(SpriteRectangles.goriyaFrontFrame, enemySprites);
        }
        public ISprite CreateBackGoriyaSprite()
        {
            return new FlippingSprite(SpriteRectangles.goriyaBackFrame, enemySprites);
        }
        public ISprite CreateRightGoriyaSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.goriyaRightFrames, enemySprites);
        }
        public ISprite CreateLeftGoriyaSprite()
        {
            return new AnimatedFlippedSprite(SpriteRectangles.goriyaRightFrames, enemySprites);
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

        public ISprite CreatePatraSprite()
        {
            return new QuickFlippingSprite(SpriteRectangles.patraFrame, bossSprites);
        }
        public ISprite CreatePatraMinionSprite()
        {
            return new AnimatedEnemySprite(SpriteRectangles.patraMinionFrames, bossSprites);
        }
    }
}
