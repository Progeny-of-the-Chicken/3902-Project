using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.InventoryState.Display
{
    public class DiscoveredRoomsDisplay : IDisplay
    {
        // Sprite, sprite location and known used doors
        private Dictionary<ISprite, (Vector2, HashSet<FacingDirection>)> discoveredRooms;
        private ISprite playerDotSprite;
        private Vector2 playerDotLocation;
        private bool compass = Inventory.Instance.Compass;

        public DiscoveredRoomsDisplay()
        {
            discoveredRooms = new Dictionary<ISprite, (Vector2, HashSet<FacingDirection>)>();
            if (compass)
            {
                InitializePlayerDotSprite();
            }
            AssembleRoomSprites();
        }

        public void Update(GameTime gt)
        {
            if (compass)
            {
                playerDotSprite.Update(gt);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            foreach (KeyValuePair<ISprite, (Vector2, HashSet<FacingDirection>)> discoveredRoom in discoveredRooms)
            {
                discoveredRoom.Key.Draw(spriteBatch, discoveredRoom.Value.Item1);
            }
            if (compass)
            {
                playerDotSprite.Draw(spriteBatch, playerDotLocation);
            }
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (KeyValuePair<ISprite, (Vector2, HashSet<FacingDirection>)> discoveredRoom in discoveredRooms)
            {
                discoveredRooms[discoveredRoom.Key] = (discoveredRooms[discoveredRoom.Key].Item1 + displacement, discoveredRooms[discoveredRoom.Key].Item2);
            }
        }

        //----- Initialization helper methods -----//

        private void InitializePlayerDotSprite()
        {
            playerDotSprite = InventorySpriteFactory.Instance.CreatePlayerDotSprite();
            playerDotLocation = GetLocationForRoomSprite(RoomTracker.Instance.ActiveRoomCoords) + ObjectConstants.playerDotOffsetFromRoom;
        }

        private void AssembleRoomSprites()
        {
            foreach (KeyValuePair<Vector2, HashSet<FacingDirection>> trackedRoom in RoomTracker.Instance.TrackedRooms)
            {
                discoveredRooms.Add(
                    // Sprite
                    InventorySpriteFactory.Instance.CreateDiscoveredRoomSprite(
                        GetRectangleForRoomSpriteIndex(GetIndexForRoomSprite(trackedRoom.Value))),
                    (
                        // Location
                        GetLocationForRoomSprite(trackedRoom.Key),
                        // Doors
                        trackedRoom.Value
                    )
                );
            }
        }

        private Vector2 GetLocationForRoomSprite(Vector2 roomCoords)
        {
            return ObjectConstants.backdropSpawnLocation + ObjectConstants.discoveredRoomsInitialLocationFromBackdrop
                + ObjectConstants.discoveredRoomsD1LocationOffset + (roomCoords * ObjectConstants.discoveredRoomsWidthHeight);
        }

        private int GetIndexForRoomSprite(HashSet<FacingDirection> doors)
        {
            // Algorithm taking advantage of source rectangle order in order to reflect known doors
            List<FacingDirection> orderedDoorsToCompare = new List<FacingDirection>
            {
                FacingDirection.Up, FacingDirection.Down, FacingDirection.Left, FacingDirection.Right
            };
            int index = ObjectConstants.discoveredRoomsMaxIndex;
            for (int i = orderedDoorsToCompare.Count - 1; i >= ObjectConstants.zero; i--)
            {
                if (doors.Contains(orderedDoorsToCompare[i]))
                {
                    index -= (int)Math.Pow(ObjectConstants.discoveredRoomsTotalDoorStates, i);
                }
            }
            return index;
        }

        private Rectangle GetRectangleForRoomSpriteIndex(int index)
        {
            Rectangle sourceRec = SpriteRectangles.discoveredRoomIndex0Frame;
            sourceRec.Location += new Vector2(index * ObjectConstants.discoveredRoomsSourcePixelDistance, 0).ToPoint();
            return sourceRec;
        }
    }
}
