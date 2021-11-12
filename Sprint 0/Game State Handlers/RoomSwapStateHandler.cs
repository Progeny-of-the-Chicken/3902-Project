using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public class RoomSwapStateHandler: IGameStateHandler
    {
        private const int verticalScrollDist = 800;
        private const int horizontalScrollDist = 1200;
        private Vector2 toRoomOriginDrawPoint;
        private Vector2 fromRoomOriginDrawPoint;

        private string fromRoomID;
        private string toRoomID;
        private IRoom toRoom;
        private IRoom fromRoom;
        private FacingDirection scrollingDirection;

        // Constants that define how many frames the animation will take/the step size of each new frame
        private const int frames = 80;
        private int currFrame = 0;

        public RoomSwapStateHandler(string fID, string tID, FacingDirection dir)
        {
            fromRoomID = fID;
            toRoomID = tID;
            scrollingDirection = dir;

            fromRoom = RoomManager.Instance.LoadRoom(fromRoomID);
            toRoom = RoomManager.Instance.LoadRoom(toRoomID);

            fromRoom.PrepareForTransition();
            toRoom.PrepareForTransition();

            fromRoomOriginDrawPoint = fromRoom.roomDrawPoint;
            toRoomOriginDrawPoint = new Vector2(fromRoomOriginDrawPoint.X, fromRoomOriginDrawPoint.Y);

            switch(scrollingDirection)
            {
                // Current room moves to the right, new room appears from left
                case FacingDirection.Right:
                    toRoomOriginDrawPoint += new Vector2(-horizontalScrollDist, 0);
                    break;
                case FacingDirection.Left:
                    toRoomOriginDrawPoint += new Vector2(horizontalScrollDist, 0);
                    break;

                // Current room moves up, new room appears from bottom
                case FacingDirection.Up:
                    toRoomOriginDrawPoint += new Vector2(0, verticalScrollDist);
                    break;
                case FacingDirection.Down:
                    toRoomOriginDrawPoint += new Vector2(0, -verticalScrollDist);
                    break;
                default:
                    break;
            }

            
            toRoom.UpdateDrawPoint(toRoomOriginDrawPoint);
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            if (currFrame <= frames)
            {
                Vector2 step;

                switch (scrollingDirection)
                {
                    // Current room moves to the right, new room appears from left
                    case FacingDirection.Right:
                        step = new Vector2(horizontalScrollDist / frames, 0);
                        break;

                    case FacingDirection.Left:
                        step = new Vector2(-horizontalScrollDist / frames, 0);
                        break;

                    // Current room moves up, new room appears from bottom
                    case FacingDirection.Up:
                        step = new Vector2(0, -verticalScrollDist / frames);
                        break;
                    case FacingDirection.Down:
                        step = new Vector2(0, verticalScrollDist / frames);
                        break;
                    default:
                        step = new Vector2();
                        break;
                }

                fromRoom.UpdateDrawPoint(fromRoom.roomDrawPoint + step);
                toRoom.UpdateDrawPoint(toRoom.roomDrawPoint + step);

                fromRoom.Draw(sb);
                toRoom.Draw(sb);

                currFrame++;
            } else
            {
                // Do whatever needed to swap game states
                currFrame = 0;
                fromRoom.TransitionEnded();
                toRoom.TransitionEnded();

                RoomManager.Instance.SwitchToRoom(toRoomID);
                GameStateManager.Instance.StartGameplay();
            }

            
        }

        public void Update(GameTime gameTime)
        {
            toRoom.Update(gameTime);
            fromRoom.Update(gameTime);
        }
    }
}
