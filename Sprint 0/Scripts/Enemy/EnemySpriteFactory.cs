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

        public ISprite CreateStalfosSprite(Rectangle frame)
        {
            return new FlippingSprite(frame, enemySprites);
        }

        public ISprite CreateRightRopeSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, enemySprites);
        }
        public ISprite CreateLeftRopeSprite(Rectangle[] frames)
        {
            return new AnimatedFlippedSprite(frames, enemySprites);
        }
        public ISprite CreateOldManSprite(Rectangle frame)
        {
            return new UnanimatedEnemySprite(frame, npcSprites);
        }
        public ISprite CreateGelSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, enemySprites);
        }
        public ISprite CreateZolSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, enemySprites);
        }
        public ISprite CreateAquamentusMoveSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, bossSprites);
        }
        public ISprite CreateAquamentusShootSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, bossSprites);
        }
        public ISprite CreateKeeseSprite(Rectangle[] frames)
        {
            return new AnimatedFlippedSprite(frames, enemySprites);
        }
        //TODO: fix the magic projectile sprite to not take rectangles
        public ISprite CreateMagicProjectileSprite()
        {
            return new MagicProjectileSprite(SpriteRectangles.magicProjectileFrames, bossSprites);
        }
        public ISprite CreateFrontGoriyaSprite(Rectangle frame)
        {
            return new FlippingSprite(frame, enemySprites);
        }
        public ISprite CreateBackGoriyaSprite(Rectangle frame)
        {
            return new FlippingSprite(frame, enemySprites);
        }
        public ISprite CreateRightGoriyaSprite(Rectangle[] frames)
        {
            return new AnimatedEnemySprite(frames, enemySprites);
        }
        public ISprite CreateLeftGoriyaSprite(Rectangle[] frames)
        {
            return new AnimatedFlippedSprite(frames, enemySprites);
        }
        public ISprite CreateWallmasterOpenSprite(Rectangle frame)
        {
            return new WallmasterOpenSprite(frame, enemySprites);
        }
        public ISprite CreateWallmasterCloseSprite(Rectangle frame)
        {
            return new WallmasterCloseSprite(frame, enemySprites);
        }

        public ISprite CreateSpikeTrapSprite(Rectangle frame)
        {
            return new SpikeTrapSprite(frame, enemySprites);
        }
    }
}
