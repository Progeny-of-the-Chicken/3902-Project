using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0;
using Microsoft.Xna.Framework.Content;

public class SpriteText : ISprite
{
    private SpriteFont font;
    private Vector2 destinationPos;
    private Rectangle spritePos;

    public SpriteText(Vector2 center)
    {
        destinationPos = center;
        destinationPos.X -= 300;
        destinationPos.Y += 100;
        spritePos = new Rectangle(211, 0, 12, 16);
    }

    public void LoadContent(ContentManager content)
    {
        content.RootDirectory = "Content";
        font = content.Load<SpriteFont>("File");
    }

    public void Update(GameTime gt)
    {
        //not used
    }
    public void Draw(SpriteBatch _spriteBatch, Vector2 location)
    {
        _spriteBatch.DrawString(font, "Credits\nProgram Made By: Alex Dai\nSprites from: \"https://www.mariomayhem.com/downloads/sprites/super_mario_bros_sprites.php\"", destinationPos, Color.Black);
    }
}

