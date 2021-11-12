using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0
{
    public static class ObjectConstants
    {
        //----- Sprite constant values -----//
        public const int scale = 3;
        public const double itemAnimationDelaySeconds = 0.1;
        public const int standardWidthHeight = 16;
        public const int scaledStdWidthHeight = scale * standardWidthHeight;

        //----- General constant values -----//
        public const int counterInitialVal_int = 0;
        public const float counterInitialVal_float = 0;
        public const double counterInitialVal_double = 0;
        public const double oneSecond_double = 1;
        public const float oneSecond_float = 1;
        public const float zero_float = 0;
        public const int zero_int = 0;
        public const double zero_double = 0;
        public const int PreferredBackBufferWidth = 256;
        public const int PreferredBackBufferHeight = 240;

        //----- Vector constant values -----//
        public static Vector2 UpUnitVector = new Vector2(0, -1);
        public static Vector2 DownUnitVector = new Vector2(0, 1);
        public static Vector2 LeftUnitVector = new Vector2(-1, 0);
        public static Vector2 RightUnitVector = new Vector2(1, 0);
        public static Vector2 zeroVector = new Vector2(0, 0);

        //----- Probability and random selection constant values -----//
        public const int oneInTwo = 2;
        public const int numberOfBytesForRandomDirection = 2;
        public const int oneInThree = 3;
        public const int oneInFour = 4;
        public const int oneInFive = 5;
        public const int adjustByNegativeOne = -1;
        public const int rgbHalfOfMax = 128;

        //----- Link constant values -----//
        public const int linkSpeed = 1;
        public const int linkStartingHealth = 6;
        public const int linkTurningCounterDebounce = 10;
        public const int linkDeathCounter = 90;
        public const int defaultCounterLength = 30;
        public const int bouncebackDistance = 90;
        public const int squareTileWidthHeight = 16;
        public static Vector2 linkStartingPosition = new Vector2(200, 400); //generic starting position

        //----- Item constant values -----//
        public const double clockFreezeSeconds = 10.0;

        //----- Projectile constant values -----//
        public static Rectangle standardProjectileSize = new Rectangle(0, 0, 8, 8);
        public static Rectangle swordAttackHitBoxSize = new Rectangle(0, 0, swordHitboxLength, swordHitboxWidth);
        // Arrow
        public const double arrowSpeedPerSecond = 150.0;
        public const int arrowMaxDistance = 200;
        public const double silverArrowSpeedCoef = 1.5;
        public const int arrowDamage = 1;
        public static Vector2 rightArrowPopOffset = new Vector2(4, -8);
        public static Vector2 upArrowPopOffset = new Vector2(-8, -20);
        public static Vector2 leftArrowPopOffset = new Vector2(-20, -8);
        public static Vector2 downArrowPopOffset = new Vector2(-8, 4);
        public static Vector2 arrowRotationOffset = new Vector2(8, 2.5f);
        // BlastZone
        public const int blastZonePositionOffset = -8;
        public const int blastZoneWidthHeight = 32;
        public const int blastZoneCounter = 1;
        public const int blastZoneDamage = 1;
        public static Rectangle blastZoneSize = new Rectangle(0, 0, blastZoneWidthHeight, blastZoneWidthHeight);
        // Bomb
        public const int bombDisplacement = 16 * scale;
        public const double bombFuseDurationSeconds = 2.0;
        // Boomerang
        public const double boomerangSpeedPerSecond = 10.0;
        public const double boomerangDecelPerSecond = -5.0;
        public const double magicalBoomerangSpeedCoef = 1.2;
        public const double boomerangTOffset = 1;
        public const int boomerangDamage = 1;
        public static Vector2 boomerangRotationOffset = new Vector2(4, 4);
        // FireSpell
        public const double fireSpellSpeedPerSecond = 150.0;
        public const int fireSpellMaxDistance = 200;
        public const double fireSpellLingerDuration = 2.0;
        public const int fireSpellDamage = 1;
        // SwordAttackHitbox
        public const int swordHitboxCounter = 17;
        public const int swordHitboxLength = 11;
        public const int swordHitboxWidth = 3;
        public const int basicSwordDamage = 1;
        //Magic projectile
        public const float magicProjectileSpread = 0.3f;
        public const double magicProjectileSpeed = 150;
        public const double magicProjectileLifetime = 3.0;
        public const int magicProjectileDamage = DefaultEnemyDamage;

        //----- Enemy constant values -----//
        //Default
        public const int DefaultEnemyDamage = 1;
        public const int DefaultEnemyHealth = 1;
        public const int DefaultEnemyKnockback = 2 * scale * standardWidthHeight;
        public const float DefaultEnemyMoveSpeed = 2 * scale * standardWidthHeight;
        public const double DefaultEnemyMoveTime = 1.0;
        public const double DefaultEnemyPauseTime = 1.0;
        //Aquamentus
        public const int AquamentusDamage = DefaultEnemyDamage;
        public const float AquamentusMoveDistance = 2 * scale * standardWidthHeight;
        public const float AquamentusMoveSpeed = DefaultEnemyMoveSpeed;
        public const double AquamentusShootSpriteTime = 0.5f;
        public const int AquamentusStartingHealth = 1;
        //Gel
        public const int GelDamage = DefaultEnemyDamage;
        public const double GelMoveTime = DefaultEnemyMoveTime;
        public const float GelMoveSpeed = DefaultEnemyMoveSpeed;
        public const double GelPauseTime = DefaultEnemyPauseTime;
        public const int GelStartingHealth = DefaultEnemyHealth;
        //Goriya
        public const int GoriyaDamage = DefaultEnemyDamage;
        public const double GoriyaMoveTime = 1.5;
        public const float GoriyaMoveSpeed = DefaultEnemyMoveSpeed;
        public const int GoriyaStartingHealth = DefaultEnemyHealth;
        //Keese
        public const int KeeseDamage = DefaultEnemyDamage;
        public const double KeeseMoveTime = DefaultEnemyMoveTime;
        public const float KeeseMoveSpeed = DefaultEnemyMoveSpeed;
        public const int KeeseStartingHealth = DefaultEnemyHealth;
        //OldMan
        public const int OldManDamage = 0;
        public const int OldManStartingHealth = 1;
        //Stalfos
        public const int StalfosDamage = DefaultEnemyDamage;
        public const double StalfosMoveTime = DefaultEnemyMoveTime;
        public const float StalfosMoveSpeed = DefaultEnemyMoveSpeed;
        public const int StalfosStartingHealth = DefaultEnemyHealth;
        //Zol
        public const int ZolDamage = DefaultEnemyDamage;
        public const double ZolMoveTime = DefaultEnemyMoveTime;
        public const float ZolMoveSpeed = DefaultEnemyMoveSpeed;
        public const double ZolPauseTime = DefaultEnemyPauseTime;
        public const int ZolStartingHealth = DefaultEnemyHealth;
        //SpikeTrap
        public const int vectorFlip = -1;
        public const int spikeTrapSpeed = 25 * scale;
        //WallMaster
        public const int WallMasterHealth = 3;
        public const float WallMasterTimeToMoveAgain = 1;
        public const float WallMasterMoveSpeed = DefaultEnemyMoveSpeed;
        //Sprites
        public const float DefaultEnemyFramesPerSecond = 4;
        public const int firstFrame = 0;
        public const int firstInArray = 0;
        public const int secondDoorInArray = 2;
        public const int thirdDoorInArray = 4;
        public const int fourthDoorInArray = 6;
        public const int secondInArray = 1;
        public const float zeroRotation = 0;
        public const double degreeRotationCW90_s = Math.PI / 2;
        public const double degreeRotationCW180_s = Math.PI;
        public const double degreeRotationCW270_s = (3 * Math.PI) / 2;
        public const float noLayerDepth = 0;
        public const int nextInArray = 1;

        //----- Collision constant values -----//
        public static Vector2 degreeRotationCW90_v = new Vector2(0, -1);
        public static Vector2 degreesRotationCW180_v = new Vector2(-1, -1);
        public static Vector2 degreesRotationCW270_v = new Vector2(-1, 0);
        public const int zero = 0;
        public const int xOnScreenBorder = 0;

        //----- string constant values -----//
        public const string secretRoom = "Room00";
        public const string wallMasterToRoom = "Room25";
        public const string enemiesFile = "enemies";
        public const string npcFile = "npc";
        public const string bossesFile = "bosses";
        public const string itemFile = "LoZItems";
        public const string projectileFile = "LoZSprites";
        public const string linkFile = "LinkSpriteSheet";
        public const string pathForCsvFiles = @"/../../../Scripts/Terrain/LevelData/Dungeon1/";
        public const string cvsExtension = ".csv";
        public const string separator = ",";
        public const string lineIsEmpty = "None";
        public const string emptyStr = "";
        public const string spaceStr = " ";
        public const string AquamentusStr = "Aquamentus";
        public const string BladeTrapStr = "BladeTrap";
        public const string GelStr = "Gel";
        public const string GoriyaStr = "Goriya";
        public const string KeeseStr = "Keese";
        public const string OldManStr = "OldMan";
        public const string StalfosStr = "Stalfos";
        public const string WallMasterStr = "WallMaster";
        public const string ZolStr = "Zol";
        public const string BowItemStr = "BowItem";
        public const string CompassStr = "Compass";
        public const string HeartContainerStr = "HeartContainer";
        public const string KeyStr = "Key";
        public const string MapStr = "Map";
        public const string TriforcePieceStr = "TriforcePiece";
        public const string typoInRoomMessage = "Typo in Room ";
        public const string EastClosedSpriteStr = "EastClosedSprite";
        public const string NorthClosedSpriteStr = "NorthClosedSprite";
        public const string WestClosedSpriteStr = "WestClosedSprite";
        public const string SouthClosedSpriteStr = "SouthClosedSprite";
        public const string MoveableBlockSpriteStr = "MoveableBlockSprite";
        public const string StairSpriteStr = "StairSprite";
        public const string EastDoorSpriteStr = "EastDoorSprite";
        public const string NorthDoorSpriteStr = "NorthDoorSprite";
        public const string WestDoorSpriteStr = "WestDoorSprite";
        public const string SouthDoorSpriteStr = "SouthDoorSprite";
        //TODO: start in start room
        public const string startRoom = "Room20";
        public static string[] rooms = new string[] {"Room25", "Room15", "Room35", "Room24", "Room23", "Room33", "Room13", "Room12", "Room02", "Room22", "Room21", "Room20", "Room10", "Room00", "Room32", "Room42", "Room41",
"Room51"};
        public const string contentLocation = "Content";
        public const string OverworldTilesetStr = "OverworldTileset";
        public const string dungeonTilesetStr = "dungeonTileset";
        public const string Dungeon1EagleStr = "Dungeon1Eagle";
        public const string EastBombableSpriteStr = "EastBombableSprite";
        public const string EastBombedSpriteStr = "EastBombedSprite";
        public const string EastLockedSpriteStr = "EastLockedSprite";
        public const string EastWallSpriteStr = "EastWallSprite";
        public const string NorthBombableSpriteStr = "NorthBombableSprite";
        public const string NorthBombedSpriteStr = "NorthBombedSprite";
        public const string NorthLockedSpriteStr = "NorthLockedSprite";
        public const string NorthWallSpriteStr = "NorthWallSprite";
        public const string WestBombableSpriteStr = "WestBombableSprite";
        public const string WestBombedSpriteStr = "WestBombedSprite";
        public const string WestLockedSpriteStr = "WestLockedSprite";
        public const string WestWallSpriteStr = "WestWallSprite";
        public const string SouthBombableSpriteStr = "SouthBombableSprite";
        public const string SouthBombedSpriteStr = "SouthBombedSprite";
        public const string SouthLockedSpriteStr = "SouthLockedSprite";
        public const string SouthWallSpriteStr = "SouthWallSprite";

        //----- wall/block constant values -----//
        public const int wallOffset = scale * standardWidthHeight * 2;
        public const int yOffsetForRoom = scale * standardWidthHeight * 4;
        public const int rowParsePosition = 5;
        public const int colParsePosition = 4;
        public const int rowAndColPraseLen = 1;
        public const int xOffsetForRoom = 0;
        public const int roomWidth = 256;
        public const int roomHeight = 176;
        public const int roomWidthForScanIn = 257;
        public const int roomHeightForScanIn = 177;
        public const int roomReadInAdjustment = 1;
        public const int coordinateReadInAdjustment = 2;
        public const int nextCharInString = 1;
        public const int xPosForParse = 0;
        public const int xPosForDoorOrigin = 0;
        public const int xPosForDoorRight = 144;
        public const int xPosForDoorTop = 224;
        public const int yPosForDoorBottom = 104;
        public const int yPosForDoorLeft = 144;
        public const int yPosForDoorEast = 72;
        public const int xPosForDoorNorth = 112;
        public const int EastDoorSpritePos = 8;
        public const int NorthDoorSpritePos = 9;
        public const int WestDoorSpritePos = 10;
        public const int SouthDoorSpritePos = 11;
        public const int wallHitBoxHalfSize = standardWidthHeight / 2;
        public const int wallHitBoxSize = standardWidthHeight;
        //----- Effect constant values -----//
        public const double popDurationSeconds = 0.2;
        public const double explosionDurationSeconds = 0.3;
        public const double bombExtraExplosionOffset = 16 * scale;
        public const double bombExtraExplosionNumber = 6;

        //----- Inventory GUI constant values -----//
        public const string inventorySpritesheetFileName = "InventorySpritesheetAdjusted";
        public const int inventoryDisplayListIndex = 1;
        // Backdrop
        public static Vector2 backdropSpawnLocation = Vector2.Zero;
        public static Vector2 mapBackdropFromBackdrop = new Vector2(0, 88) * scale;
        // Weapon
        public static Vector2 weaponFromBackdropLocation = new Vector2(132, 48) * scale;
        public static Vector2 selectionWeaponFromBackdropLocation = new Vector2(68, 48) * scale;
        public static Vector2 mapFromBackdropLocation = new Vector2(48, 112) * scale;
        public static Vector2 compassFromBackdropLocation = new Vector2(44, 152) * scale;
        public static List<Vector2> inventoryWeaponLocations = new List<Vector2>
        {
            new Vector2()
        };
        public const int inventoryWeaponListStartIndex = 0;
        // Selection
        public static List<Vector2> inventorySlotLocations = new List<Vector2>
        {
            new Vector2(128, 48) * scale,
            new Vector2(152, 48) * scale,
            new Vector2(176, 48) * scale,
            new Vector2(200, 48) * scale,
            new Vector2(128, 64) * scale,
            new Vector2(152, 64) * scale,
            new Vector2(176, 64) * scale,
            new Vector2(200, 64) * scale
        };
        public static Vector2 inventoryWeaponFromSlotOffset = new Vector2(4, 0) * scale;
        public const int inventoryMoveSelectionRightIndex = 1;
        public const int inventoryMoveSelectionUpIndex = -4;
        public const int inventoryMoveSelectionLeftIndex = -1;
        public const int inventoryMoveSelectionDownIndex = 4;
        public const int selectedItemStartingIndex = 0;

        //----- RoomTracker constant values -----//
        public const int roomStringXIndex = 4;
        public const int roomStringYIndex = 5;
    }
}
