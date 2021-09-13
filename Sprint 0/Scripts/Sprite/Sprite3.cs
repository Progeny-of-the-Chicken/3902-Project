using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0;
using Microsoft.Xna.Framework.Content;

public class Sprite3 : ISprite
{
    private Texture2D marioTexture;
    private Rectangle destinationPos;
    private Rectangle spritePos;

    public Sprite3(Vector2 center)
    {
        destinationPos = new Rectangle((int)center.X, (int)center.Y, 48, 48);
        spritePos = new Rectangle(0, 16, 16, 16);
    }

    public void LoadContent(ContentManager content)
    {

        content.RootDirectory = "Content";
        marioTexture = content.Load<Texture2D>("smb_mario_sheet");
    }
    public void Draw(SpriteBatch _spriteBatch, GameTime timer)
    {
        if ((int)timer.TotalGameTime.TotalSeconds % 2 == 0)
            destinationPos.Y--;
        else
            destinationPos.Y++;

        _spriteBatch.Draw(marioTexture, destinationPos, spritePos, Color.White);
    }
}

