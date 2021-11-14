using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.Font;
using Sprint_0.Scripts.Sprite.Font.Letters;

namespace Sprint_0.Scripts.SpriteFactories
{
    public class FontSpriteFactory
    {
        private Texture2D texture;
        private static FontSpriteFactory instance = new FontSpriteFactory();

        public static FontSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private FontSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(ObjectConstants.fontSpritesheetFileName);
        }

        public ISprite CreateZeroSprite()
        {
            return new ZeroSprite(texture);
        }

        public ISprite CreateOneSprite()
        {
            return new OneSprite(texture);
        }

        public ISprite CreateTwoSprite()
        {
            return new TwoSprite(texture);
        }

        public ISprite CreateThreeSprite()
        {
            return new ThreeSprite(texture);
        }

        public ISprite CreateFourSprite()
        {
            return new FourSprite(texture);
        }

        public ISprite CreateFiveSprite()
        {
            return new FiveSprite(texture);
        }

        public ISprite CreateSixSprite()
        {
            return new SixSprite(texture);
        }

        public ISprite CreateSevenSprite()
        {
            return new SevenSprite(texture);
        }

        public ISprite CreateEightSprite()
        {
            return new EightSprite(texture);
        }

        public ISprite CreateNineSprite()
        {
            return new NineSprite(texture);
        }

        public ISprite CreateLetterSprite(char letter)
        {
            return new LetterSprite(texture, letter);
        }
    }
}
