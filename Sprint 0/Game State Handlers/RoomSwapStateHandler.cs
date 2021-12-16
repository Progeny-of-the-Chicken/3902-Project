using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public class RoomSwapStateHandler: IGameStateHandler
    {
        private const int verticalScrollDist = ObjectConstants.roomswapAnimationVerticalScrollDist;
        private const int horizontalScrollDist = ObjectConstants.roomswapAnimationHorizontalScrollDist;
        private Vector2 toRoomOriginDrawPoint;
        private Vector2 fromRoomOriginDrawPoint;
        private HUD headsUpDisplay;

        private string fromRoomID;
        private string toRoomID;
        private IRoom toRoom;
        private IRoom fromRoom;
        private FacingDirection scrollingDirection;
        private Link link;

        // Constants that define how many frames the animation will take/the step size of each new frame
        private const int frames = ObjectConstants.roomswapAnimationDurationInFrames;
        private int currFrame = 0;


        public RoomSwapStateHandler(string fID, string tID, FacingDirection dir, Link l)
        {
            fromRoomID = fID;
            toRoomID = tID;
            scrollingDirection = dir;
            link = l;
            headsUpDisplay = new HUD(ObjectConstants.counterInitialVal_int);

            fromRoom = RoomManager.Instance.LoadRoom(fromRoomID);
            toRoom = RoomManager.Instance.LoadRoom(toRoomID);

            link.Suspend();
            fromRoom.PrepareForTransition(true);
            toRoom.PrepareForTransition(false);

            fromRoomOriginDrawPoint = fromRoom.roomDrawPoint;
            toRoomOriginDrawPoint = calculateEnteringRoomOriginDrawPoint();

            toRoom.UpdateDrawPoint(toRoomOriginDrawPoint);
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {

            if (currFrame <= frames)
            {
                Vector2 step = calculateStep();

                fromRoom.UpdateDrawPoint(fromRoom.roomDrawPoint + step);
                toRoom.UpdateDrawPoint(toRoom.roomDrawPoint + step);

                fromRoom.Draw(sb);
                toRoom.Draw(sb);

                currFrame++;
            } else
            {
                // Do whatever needed to return to Gameplay
                currFrame = 0;
                fromRoom.TransitionEnded();
                toRoom.TransitionEnded();

                setSpawnPostion();

                RoomManager.Instance.SwitchToRoom(toRoomID);
                GameStateManager.Instance.StartGameplay();
                link.UnSuspend();
            }
            
            headsUpDisplay.Draw(sb);
            
        }

        public void Update(GameTime gameTime)
        {
            link.Update(gameTime);
            toRoom.Update(gameTime);
            fromRoom.Update(gameTime);
        }

        public void TogglePause() { /*Unused*/ }
        public void DialogueNext() { /*Unused*/ }
        public void ClearDialogue() { /*Unused*/ }
        public void AddDialogue(string[] dia) { /*Unused*/ }
        public void SetSuspended(bool sus) { /*Unused*/ }

        /*--------------- Helper Methods ---------------*/


        // Method that calculates the initial position of the room link is entering
        // for the animation. Will start off screen and be animated onto the screen.
        private Vector2 calculateEnteringRoomOriginDrawPoint()
        {
            Vector2 result = new Vector2(fromRoomOriginDrawPoint.X, fromRoomOriginDrawPoint.Y);

            switch (scrollingDirection)
            {
                // Current room moves to the right, new room appears from left
                case FacingDirection.Right:
                    result += new Vector2(-horizontalScrollDist, 0);
                    break;
                case FacingDirection.Left:
                    result += new Vector2(horizontalScrollDist, 0);
                    break;

                // Current room moves up, new room appears from bottom
                case FacingDirection.Up:
                    result += new Vector2(0, verticalScrollDist);
                    break;
                case FacingDirection.Down:
                    result += new Vector2(0, -verticalScrollDist);
                    break;
                default:
                    break;
            }

            return result;
        }

        // Method that sets link's spawn point in the room he enters
        private void setSpawnPostion()
        {
            Vector2 spawnPos;
            int scale = ObjectConstants.scale;
            int YOFFSET = ObjectConstants.yOffsetForRoom;
            int tileSize = ObjectConstants.standardWidthHeight * scale;

            switch (scrollingDirection)
            {
                case FacingDirection.Right:
                    spawnPos = new Vector2(ObjectConstants.xPosForEastDoor * scale - tileSize, ObjectConstants.yPosForEastWestDoor * scale + YOFFSET + (tileSize / 2));
                    break;
                case FacingDirection.Left:
                    spawnPos = new Vector2(ObjectConstants.xPosForWestDoor * scale + (tileSize * 2), ObjectConstants.yPosForEastWestDoor * scale + YOFFSET + (tileSize / 2));
                    break;
                case FacingDirection.Up:
                    spawnPos = new Vector2(ObjectConstants.xPosForNorthSouthDoor * scale + (tileSize / 2), ObjectConstants.yPosForNorthDoor * scale + YOFFSET + 2 * tileSize);
                    break;
                case FacingDirection.Down:
                    spawnPos = new Vector2(ObjectConstants.xPosForNorthSouthDoor * scale + (tileSize / 2), ObjectConstants.yPosForSouthDoor * scale + YOFFSET - tileSize);
                    break;
                default:
                    spawnPos = new Vector2();
                    break;
            }

            link.ResetPosition(spawnPos);
        }

        // Determines the step size and direction that should be animated each frame
        private Vector2 calculateStep()
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

            return step;
        }
    }
}
