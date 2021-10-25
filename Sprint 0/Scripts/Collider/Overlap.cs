using System;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Collider
{
    public class Overlap
    {
        static public Vector2 DirectionToMoveObjectOff(Rectangle staticObject, Rectangle movableObject)
        {
            Rectangle overlapRec = Rectangle.Intersect(staticObject, movableObject);
            Vector2 overlapVec = new Vector2(overlapRec.Width, overlapRec.Height);
            if(overlapVec.X < overlapVec.Y)
                overlapVec.Y = 0;
            else
                overlapVec.X = 0;
            //This less us take the magnatiude of the overlap and give it a direction for adjustment
            if (staticObject.X > movableObject.X)
                overlapVec.X *= -1;
            if (staticObject.Y > movableObject.Y)
                overlapVec.Y *= -1;            
            return overlapVec;
        }

        public static bool CheckIntersection(Rectangle staticObject, Rectangle moveableObject)
        {
            return staticObject.Intersects(moveableObject);
        }
    }
}
