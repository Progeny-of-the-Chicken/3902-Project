using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0;
using Microsoft.Xna.Framework.Content;

public class Sprite1 : ISprite
{
    private Texture2D marioTexture;
    private Rectangle destinationPos;
    private Rectangle spritePos;

    public Sprite1(Vector2 center)
    {
        destinationPos = new Rectangle((int) center.X,(int) center.Y, 36, 48);
        spritePos = new Rectangle(211, 0, 12, 16);
    }

    public void LoadContent(ContentManager content)
    {

        content.RootDirectory = "Content";
        marioTexture = content.Load<Texture2D>("smb_mario_sheet");
    }
    public void Draw(SpriteBatch _spriteBatch, GameTime timer)
    {
        _spriteBatch.Draw(marioTexture, destinationPos, spritePos, Color.White);
    }
}

