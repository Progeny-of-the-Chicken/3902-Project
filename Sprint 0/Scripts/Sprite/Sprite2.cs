using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0;
using Microsoft.Xna.Framework.Content;

public class Sprite2 : ISprite
{
    private Texture2D marioTexture;
    private Rectangle destinationPos;
    private Rectangle spriteFrame1;
    private Rectangle spriteFrame2;
    private Rectangle spriteFrame3;

    public Sprite2(Vector2 center)
    {
        destinationPos = new Rectangle((int)center.X, (int)center.Y, 48, 48);
        spriteFrame1 = new Rectangle(239, 0, 16, 16);
        spriteFrame2 = new Rectangle(269, 0, 16, 16);
        spriteFrame3 = new Rectangle(299, 0, 16, 16);
    }

    public void LoadContent(ContentManager content)
    {

        content.RootDirectory = "Content";
        marioTexture = content.Load<Texture2D>("smb_mario_sheet");
    }
    public void Draw(SpriteBatch _spriteBatch, GameTime timer)
    {
        if (((int) timer.TotalGameTime.TotalMilliseconds / 400) % 3 == 0)
        {
            _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame1, Color.White);
        } else if (((int) timer.TotalGameTime.TotalMilliseconds / 400) % 3 == 1)
        {
            _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame2, Color.White);
        } else
        {
            _spriteBatch.Draw(marioTexture, destinationPos, spriteFrame3, Color.White);
        }
    }
}

