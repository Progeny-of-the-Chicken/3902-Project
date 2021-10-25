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

        //----- Link constant values -----//
        public const int linkSpeed = 1;
        public const int linkStartingHealth = 6;
        public const int defaultCounterLength = 30;
        public const int bouncebackDistance = 90;

        //----- Item constant values -----//
        public const double clockFreezeSeconds = 10.0;
        
        //----- Projectile constant values -----//
        // Arrow
        public const double arrowSpeedPerSecond = 150.0;
        public const int arrowMaxDistance = 200;
        public const double silverArrowSpeedCoef = 1.5;
        public const double arrowPopDurationSeconds = 0.2;
        public const int arrowDamage = 1;
        // Bomb
        public const int bombDisplacement = 50;
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
        public const int swordHitboxLength = 11 * scale;
        public const int swordHitboxWidth = 3 * scale;
        public const int basicSwordDamage = 1;
    }
}
