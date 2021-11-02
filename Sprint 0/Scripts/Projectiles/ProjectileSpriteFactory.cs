using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.ProjectileSprites;

namespace Sprint_0.Scripts.Projectiles
{
    public class ProjectileSpriteFactory
    {
        private Texture2D spritesheet;

        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            spritesheet = content.Load<Texture2D>(ObjectConstants.projectileFile);
        }

        public ISprite CreateArrowSprite(FacingDirection direction, bool silver)
        {
            return new ArrowSprite(spritesheet, direction, silver);
        }

        public ISprite CreateArrowPopSprite()
        {
            return new ArrowPopSprite(spritesheet);
        }

        public ISprite CreateBoomerangSprite(bool magical)
        {
            return new BoomerangSprite(spritesheet, magical);
        }

        public ISprite CreateBombSprite()
        {
            return new BombSprite(spritesheet);
        }

        public ISprite CreateBombExplodeSprite()
        {
            return new BombExplodeSprite(spritesheet);
        }

        public ISprite CreateFireSpellSprite()
        {
            return new FireSpellSprite(spritesheet);
        }
    }
}
