using Microsoft.Xna.Framework;
namespace Sprint_0.Scripts.Items
{
    public struct SpriteAxis
    {
        public enum Orientation { VERTICAL, HORIZONTAL }
        private Orientation axisDirection;
        private Rectangle rec;

        public SpriteAxis(Rectangle destinationRec, Orientation orientation)
        {
            rec = destinationRec;
            axisDirection = orientation;
            if (axisDirection == Orientation.HORIZONTAL)
            {
                startPos = rec.X;
            }
            else
            {
                startPos = rec.Y;
            }
        }

        public Rectangle spriteRec
        {
            get
            {
                return rec;
            }
        }

        public int startPos { get; }

        public int currentPos {
            get
            {
                if (axisDirection == Orientation.HORIZONTAL)
                {
                    return rec.X;
                }
                else
                {
                    return rec.Y;
                }
            }
            set
            {
                if (axisDirection == Orientation.HORIZONTAL)
                {
                    rec.X = value;
                }
                else
                {
                    rec.Y = value;
                }
            }
        }
    }
}
