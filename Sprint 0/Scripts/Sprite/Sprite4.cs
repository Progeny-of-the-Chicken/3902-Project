using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0;
using Microsoft.Xna.Framework.Content;

public class Sprite4 : ISprite
{
    private Texture2D marioTexture;
    private Rectangle destinationPos;
    private Rectangle spriteFrame1;
    private Rectangle spriteFrame2;
    private Rectangle spriteFrame3;
    private Rectangle spriteFrame4;
    private Rectangle spriteFrame5;
    private Rectangle spriteFrame6;
    private const int FRAMELENGTH = 80;

    public Sprite4(Vector2 center)
    {
        destinationPos = new Rectangle((int)center.X, (int)center.Y, 48, 48);
        spriteFrame1 = new Rectangle(239, 0, 16, 16);
        spriteFrame2 = new Rectangle(269, 0, 16, 16);
        spriteFrame3 = new Rectangle(299, 0, 16, 16);

        spriteFrame4 = new Rectangle(149, 0, 16, 16);
        spriteFrame5 = new Rectangle(119, 0, 16, 16);
        spriteFrame6 = new Rectangle(89, 0, 16, 16);
    }

    public void LoadContent(ContentManager content)
    {

        content.RootDirectory = "Content";
        marioTexture = content.Load<Texture2D>("smb_mario_sheet");
    }
    public void Draw(SpriteBatch _spriteBatch, GameTime timer)
    {
        if ((int)timer.TotalGameTime.TotalSeconds % 2 == 0)
        {
            destinationPos.X+=3;
            if (((int)timer.TotalGameTime.TotalMilliseconds / FRAMELENGTH) % 3 == 0)
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame1, Color.White);
            }
            else if (((int)timer.TotalGameTime.TotalMilliseconds / FRAMELENGTH) % 3 == 1)
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame2, Color.White);
            }
            else
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame3, Color.White);
            }
        } else
        {
            destinationPos.X-=3;
            if (((int)timer.TotalGameTime.TotalMilliseconds / FRAMELENGTH) % 3 == 0)
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame4, Color.White);
            }
            else if (((int)timer.TotalGameTime.TotalMilliseconds / FRAMELENGTH) % 3 == 1)
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame5, Color.White);
            }
            else
            {
                _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame6, Color.White);
            }
        }
    }
}

