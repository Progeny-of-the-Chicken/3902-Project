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

        //----- General constant values -----//
        public const int counterInitialVal_int = 0;
        public const float counterInitialVal_float = 0;
        public const int zeroHealth = 0;

        //----- Probability and random selection constant values -----//
        public const int zero = 0;
        public const int oneInTwo = 2;
        public const int numberOfBytesForRandomDirection = 2;
        public const int oneInThree = 3;
        public const int oneInFour = 4;
        public const int oneInFive = 5;
        public const int adjustByNegativeOne = -1;

        //----- Link constant values -----//
        public const int linkSpeed = 1;
        public const int linkStartingHealth = 6;
        public const int defaultCounterLength = 30;
        public const int bouncebackDistance = 90;
        public const int squareTileWidthHeight = 16;

        //----- Item constant values -----//
        public const double clockFreezeSeconds = 10.0;
        
        //----- Projectile constant values -----//
        public static Rectangle standardProjectileSize = new Rectangle(0, 0, 8, 8);
        public static Rectangle swordAttackHitBoxSize = new Rectangle(0, 0, swordHitboxLength, swordHitboxWidth);
        // Arrow
        public const double arrowSpeedPerSecond = 150.0;
        public const int arrowMaxDistance = 200;
        public const double silverArrowSpeedCoef = 1.5;
        public const double arrowPopDurationSeconds = 0.2;
        public const int arrowDamage = 1;
        // BlastZone
        public const int blastZonePositionOffset = -8;
        public const int blastZoneWidthHeight = 32;
        public const int blastZoneCounter = 1;
        public const int blastZoneDamage = 1;
        public static Rectangle blastZoneSize = new Rectangle(0, 0, blastZoneWidthHeight, blastZoneWidthHeight);
        // Bomb
        public const int bombDisplacement = 16 * scale;
        public const double bombFuseDurationSeconds = 2.0;
        public const double bombExplodeDurationSeconds = 0.3;
        public const int bombDamage = 1;
        // Boomerang
        public const double boomerangSpeedPerSecond = 10.0;
        public const double boomerangDecelPerSecond = -5.0;
        public const double magicalBoomerangSpeedCoef = 1.2;
        public const double boomerangTOffset = 1;
        public const int boomerangDamage = 1;
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
        public const int spikeTrapSpeed = 25;
        //Sprites
        public const float DefaultEnemyFramesPerSecond = 4;
        public const int firstFrame = 0;
        public const int firstInArray = 0;
        public const int secondInArray = 1;

        //----- Collision constant values -----//
        public static Vector2 degreesCW90 = new Vector2(0, -1);
        public static Vector2 degreesCW180 = new Vector2(-1, -1);
        public static Vector2 degreesCW270 = new Vector2(-1, 0);
        public const int goToZero = 0;

        //----- string constant values -----//
        public const string secretRoom = "Room00";
        public const string wallMasterToRoom = "Room25";
        public const string enemiesFile = "enemies";
        public const string npcFile = "npc";
        public const string bossesFile = "bosses";
    }
}
