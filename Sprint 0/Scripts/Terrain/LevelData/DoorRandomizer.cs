using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Terrain
{
    
    class DoorRandomizer
    {
        const int numConnections = ObjectConstants.numberOfConnections;
        int roomsWithAllowableDoors = ObjectConstants.numberOfConnectableRooms;
        int numKeys = 0;
        string[, ,] doorStrings = new String[ObjectConstants.randoDungeonHeightWidth, ObjectConstants.randoDungeonHeightWidth, ObjectConstants.randoDungeonHeightWidth];
        bool[,,] doorAvailability = new bool[ObjectConstants.randoDungeonHeightWidth, ObjectConstants.randoDungeonHeightWidth, ObjectConstants.numDoorsInRoom];
        private static DoorRandomizer instance = new DoorRandomizer();

        public static DoorRandomizer Instance
        {
            get
            {
                return instance;
            }
        }

        private DoorRandomizer()
        {
            randomizeDoors();
        }

        private void randomizeDoors()
        {
            //To keep track of what rooms need to be added
            List<Vector2> inDungeon = new List<Vector2>();
            List<Vector2> notInDungeon = new List<Vector2>();
            InitalizeRandomizerVariables(inDungeon, notInDungeon);

            var rand = new Random();

            for (int j = 0; j < numConnections; j++)
            {
                //Find room to add door to
                int randInt = rand.Next(inDungeon.Count);
                Vector2 roomToAddToPos = inDungeon[randInt];

                //Make sure there is an available slot to place the door
                bool roomIsAvailable = false;
                for (int i = 0; i < ObjectConstants.numDoorsInRoom; i++)
                {
                    roomIsAvailable |= IsDoorAvailableInRoom(roomToAddToPos, i);
                }
                if (!roomIsAvailable)
                {
                    //All doors in this room have been taken, reduce counter and skip to next attempt
                    roomsWithAllowableDoors--;
                    inDungeon.Remove(roomToAddToPos);
                    j--;
                    continue;
                }

                //Pick next room
                randInt = rand.Next(roomsWithAllowableDoors);
                if (randInt < inDungeon.Count)
                {
                    Vector2 roomConnectingPos = inDungeon[randInt];
                    //Pick door from originating room
                    randInt = rand.Next(ObjectConstants.numDoorsInRoom);
                    //Connecting to room that already has a door
                    while (!IsDoorAvailableInRoom(roomToAddToPos, randInt))
                    {
                        randInt = (randInt + 1) % ObjectConstants.numDoorsInRoom;
                    }
                    int randInt2 = (randInt + (ObjectConstants.numDoorsInRoom / 2)) % ObjectConstants.numDoorsInRoom; 
                    if (!IsDoorAvailableInRoom(roomConnectingPos, randInt2))
                    {
                        //The opposite door to the available one was taken, reduce counter and skip to next attempt
                        j--;
                        continue;
                    } else
                    {
                        AddConnectingDoors(roomToAddToPos, randInt, roomConnectingPos, randInt2);
                    }

                } else
                {
                    //Connecting to new room
                    randInt -= inDungeon.Count;
                    Vector2 roomConnectingPos = notInDungeon[randInt];
                    notInDungeon.RemoveAt(randInt);

                    //Pick doors to add to
                    randInt = rand.Next(ObjectConstants.numDoorsInRoom);
                    while (!IsDoorAvailableInRoom(roomToAddToPos, randInt))
                    {
                        randInt = (randInt + 1) % ObjectConstants.numDoorsInRoom;
                    }
                    int randInt2 = (randInt + (ObjectConstants.numDoorsInRoom / 2)) % ObjectConstants.numDoorsInRoom;
                    AddConnectingDoors(roomToAddToPos, randInt, roomConnectingPos, randInt2);
                    CheckIfNewRoomHasKey(roomConnectingPos);
                    inDungeon.Add(roomConnectingPos);
                }

            }

        }

        private void CheckIfNewRoomHasKey(Vector2 roomConnectingPos)
        {
            if (ObjectConstants.roomsWithKeys.Contains(roomConnectingPos)) numKeys++;
        }

        private bool IsDoorAvailableInRoom(Vector2 roomToAddTo, int doorNum)
        {
            return doorAvailability[(int)roomToAddTo.X, (int)roomToAddTo.Y, doorNum];
        }

        private void InitalizeRandomizerVariables(List<Vector2> inDungeon, List<Vector2> notInDungeon)
        {
            inDungeon.Add(ObjectConstants.randomizeDungeonStartRoom);

            //Initialize notInDungeon
            for (int i = 0; i < ObjectConstants.randoDungeonHeightWidth; i++)
            {
                for (int j = 0; j < ObjectConstants.randoDungeonHeightWidth; j++)
                {
                    notInDungeon.Add(new Vector2(i, j));

                }
            }

            //Remove special rooms
            notInDungeon.Remove(ObjectConstants.randomizeDungeonSideOnRoom);
            notInDungeon.Remove(ObjectConstants.randomizeDungeonTreasureRoom1);
            notInDungeon.Remove(ObjectConstants.randomizeDungeonTreasureRoom2);
            notInDungeon.Remove(ObjectConstants.randomizeDungeonStartRoom);

            //Initialize DoorAvailability
            for (int i = 0; i < ObjectConstants.randoDungeonHeightWidth; i++)
            {
                for (int j = 0; j < ObjectConstants.randoDungeonHeightWidth; j++)
                {
                    for (int k = 0; k < ObjectConstants.numDoorsInRoom; k++)
                    {
                        doorAvailability[i, j, k] = true;
                    }
                }
            }

            for (int i = 0; i < ObjectConstants.randoDungeonHeightWidth; i++)
            {
                for (int j = 0; j < ObjectConstants.randoDungeonHeightWidth; j++)
                {
                    for (int k = 0; k < ObjectConstants.randoDungeonHeightWidth; k++)
                    {
                        doorStrings[i, j, k] = ObjectConstants.emptyStr;
                    }
                }
            }

            //Bosses always lead to treasure rooms
            doorStrings[(int) ObjectConstants.randomizeDungeonBossRoom1.X, (int)ObjectConstants.randomizeDungeonBossRoom1.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastClosedSpriteStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonBossRoom1.X, (int)ObjectConstants.randomizeDungeonBossRoom1.Y, ObjectConstants.eastDoorRandomizerArrayLocation + 1] = ObjectConstants.randomizeDungeonTreasureRoom1Str;
            doorAvailability[(int)ObjectConstants.randomizeDungeonBossRoom1.X, (int)ObjectConstants.randomizeDungeonBossRoom1.Y, ObjectConstants.eastDoorRandomizerArrayLocation / 2] = false;
            doorStrings[(int) ObjectConstants.randomizeDungeonTreasureRoom1.X, (int) ObjectConstants.randomizeDungeonTreasureRoom1.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestDoorSpriteStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonTreasureRoom1.X, (int)ObjectConstants.randomizeDungeonTreasureRoom1.Y, ObjectConstants.westDoorRandomizerArrayLocation + 1] = ObjectConstants.randomizeDungeonBossRoom1Str;
            doorAvailability[(int)ObjectConstants.randomizeDungeonTreasureRoom1.X, (int)ObjectConstants.randomizeDungeonTreasureRoom1.Y, ObjectConstants.westDoorRandomizerArrayLocation / 2] = false;
            doorStrings[(int)ObjectConstants.randomizeDungeonBossRoom2.X, (int)ObjectConstants.randomizeDungeonBossRoom2.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastClosedSpriteStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonBossRoom2.X, (int)ObjectConstants.randomizeDungeonBossRoom2.Y, ObjectConstants.eastDoorRandomizerArrayLocation + 1] = ObjectConstants.randomizeDungeonTreasureRoom1Str;
            doorAvailability[(int)ObjectConstants.randomizeDungeonBossRoom2.X, (int)ObjectConstants.randomizeDungeonBossRoom2.Y, ObjectConstants.eastDoorRandomizerArrayLocation / 2] = false;
            doorStrings[(int)ObjectConstants.randomizeDungeonTreasureRoom2.X, (int)ObjectConstants.randomizeDungeonTreasureRoom2.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestDoorSpriteStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonTreasureRoom2.X, (int)ObjectConstants.randomizeDungeonTreasureRoom2.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.randomizeDungeonBossRoom2Str;
            doorAvailability[(int) ObjectConstants.randomizeDungeonTreasureRoom2.X, (int)ObjectConstants.randomizeDungeonTreasureRoom2.Y, ObjectConstants.westDoorRandomizerArrayLocation / 2] = false;
            doorStrings[(int) ObjectConstants.randomizeDungeonSideOnRoom.X, (int)ObjectConstants.randomizeDungeonSideOnRoom.Y, (int)ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.InvisibleWallStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonSideOnRoom.X, (int)ObjectConstants.randomizeDungeonSideOnRoom.Y, (int)ObjectConstants.northDoorRandomizerArrayLocation] = ObjectConstants.InvisibleWallStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonSideOnRoom.X, (int)ObjectConstants.randomizeDungeonSideOnRoom.Y, (int)ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.InvisibleWallStr;
            doorStrings[(int)ObjectConstants.randomizeDungeonSideOnRoom.X, (int)ObjectConstants.randomizeDungeonSideOnRoom.Y, (int)ObjectConstants.southDoorRandomizerArrayLocation] = ObjectConstants.InvisibleWallStr;
        }

        //This assumes adding this door to this room is valid
        private void AddConnectingDoors(Vector2 roomLocation1, int doorLocation1, Vector2 roomLocation2, int doorLocation2)
        {
            doorAvailability[(int)roomLocation1.X, (int)roomLocation1.Y, doorLocation1] = false;
            doorAvailability[(int)roomLocation2.X, (int)roomLocation2.Y, doorLocation2] = false;

            var rand = new Random();
            int addKey = rand.Next(ObjectConstants.maxKeysBeforeForcedDoor);

            if (addKey > numKeys)
            {
                switch (doorLocation1)
                {
                    case 0:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastDoorSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.eastDoorRandomizerArrayLocation+1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 1:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.northDoorRandomizerArrayLocation] = ObjectConstants.NorthDoorSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.northDoorRandomizerArrayLocation+1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 2:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestDoorSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.westDoorRandomizerArrayLocation+1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 3:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.southDoorRandomizerArrayLocation] = ObjectConstants.SouthDoorSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.southDoorRandomizerArrayLocation+1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                }
                switch (doorLocation2)
                {
                    case 0:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastDoorSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.eastDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 1:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.northDoorRandomizerArrayLocation] = ObjectConstants.NorthDoorSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.northDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 2:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestDoorSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.westDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 3:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.southDoorRandomizerArrayLocation] = ObjectConstants.SouthDoorSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.southDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                }
            }

            // This is the same exact switch as the one above except it adds two locked doors instead
            else
            {
                numKeys--;
                switch (doorLocation1)
                {
                    case 0:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastLockedSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.eastDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 1:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.northDoorRandomizerArrayLocation] = ObjectConstants.NorthLockedSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.northDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 2:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestLockedSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.westDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                    case 3:
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.southDoorRandomizerArrayLocation] = ObjectConstants.SouthLockedSpriteStr;
                        doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, ObjectConstants.southDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation2.X + roomLocation2.Y;
                        break;
                }
                switch (doorLocation2)
                {
                    case 0:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.eastDoorRandomizerArrayLocation] = ObjectConstants.EastLockedSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.eastDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 1:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.northDoorRandomizerArrayLocation] = ObjectConstants.NorthLockedSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.northDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 2:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.westDoorRandomizerArrayLocation] = ObjectConstants.WestLockedSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.westDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                    case 3:
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.southDoorRandomizerArrayLocation] = ObjectConstants.SouthLockedSpriteStr;
                        doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, ObjectConstants.southDoorRandomizerArrayLocation + 1] = ObjectConstants.roomPrefixStr + roomLocation1.X + roomLocation1.Y;
                        break;
                }
            }
        }

        public string[] getDoorsForRoom(Vector2 roomLocation)
        {
            string[] returnArray = new string[ObjectConstants.randoDungeonHeightWidth];
            for (int i = 0; i < ObjectConstants.randoDungeonHeightWidth; i++)
            {
                returnArray[i] = doorStrings[(int)roomLocation.X, (int)roomLocation.Y, i];
            }
            return returnArray;
        }
    }
}
