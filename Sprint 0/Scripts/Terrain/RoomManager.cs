using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Terrain
{
    public class RoomManager : IRoomManager
    {
        private IRoom activeRoom;
        private Dictionary<string, IRoom> cachedRooms;
        private ILink link;

        private static RoomManager instance = new RoomManager();

        public static RoomManager Instance
        {
            get
            {
                return instance;
            }
        }

        private RoomManager()
        {
            cachedRooms = new Dictionary<string, IRoom>();
        }

        public void reset()
        {
            instance = new RoomManager();
            instance.Init(Link.Instance);
        }

        public void Init(ILink player)
        {
            this.link = player;
            activeRoom = LoadRoom(ObjectConstants.startRoom);
            RoomTracker.Instance.Init(activeRoom.RoomId());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeRoom.Draw(spriteBatch);
        }

        public void SwitchToRoom(string roomID)
        {
            activeRoom = LoadRoom(roomID);
        }

        public void Update(GameTime gt)
        {
            activeRoom.Update(gt);
        }

        public IRoom LoadRoom(string roomID)
        {
            if (!cachedRooms.ContainsKey(roomID))
            {
                cachedRooms.Add(roomID, new Room(roomID, link));
            }

            return cachedRooms[roomID];
        }

        public IRoom CurrentRoom
        {
            get
            {
                return activeRoom;
            }
        }
    }
}