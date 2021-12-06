using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;

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
        public const int PreferredBackBufferHeight = 232;
        public static Rectangle nullRectangle = new Rectangle(0, 0, 0, 0);


        //----- Game state constants -----//
        public static char[] pausedLetters = { 'p', 'a', 'u', 's', 'e', 'd' };
        public const int pauseDisplayStartingPointX = 232;
        public const int pauseDisplayStartingPointY = 400;
        public const int bombsFromDrop = 4;


        //----- Vector constant values -----//
        public static Vector2 UpUnitVector = new Vector2(0, -1);
        public static Vector2 DownUnitVector = new Vector2(0, 1);
        public static Vector2 LeftUnitVector = new Vector2(-1, 0);
        public static Vector2 RightUnitVector = new Vector2(1, 0);
        public static Vector2 UpLeftUnitVector = new Vector2(-1, -1);
        public static Vector2 UpRightUnitVector = new Vector2(1, -1);
        public static Vector2 DownLeftUnitVector = new Vector2(-1, 1);
        public static Vector2 DownRightUnitVector = new Vector2(1, 1);
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
        public const int linkStdMoveDist = scaledStdWidthHeight / 2;
        public const float linkStdMoveTime = 0.25f;
        // TODO: Remove doubled move speed, helpful for testing
        public const float linkSpeed = linkStdMoveDist / linkStdMoveTime * 2;
        public const float linkDeathAnimationTime = 1.5f;
        public const float linkTakeDamageTime = 1;
        public const float linkUseItemTime = 0.5f;
        public const float linkPickUpItemTime = 1f;
        public const float linkSwordSheathTime = 5f;
        public const float linkFrameChangeFreq = 0.05f;
        public const float linkItemPickUpFrameChangeFreq = 0.2f;
        public const int linkStartingHealth = 12;
        public const float linkTurningCounterDebounce = 0.05f;
        public const float linkDeathCounter = 3;
        public const int defaultCounterLength = 30;
        public static Vector2 linkStartingPosition = new Vector2(358, 408); //generic starting position
        public const float lowHealthThreshold = 3;
        public const int linkWidthHeight = 16 * scale;


        //----- Item constant values -----//
        public const float clockFreezeSeconds = 10.0f;


        //----- Projectile constant values -----//
        public static Rectangle standardProjectileSize = new Rectangle(0, 0, 8, 8);
        public static Rectangle swordAttackHitBoxSize = new Rectangle(0, 0, swordHitboxLength, swordHitboxWidth);
        public const int linkSwordFromRightCenter = 3 * scale;
        public const int linkSwordFromUpCenter = -4 * scale;
        public const int linkSwordFromLeftCenter = -3 * scale;
        public const int linkSwordFromDownCenter = 3 * scale;

        // Projectile
        public const float shotgunPelletSpeed = scaledStdWidthHeight * 15;
        public const int shotgunPelletDamage = 5;


        // Arrow
        public const double arrowSpeedPerSecond = 100.0 * scale;
        public const int arrowMaxDistance = 100 * scale;
        public const double silverArrowDistanceCoef = 1.5;
        public const int arrowDamage = 1;
        public static Vector2 rightArrowPopOffset = new Vector2(4, -8);
        public static Vector2 upArrowPopOffset = new Vector2(-8, -20);
        public static Vector2 leftArrowPopOffset = new Vector2(-20, -8);
        public static Vector2 downArrowPopOffset = new Vector2(-8, 4);
        public static Vector2 arrowRotationOffset = new Vector2(8, 2.5f);
        public static Vector2 arrowWidthHeight = new Vector2(16, 5) * scale;

        // BlastZone
        public const int blastZonePositionOffset = -8;
        public const int blastZoneWidthHeight = 32;
        public const int blastZoneCounter = 1;
        public const int blastZoneDamage = 3;
        public static Rectangle blastZoneSize = new Rectangle(0, 0, blastZoneWidthHeight, blastZoneWidthHeight);

        // Bomb
        public const int bombDisplacement = 16 * scale;
        public const double bombFuseDurationSeconds = 2.0;
        public const int bombWidthHeight = 16 * scale;

        // Boomerang
        public const double boomerangSpeedPerSecond = 10.0;
        public const double boomerangDecelPerSecond = -5.0;
        public const double magicalBoomerangSpeedCoef = 1.2;
        public const double boomerangReturnSpeedPerSecond = 6.0;
        public const double boomerangTOffset = 1;
        public const int boomerangDamage = 1;
        public static Vector2 boomerangRotationOffset = new Vector2(4, 4);
        public const int boomerangWidthHeight = 8 * scale;

        // FireSpell
        public const double fireSpellSpeedPerSecond = 150.0;
        public const int fireSpellMaxDistance = 200;
        public const double fireSpellLingerDuration = 2.0;
        public const int fireSpellDamage = 1;
        public const int fireSpellWidthHeight = 16 * scale;

        // SwordAttackHitbox
        public const int swordHitboxCounter = 17;
        public const int swordHitboxLength = 16;
        public const int swordHitboxWidth = 3;
        public const int basicSwordDamage = 1;
        public static Vector2 swordHitboxWidthHeight = new Vector2(16, 3) * scale;

        // Magic projectile
        public const float magicProjectileSpread = 0.3f;
        public const double magicProjectileSpeed = 150;
        public const double magicProjectileLifetime = 3.0;
        public const int magicProjectileDamage = 1;
        public static Vector2 magicProjectileWidthHeight = new Vector2(8, 10) * scale;

        // Sword beam
        public const double swordBeamSpeedPerSecond = 100 * scale;
        public const int swordBeamMaxDistance = 150 * scale;
        public const int swordBeamDamage = 2;
        public static Vector2 swordBeamRotationOffset = new Vector2(8, 3.5f);
        public static Vector2 swordBeamWidthHeight = new Vector2(16, 7) * scale;

        //----- Enemy constant values -----//

        //Default
        public const double DefaultEnemyKnockbackTime = 0.5f;
        public const float DefaultEnemyKnockbackSpeed = 4 * scale * standardWidthHeight;
        public const float DefaultEnemyKnockbackToLink = 2 * scale * standardWidthHeight;
        public const float DefaultEnemyMoveSpeed = 2 * scale * standardWidthHeight;
        public const double DefaultEnemyMoveTime = 1.0;
        public const float DefaultEnemyPauseTime = 1.0f;
        public const float DefaultEnemyDamagedTime = 0.5f;
        public const int DefaultEnemyAbilityChanceWeight = 1;
        public const double MegaEnemiesScale = scale * 1.5;
        public const double MegaEnemiesKnockbackTime = DefaultEnemyKnockbackTime / 2;

        //Aquamentus
        public const int AquamentusDamage = 2;
        public const float AquamentusMoveDistance = 2 * scale * standardWidthHeight;
        public const float AquamentusMoveSpeed = DefaultEnemyMoveSpeed;
        public const double AquamentusReloadTime = 2;
        public const double AquamentusShootSpriteTime = 0.5f;
        public const int AquamentusStartingHealth = 6;
        //Dodongo
        public const int DodongoDamage = 2;
        public const float DodongoMoveSpeed = DefaultEnemyMoveSpeed;
        public const double DodongoMoveTime = DefaultEnemyMoveTime;
        public const double DodongoStunTime = 1;
        public const int DodongoStartingHealth = basicSwordDamage * 2;
        //Gel
        public const int GelDamage = 1;
        public const double GelMoveTime = DefaultEnemyMoveTime;
        public const float GelMoveSpeed = DefaultEnemyMoveSpeed;
        public const double GelPauseTime = DefaultEnemyPauseTime;
        public const int GelStartingHealth = 1;
        public const int GelWidthHeight = 8 * scale;
        //Goriya
        public const int GoriyaDamage = 1;
        public const double GoriyaMoveTime = 1.5;
        public const float GoriyaMoveSpeed = DefaultEnemyMoveSpeed;
        public const int GoriyaStartingHealth = 3;
        public const float EnemyBoomerangTimeoutSeconds = 3.0f;
        public const int GoriyaThrowBoomerangChanceWeight = 2;
        //Keese
        public const int KeeseDamage = 1;
        public const double KeeseMoveTime = DefaultEnemyMoveTime;
        public const float KeeseMoveSpeed = DefaultEnemyMoveSpeed;
        public const int KeeseStartingHealth = 1;
        //OldMan
        public const int OldManDamage = 0;
        public const int OldManStartingHealth = 1;
        //Rope
        public const int RopeDamage = 1;
        public const double RopeMoveTime = DefaultEnemyMoveTime;
        public const float RopeMoveSpeed = DefaultEnemyMoveSpeed;
        public const float RopeChaseSpeed = RopeMoveSpeed * 2;
        public const int RopeStartingHealth = 1;
        public const double RopeChaseTimeoutTime = RopeMoveTime / 2;
        //Stalfos
        public const int StalfosDamage = 1;
        public const double StalfosMoveTime = DefaultEnemyMoveTime;
        public const float StalfosMoveSpeed = DefaultEnemyMoveSpeed;
        public const int StalfosStartingHealth = 2;
        //Zol
        public const int ZolDamage = 2;
        public const double ZolMoveTime = DefaultEnemyMoveTime;
        public const float ZolMoveSpeed = DefaultEnemyMoveSpeed;
        public const double ZolPauseTime = DefaultEnemyPauseTime;
        public const int ZolStartingHealth = 1;
        //SpikeTrap
        public const int vectorFlip = -1;
        public const int spikeTrapSpeed = 25 * scale;
        public const int roomWidthInBlocks = 12;
        public const int roomHeightInBlocks = 7;
        public const int spikeTrapSpawnAdjustment = 1;
        public const int doubleTheValue = 2;
        public const int SpikeTrapWidthMovementTicks = 100;
        public const int SpikeTrapHeightMovementTicks = 55;

        //WallMaster
        public const int WallMasterHealth = 3;
        public const float WallMasterTimeToMoveAgain = 1;
        public const float WallMasterMoveSpeed = DefaultEnemyMoveSpeed;

        //Bubble
        public const int BubbleDamage = 1;
        public const double BubbleMoveTime = DefaultEnemyMoveTime / 2.0f;
        public const float BubbleMoveSpeed = DefaultEnemyMoveSpeed * 2.0f;
        public const int BubblePlaceholderHealth = 5;
        public const float BubbleFramesPerSecond = 16;
        //Darknut
        public const int DarknutDamage = 2;
        public const double DarknutMoveTime = DefaultEnemyMoveTime;
        public const float DarknutMoveSpeed = DefaultEnemyMoveSpeed;
        public const int DarknutStartingHealth = 2;
        //Patra
        public const int PatraDamage = 2;
        public const double PatraMoveTime = DefaultEnemyMoveTime;
        public const float PatraMoveSpeed = DefaultEnemyMoveSpeed / 2;
        public const int PatraStartingHealth = 6;
        public const int PatraStartingMinionCount = 8;
        public const int PatraToggleOrbitChanceWeight = 6;
        public static Vector2 PatraWidthHeight = new Vector2(16, 11) * scale;
        //PatraMinion
        public const int PatraMinionDamage = 1;
        public const int PatraMinionStartingHealth = 2;
        public const int PatraMinionBaseOrbitRadius = (int)(standardWidthHeight * scale * -1.5);
        public const int PatraMinionExtendedOrbitRadius = (int)(standardWidthHeight * scale * -5.0);
        public const double PatraMinionOrbitTimeRadians = (2 * Math.PI) / PatraMoveTime;
        public const double PatraRadiusExtensionSpeed = (standardWidthHeight * scale * 3.5) / PatraMoveTime;
        public const double PatraMinionEllipseRadiusRatio = 0.5;
        public static Vector2 PatraMinionWidthHeight = new Vector2(8, 8) * scale;
        //MegaStalfos
        public const int MegaStalfosDamage = 2;
        public const double MegaStalfosMoveTime = StalfosMoveTime;
        public const float MegaStalfosMoveSpeed = StalfosMoveSpeed;
        public const int MegaStalfosHealth = 6;
        public const double MegaStalfosScale = MegaEnemiesScale;
        public const double MegaStalfosKnockbackTime = MegaEnemiesKnockbackTime;
        //MegaGel
        public const int MegaGelDamage = 2;
        public const double MegaGelMoveTime = GelMoveTime;
        public const float MegaGelMoveSpeed = GelMoveSpeed;
        public const double MegaGelPauseTime = GelPauseTime;
        public const int MegaGelHealth = 3;
        public const double MegaGelScale = MegaEnemiesScale;
        public const double MegaGelKnockbackTime = MegaEnemiesKnockbackTime;
        //MegaZol
        public const int MegaZolDamage = 3;
        public const double MegaZolMoveTime = ZolMoveTime;
        public const float MegaZolMoveSpeed = ZolMoveSpeed;
        public const double MegaZolPauseTime = ZolPauseTime;
        public const int MegaZolHealth = 4;
        public const double MegaZolScale = MegaEnemiesScale;
        public const double MegaZolKnockbackTime = MegaEnemiesKnockbackTime;
        //MegaKeese
        public const int MegaKeeseDamage = 2;
        public const double MegaKeeseMoveTime = KeeseMoveTime;
        public const float MegaKeeseMoveSpeed = KeeseMoveSpeed * 1.5f;
        public const int MegaKeeseHealth = 4;
        public const double MegaKeeseScale = MegaEnemiesScale;
        public const double MegaKeeseKnockbackTime = MegaEnemiesKnockbackTime;
        //MegaDarknut
        public const int MegaDarknutDamage = 2;
        public const double MegaDarknutMoveTime = DarknutMoveTime;
        public const float MegaDarknutMoveSpeed = DarknutMoveSpeed;
        public const int MegaDarknutHealth = 4;
        public const double MegaDarknutScale = MegaEnemiesScale;
        public const double MegaDarknutKnockbackTime = MegaEnemiesKnockbackTime;
        public const float MegaDarknutChaseSpeed = DarknutMoveSpeed * 2;
        public const double MegaDarknutChaseTimeoutTime = DarknutMoveTime / 2;
        //Manhandla
        public const int ManhandlaHeadDamage = 2;
        public const double ManhandlaMoveTime = DefaultEnemyMoveTime;
        public const float ManhandlaMoveSpeed = DefaultEnemyMoveSpeed;
        public const int ManhandlaHeadHealth = 3;
        public const int ManhandlaPlaceholderHealth = 1;
        public const float ManhandlaSpeedMultiplier = 1.2f;
        public const int ManhandlaComponentWidthHeight = 16 * scale;

        //Sprites
        public const float DefaultEnemyFramesPerSecond = 4;
        public const float QuickEnemyFramesPerSecond = 16;
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
        public const double degreeRotationCW360_s = 2 * Math.PI;
        public const float noLayerDepth = 0;
        public const int nextInArray = 1;

        // Movement
        public const float zeroPauseTime = 0f;


        //----- Collision constant values -----//
        public static Vector2 degreeRotationCW90_v = new Vector2(0, -1);
        public static Vector2 degreesRotationCW180_v = new Vector2(-1, -1);
        public static Vector2 degreesRotationCW270_v = new Vector2(-1, 0);
        public const int zero = 0;
        public const int xOnScreenBorder = 0;


        //----- string constant values -----//
        public const string secretRoom = "Room00";
        public const string stairRoom = "Room10";
        public const string wallMasterToRoom = "Room25";
        public const string enemiesFile = "enemies";
        public const string npcFile = "npc";
        public const string bossesFile = "bosses";
        public const string itemFile = "LoZItems";
        public const string projectileFile = "LoZSprites";
        public const string linkFile = "LinkSpriteSheet";
        public const string blueLinkFile = "BlueLinkSpriteSheet";
        public const string shotgunFile = "LinkShotGunSpriteSheet";
        public const string blueLinkShotgunFile = "BlueLinkShotGunSpriteSheet";
        public const string pathForCsvFiles = @"/../../../Scripts/Terrain/LevelData/Dungeon1/";
        public const string cvsExtension = ".csv";
        public const string separator = ",";
        public const string lineIsEmpty = "None";
        public const string emptyStr = "";
        public const string spaceStr = " ";
        public const string AquamentusStr = "Aquamentus";
        public const string BladeTrapStr = "BladeTrap";
        public const string DodongoStr = "Dodongo";
        public const string GelStr = "Gel";
        public const string GoriyaStr = "Goriya";
        public const string KeeseStr = "Keese";
        public const string OldManStr = "OldMan";
        public const string MerchantStr = "Merchant";
        public const string RopeStr = "Rope";
        public const string StalfosStr = "Stalfos";
        public const string WallMasterStr = "WallMaster";
        public const string ZolStr = "Zol";
        public const string BubbleStr = "Bubble";
        public const string DarknutStr = "Darknut";
        public const string PatraStr = "Patra";
        public const string MegaStalfosStr = "MegaStalfos";
        public const string MegaGelStr = "MegaGel";
        public const string MegaZolStr = "MegaZol";
        public const string MegaKeeseStr = "MegaKeese";
        public const string MegaDarknutStr = "MegaDarknut";
        public const string ManhandlaStr = "Manhandla";
        public const string SmallHeartItemStr = "SmallHeartItem";
        public const string HeartContainerStr = "HeartContainer";
        public const string FairyStr = "Fairy";
        public const string ClockStr = "Clock";
        public const string BlueRubyStr = "BlueRuby";
        public const string YellowRubyStr = "YellowRuby";
        public const string BasicMapItemStr = "BasicMapItem";
        public const string BoomerangItemStr = "BoomerangItem";
        public const string BombItemStr = "BombItem";
        public const string BowItemStr = "BowItem";
        public const string BasicKeyStr = "BasicKey";
        public const string MagicKeyStr = "MagicKey";
        public const string CompassStr = "Compass";
        public const string TriforcePieceStr = "TriforcePiece";
        public const string BasicArrowItemStr = "BasicArrowItem";
        public const string SilverArrowItemStr = "SilverArrowItem";
        public const string KeyStr = "Key";
        public const string MapStr = "Map";
        public const string ShotgunItemStr = "ShotgunItem";
        public const string ShotgunShellItemStr = "ShotgunShellItem";
        public const string BlueRingStr = "BlueRing";
        public const string typoInRoomMessage = "Typo in Room ";
        public const string EastClosedSpriteStr = "EastClosedSprite";
        public const string NorthClosedSpriteStr = "NorthClosedSprite";
        public const string WestClosedSpriteStr = "WestClosedSprite";
        public const string SouthClosedSpriteStr = "SouthClosedSprite";
        public const string MoveableBlockSpriteStr = "MoveableBlockSprite";
        public const string StairSpriteStr = "StairSprite";
        public const string InvisibleExitStr = "InvisibleExit";
        public const string EastDoorSpriteStr = "EastDoorSprite";
        public const string NorthDoorSpriteStr = "NorthDoorSprite";
        public const string WestDoorSpriteStr = "WestDoorSprite";
        public const string SouthDoorSpriteStr = "SouthDoorSprite";
        //TODO: start in start room
        public const string startRoom = "Room25";
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
        public const string InvisibleWallStr = "InvisibleWall";


        //----- wall/block constant values -----//
        public const int fullScreen = 1200;
        public const int wallOffset = scale * standardWidthHeight * 2;
        public const int yOffsetForRoom = scale * standardWidthHeight * 7 / 2;
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

        public const int yPosForNorthDoor = 0;
        public const int yPosForEastWestDoor = 72;
        public const int yPosForSouthDoor = 144;

        public const int xPosForNorthSouthDoor = 112;
        public const int xPosForEastDoor = 224;
        public const int xPosForWestDoor = 0;

        public const int xPosForDoorRight = 144;
        public const int yPosForDoorBottom = 104;
        public const int yPosForDoorLeft = 144;

        public const int EastDoorSpritePos = 8;
        public const int NorthDoorSpritePos = 9;
        public const int WestDoorSpritePos = 10;
        public const int SouthDoorSpritePos = 11;
        public const int wallHitBoxHalfSize = standardWidthHeight / 2;
        public const int wallHitBoxSize = standardWidthHeight;
        public static Vector2 sideOnRoomSpawnPosition = new Vector2(scale * wallHitBoxSize * 3, yOffsetForRoom + scale * wallHitBoxSize * 3);
        public static Vector2 leftOfStairSpawnPosition = new Vector2(scale * wallHitBoxSize * 7, yOffsetForRoom + scale * wallHitBoxSize * 6);

        //----- Effect constant values -----//
        public const double popDurationSeconds = 0.2;
        public const double explosionDurationSeconds = 0.3;
        public const double bombExtraExplosionOffset = 16 * scale;
        public const double bombExtraExplosionNumber = 6;
        public const double swordBeamExplosionDurationSeconds = 0.4;
        public const double swordBeamExplosionSpeed = 40 * scale;
        public static Vector2 swordBeamExplosionRightOffset = new Vector2(2, -4) * scale;
        public static Vector2 swordBeamExplosionUpOffset = new Vector2(-4, -6) * scale;
        public static Vector2 swordBeamExplosionLeftOffset = new Vector2(-2, -4) * scale;
        public static Vector2 swordBeamExplosionDownOffset = new Vector2(-4, 6) * scale;

        //----- Room swapping animation constants -----//
        public const int roomswapAnimationVerticalScrollDist = 176 * scale;
        public const int roomswapAnimationHorizontalScrollDist = 256 * scale;
        public const int roomswapAnimationDurationInFrames = 80;


        //----- Inventory GUI constant values -----//
        public const string inventorySpritesheetFileName = "InventorySpritesheet";
        public const int inventoryDisplayListIndex = 1;

        // Backdrop
        public static Vector2 backdropSpawnLocation = Vector2.Zero;
        public static Vector2 mapBackdropFromBackdrop = new Vector2(0, 88) * scale;
        public static Vector2 mapColorCoverFromBackdrop = new Vector2(128, 96) * scale;
        public const int mapColorCoverWidthHeightScale = 4;

        // Weapon
        public static Vector2 weaponFromBackdropLocation = new Vector2(132, 48) * scale;
        public static Vector2 selectionWeaponFromBackdropLocation = new Vector2(68, 48) * scale;
        public static Vector2 basicArrowFromBackdropLocation = new Vector2(130, 24) * scale;
        public static Vector2 silverArrowFromBackdropLocation = new Vector2(137, 24) * scale;
        public static Vector2 blueRingFromBackdropLocation = new Vector2(164, 24) * scale;
        public static Vector2 magicKeyFromBackdropLocation = new Vector2(196, 24) * scale;
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


        //----- Font or HUD constant values -----//
        public const string fontSpritesheetFileName = "Font";
        public const string fontClearBackgroundSpritesheetFileName = "FontClearBackground";
        public const int maxDisplayableNumbers = 3;
        public static Vector2 mapDrawLocation = new Vector2(16 * scale, 16 * scale);
        public static Vector2 keyCounterLocation = new Vector2(96 * scale, 32 * scale);
        public static Vector2 bombCounterLocation = new Vector2(96 * scale, 40 * scale);
        public static Vector2 rupeeCounterLocation = new Vector2(96 * scale, 16 * scale);
        public static Vector2 shotgunShellCounterLocation = new Vector2(96 * scale, 24 * scale);
        public static Vector2 primaryWeaponLocation = new Vector2(152 * scale, 24 * scale);
        public static Vector2 secondaryWeaponLocation = new Vector2(128 * scale, 24 * scale);
        public static Vector2 DungeonLevelDisplayLocation = new Vector2(16 * scale, 8 * scale);
        public static Vector2 DungeonLevelNumberDisplayLocation = new Vector2(64 * scale, 8 * scale);
        public const int maxMaxHealth = 32;
        public const int maxDungeonWidthHeight = 8;
        public const int HUDYOffsetInInventory = 176 * scale;
        public const int HealthDrawLocationX = 176;
        public const int HealthDrawLocationY = 32;
        public const int maxHeartsPerLine = 8;
        public static Vector2 roomMapSize = new Vector2(8 * scale, 4 * scale);
        public static Vector2 markerXOffset = new Vector2(2 * scale, 0);
        public static Vector2 TreasureRoomLocation = new Vector2(5, 1);

        // Discovered rooms
        public const int discoveredRoomsMaxIndex = 15;
        public const int discoveredRoomsTotalDoorStates = 2;
        public const int discoveredRoomsSourcePixelDistance = 9;
        public static Vector2 discoveredRoomsInitialLocationFromBackdrop = new Vector2(128, 96) * scale;
        public static Vector2 discoveredRoomsD1LocationOffset = new Vector2(16, 8) * scale;
        public static Vector2 dotOffsetFromRoom = new Vector2(2) * scale;
        public const int discoveredRoomsWidthHeight = 8 * scale;


        //----- RoomTracker constant values -----//
        public const int roomStringXIndex = 4;
        public const int roomStringYIndex = 5;


        //----- DropTable constant values -----//
        public const double groupADropRate = 0.31;
        public const double groupBDropRate = 0.41;
        public const double groupCDropRate = 0.59;
        public const double groupDDropRate = 0.41;
        public const double groupXDropRate = 0;
        public static HashSet<Type> groupAEnemies = new HashSet<Type>() { };
        public static HashSet<Type> groupBEnemies = new HashSet<Type> { typeof(Goriya), typeof(Darknut) };
        public static HashSet<Type> groupCEnemies = new HashSet<Type> { typeof(Stalfos), typeof(Zol), typeof(Wallmaster) };
        public static HashSet<Type> groupDEnemies = new HashSet<Type> { typeof(Aquamentus), typeof(Patra), typeof(MegaStalfos), typeof(MegaGel), typeof(MegaZol), typeof(MegaKeese), typeof(MegaDarknut) };
        public static HashSet<Type> groupXEnemies = new HashSet<Type> { typeof(Keese), typeof(Gel), typeof(SpikeTrap), typeof(PatraMinion) };
        public static ItemType[] groupAItems = {
            ItemType.YellowRuby,
            ItemType.SmallHeartItem,
            ItemType.YellowRuby,
            ItemType.Fairy,
            ItemType.YellowRuby,
            ItemType.SmallHeartItem,
            ItemType.SmallHeartItem,
            ItemType.YellowRuby,
            ItemType.YellowRuby,
            ItemType.SmallHeartItem };
        public static ItemType[] groupBItems = {
            ItemType.BombItem,
            ItemType.YellowRuby,
            ItemType.Clock,
            ItemType.YellowRuby,
            ItemType.SmallHeartItem,
            ItemType.BombItem,
            ItemType.YellowRuby,
            ItemType.BombItem,
            ItemType.SmallHeartItem,
            ItemType.SmallHeartItem };
        public static ItemType[] groupCItems = {
            ItemType.YellowRuby,
            ItemType.SmallHeartItem,
            ItemType.YellowRuby,
            ItemType.BlueRuby,
            ItemType.SmallHeartItem,
            ItemType.Clock,
            ItemType.YellowRuby,
            ItemType.YellowRuby,
            ItemType.YellowRuby,
            ItemType.BlueRuby };
        public static ItemType[] groupDItems = {
            ItemType.SmallHeartItem,
            ItemType.Fairy,
            ItemType.YellowRuby,
            ItemType.SmallHeartItem,
            ItemType.Fairy,
            ItemType.SmallHeartItem,
            ItemType.SmallHeartItem,
            ItemType.SmallHeartItem,
            ItemType.YellowRuby,
            ItemType.SmallHeartItem, };

        //Group X doesn't drop anything


        //----- Inventory constant values -----//
        public const int inventoryStartingRupees = 10;
        public const int inventoryStartingKeys = 0;
        public const int inventoryStartingBombs = 4;
        public const int fullHeartHealthValue = 2;
        public const int inventoryYellowRupeeValue = 1;
        public const int inventoryBlueRupeeValue = 5;
        public const int inventoryBasicKeyValue = 1;
        public const int inventoryStartingShotgunShells = 0;
        public const int shotgunShellsPerPickUp = 20;

        //Sound effects
        public const string soundDirectoryStr = "Sounds/";
        public const string bombExplosionStr = soundDirectoryStr + "LOZ_Bomb_Blow";
        public const string bombPlacementStr = soundDirectoryStr + "LOZ_Bomb_Drop";
        public const string bossHitStr = soundDirectoryStr + "LOZ_Boss_Hit";
        public const string bossScream1Str = soundDirectoryStr + "LOZ_Boss_Scream1";
        public const string bossScream2Str = soundDirectoryStr + "LOZ_Boss_Scream2";
        public const string bossScream3Str = soundDirectoryStr + "LOZ_Boss_Scream3";
        public const string doorUnlockingStr = soundDirectoryStr + "LOZ_Door_Unlock";
        public const string enemyDeathStr = soundDirectoryStr + "LOZ_Enemy_Die";
        public const string enemyHitStr = soundDirectoryStr + "LOZ_Enemy_Hit";
        public const string fanfareStr = soundDirectoryStr + "LOZ_Fanfare";
        public const string fireArrowBoomerangStr = soundDirectoryStr + "LOZ_Arrow_Boomerang";
        public const string shotgunBangStr = soundDirectoryStr + "Shotgun_Bang";
        public const string fireCandleStr = soundDirectoryStr + "LOZ_Candle";
        public const string fireMagicRodStr = soundDirectoryStr + "LOZ_MagicalRod";
        public const string gameOverStr = soundDirectoryStr + "GameOver";
        public const string keySpawnStr = soundDirectoryStr + "LOZ_Key_Appear";
        public const string linkDeathStr = soundDirectoryStr + "LOZ_Link_Die";
        public const string linkHitStr = soundDirectoryStr + "LOZ_Link_Hurt";
        public const string lowHealthStr = soundDirectoryStr + "LOZ_LowHealth";
        public const string musicStr = soundDirectoryStr + "Dungeon Theme";
        public const string pickUpHeartStr = soundDirectoryStr + "LOZ_Get_Heart";
        public const string pickUpItemStr = soundDirectoryStr + "LOZ_Get_Item";
        public const string pickupRupeeStr = soundDirectoryStr + "LOZ_Get_Rupee";
        public const string recorderStr = soundDirectoryStr + "LOZ_Recorder";
        public const string refillLoopStr = soundDirectoryStr + "LOZ_Refill_Loop";
        public const string secretFoundStr = soundDirectoryStr + "LOZ_Secret";
        public const string shieldDeflectStr = soundDirectoryStr + "LOZ_Shield";
        public const string shoreStr = soundDirectoryStr + "LOZ_Shore";
        public const string stairsStr = soundDirectoryStr + "LOZ_Stairs";
        public const string swordCombinedStr = soundDirectoryStr + "LOZ_Sword_Combined";
        public const string swordShootStr = soundDirectoryStr + "LOZ_Sword_Shoot";
        public const string swordSlashStr = soundDirectoryStr + "LOZ_Sword_Slash";
        public const string textScrollStr = soundDirectoryStr + "LOZ_Text";
        public const string textScrollSlowStr = soundDirectoryStr + "LOZ_Text_Slow";
        public const string triforcePieceSoundStr = soundDirectoryStr + "Triforce Piece";

        //----- Dialogue Box Constants -----//
        public const int framesBetweenLetters = 2;

        public const int maxLetters = 400;
        public const int lettersPerLine = 35;
        public const int maxLines = 7;
        public const int letterSpacing = 6;

        // Origin point for printed dialogue
        public const int dialogueStartX = 56;
        public const int dialogueStartY = ObjectConstants.yOffsetForRoom + 2 * ObjectConstants.standardWidthHeight;
    }
}
