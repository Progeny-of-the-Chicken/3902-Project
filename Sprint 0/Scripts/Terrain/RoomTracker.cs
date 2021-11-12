using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Terrain
{
    public class RoomTracker
    {
        // Room coords, known used doors
        private Dictionary<Vector2, HashSet<FacingDirection>> trackedRooms;

        private static RoomTracker instance = new RoomTracker();

        public Dictionary<Vector2, HashSet<FacingDirection>> TrackedRooms { get => trackedRooms; }

        public static RoomTracker Instance
        {
            get
            {
                return instance;
            }
        }

        private RoomTracker()
        {
        }

        public void Init(string startRoom)
        {
            trackedRooms = new Dictionary<Vector2, HashSet<FacingDirection>>();
            trackedRooms.Add(ParseRoomString(startRoom), new HashSet<FacingDirection>());
        }

        public void RegisterRoom(string currentRoom, string nextRoom)
        {
            Vector2 currentRoomCoords = ParseRoomString(currentRoom);
            Vector2 nextRoomCoords = ParseRoomString(nextRoom);
            FacingDirection currentRoomDoorDirection = GetDirectionForVector(nextRoomCoords - currentRoomCoords);
            FacingDirection nextRoomDoorDirection = GetDirectionForVector(currentRoomCoords - nextRoomCoords);

            // Room
            if (!trackedRooms.ContainsKey(nextRoomCoords))
            {
                trackedRooms.Add(nextRoomCoords, new HashSet<FacingDirection>());
            }
            // Doors
            if (!trackedRooms[currentRoomCoords].Contains(currentRoomDoorDirection))
            {
                trackedRooms[currentRoomCoords].Add(currentRoomDoorDirection);
            }
            if (!trackedRooms[nextRoomCoords].Contains(nextRoomDoorDirection))
            {
                trackedRooms[nextRoomCoords].Add(nextRoomDoorDirection);
            }
        }

        //----- Helper methods to communicate with room manager -----//

        private FacingDirection GetDirectionForVector(Vector2 doorDirection)
        {
            return doorDirection switch
            {
                Vector2(1, 0) => FacingDirection.Right,
                Vector2(0, -1) => FacingDirection.Up,
                Vector2(-1, 0) => FacingDirection.Left,
                Vector2(0, 1) => FacingDirection.Down,
                // Should never happen
                _ => FacingDirection.Right
            };
        }

        private Vector2 ParseRoomString(string room)
        {
            return new Vector2(room[ObjectConstants.roomStringXIndex], room[ObjectConstants.roomStringYIndex]);
        }
    }
}
