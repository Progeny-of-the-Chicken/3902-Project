using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.Font.Letters
{
    public class LetterSprite: ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.fontSpaceFrame;
        private int scale = ObjectConstants.scale;

        public LetterSprite(Texture2D textures, char letter)
        {
            spritesheet = textures;
            setFrameForLetter(letter);
        }

        public void Update(GameTime gt)
        {
            //Should be empty
        }


        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White);
        }

        private void setFrameForLetter(char letter)
        {
            switch (letter)
            {
                case 'a':
                    frame = SpriteRectangles.fontAFrame;
                    break;
                case 'b':
                    frame = SpriteRectangles.fontBFrame;
                    break;
                case 'c':
                    frame = SpriteRectangles.fontCFrame;
                    break;
                case 'd':
                    frame = SpriteRectangles.fontDFrame;
                    break;
                case 'e':
                    frame = SpriteRectangles.fontEFrame;
                    break;
                case 'f':
                    frame = SpriteRectangles.fontFFrame;
                    break;
                case 'g':
                    frame = SpriteRectangles.fontGFrame;
                    break;
                case 'h':
                    frame = SpriteRectangles.fontHFrame;
                    break;
                case 'i':
                    frame = SpriteRectangles.fontIFrame;
                    break;
                case 'j':
                    frame = SpriteRectangles.fontJFrame;
                    break;
                case 'k':
                    frame = SpriteRectangles.fontKFrame;
                    break;
                case 'l':
                    frame = SpriteRectangles.fontLFrame;
                    break;
                case 'm':
                    frame = SpriteRectangles.fontMFrame;
                    break;
                case 'n':
                    frame = SpriteRectangles.fontNFrame;
                    break;
                case 'o':
                    frame = SpriteRectangles.fontOFrame;
                    break;
                case 'p':
                    frame = SpriteRectangles.fontPFrame;
                    break;
                case 'q':
                    frame = SpriteRectangles.fontQFrame;
                    break;
                case 'r':
                    frame = SpriteRectangles.fontRFrame;
                    break;
                case 's':
                    frame = SpriteRectangles.fontSFrame;
                    break;
                case 't':
                    frame = SpriteRectangles.fontTFrame;
                    break;
                case 'u':
                    frame = SpriteRectangles.fontUFrame;
                    break;
                case 'v':
                    frame = SpriteRectangles.fontVFrame;
                    break;
                case 'w':
                    frame = SpriteRectangles.fontWFrame;
                    break;
                case 'x':
                    frame = SpriteRectangles.fontXFrame;
                    break;
                case 'y':
                    frame = SpriteRectangles.fontYFrame;
                    break;
                case 'z':
                    frame = SpriteRectangles.fontZFrame;
                    break;
                case ' ':
                    frame = SpriteRectangles.fontSpaceFrame;
                    break;
                case '\'':
                    frame = SpriteRectangles.fontApostropheFrame;
                    break;
                case '!':
                    frame = SpriteRectangles.fontExclaimationFrame;
                    break;
                case '.':
                    frame = SpriteRectangles.fontPeriodFrame;
                    break;
                case ',':
                    frame = SpriteRectangles.fontCommaFrame;
                    break;
                default:
                    frame = SpriteRectangles.fontSpaceFrame;
                    break;
            }
        }
    }
}