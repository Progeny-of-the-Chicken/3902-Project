using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.EffectSprites;

namespace Sprint_0.Scripts.Effect
{
    public class EffectSpriteFactory
    {
        private Texture2D spritesheet;

        private static EffectSpriteFactory instance = new EffectSpriteFactory();

        public static EffectSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EffectSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            spritesheet = content.Load<Texture2D>("LoZSprites");
        }

        public ISprite CreatePopSprite()
        {
            return new PopSprite(spritesheet);
        }

        public ISprite CreateExplosionSprite()
        {
            return new ExplosionSprite(spritesheet);
        }
    }
}
