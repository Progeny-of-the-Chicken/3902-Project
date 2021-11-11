using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState.InventoryState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.GameState
{
    public class HUD : IHUD
    {
        ISprite backgroundSprite;
        ISprite[] rupeeCounter;
        ISprite[] keyCounter;
        ISprite[] bombCounter;

        public HUD()
        {
            backgroundSprite = InventorySpriteFactory.Instance.CreateHUDBackdropSprite();
            rupeeCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];
            keyCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];
            bombCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];

            //Replace numbers with link's inventory when added
            rupeeCounter = numToSprites(123);
            keyCounter = numToSprites(456);
            bombCounter = numToSprites(789);
        }

        public void Update()
        {
            //Replace numbers with link's inventory when added
            rupeeCounter = numToSprites(123);
            keyCounter = numToSprites(456);
            bombCounter = numToSprites(789);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            backgroundSprite.Draw(spriteBatch, new Vector2(0, 0));
            for (int i = 0; i < ObjectConstants.maxDisplayableNumbers; i++)
            {
                rupeeCounter[i].Draw(spriteBatch, new Vector2((96 + 8 * i) * ObjectConstants.scale, 16 * ObjectConstants.scale));
                keyCounter[i].Draw(spriteBatch, new Vector2((96 + 8 * i) * ObjectConstants.scale, (16 + 16) * ObjectConstants.scale));
                bombCounter[i].Draw(spriteBatch, new Vector2((96 + 8 * i )* ObjectConstants.scale, (16 + 24) * ObjectConstants.scale));
            }
        }

        private ISprite[] numToSprites(int num)
        {
            ISprite[] spriteArray = new ISprite[ObjectConstants.maxDisplayableNumbers];
            for (int i = ObjectConstants.maxDisplayableNumbers - 1; i >= 0; i--)
            {
                spriteArray[i] = singleDigitToSprite(num % 10);
                num /= 10;
            }

            return spriteArray;
        }

        private ISprite singleDigitToSprite(int num)
        {
            switch (num)
            {
                case 0:
                    return FontSpriteFactory.Instance.CreateZeroSprite();
                case 1:
                    return FontSpriteFactory.Instance.CreateOneSprite();
                case 2:
                    return FontSpriteFactory.Instance.CreateTwoSprite();
                case 3:
                    return FontSpriteFactory.Instance.CreateThreeSprite();
                case 4:
                    return FontSpriteFactory.Instance.CreateFourSprite();
                case 5:
                    return FontSpriteFactory.Instance.CreateFiveSprite();
                case 6:
                    return FontSpriteFactory.Instance.CreateSixSprite();
                case 7:
                    return FontSpriteFactory.Instance.CreateSevenSprite();
                case 8:
                    return FontSpriteFactory.Instance.CreateEightSprite();
                case 9:
                    return FontSpriteFactory.Instance.CreateNineSprite();
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
