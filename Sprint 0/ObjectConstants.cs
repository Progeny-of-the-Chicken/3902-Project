using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0
{
    public static class ObjectConstants
    {
        //----- Sprite constant values -----//
        public const int scale = 2;
        public const double itemAnimationDelaySeconds = 0.1;

        //----- Item source rectangles -----//
        public static List<Rectangle> smallHeartFrames = new List<Rectangle> {
            new Rectangle(0, 0, 7, 8),
            new Rectangle(0, 8, 7, 8)
        };
        public static Rectangle heartContainerFrame = new Rectangle(25, 1, 13, 13);
        public static List<Rectangle> fairyFrames = new List<Rectangle>
        {
            new Rectangle(40, 0, 8, 16),
            new Rectangle(48, 0, 8, 16)
        };
        public static Rectangle clockFrame = new Rectangle(58, 0, 11, 16);
        public static Rectangle blueRubyFrame = new Rectangle(72, 0, 8, 16);
        public static List<Rectangle> yellowRubyFrames = new List<Rectangle>
        {
            new Rectangle(72, 0, 8, 16),
            new Rectangle(72, 16, 8, 16)
        };
        public static Rectangle basicMapFrame = new Rectangle(88, 0, 8, 16);
        public static Rectangle boomerangItemFrame = new Rectangle(129, 3, 5, 8);
        public static Rectangle bombItemFrame = new Rectangle(136, 0, 8, 14);
        public static Rectangle bowItemFrame = new Rectangle(144, 0, 8, 16);
        public static Rectangle basicKeyFrame = new Rectangle(240, 0, 8, 16);
        public static Rectangle magicKeyFrame = new Rectangle(248, 0, 8, 16);
        public static Rectangle compassFrame = new Rectangle(258, 1, 11, 12);
        public static List<Rectangle> triforcePieceFrames = new List<Rectangle>
        {
            new Rectangle(275, 3, 10, 10),
            new Rectangle(275, 19, 10, 10)
        };
        
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
        public const int swordHitboxLength = 11;
        public const int swordHitboxWidth = 3;
        public const int basicSwordDamage = 1;

        //----- Projectile source rectangles -----//
        public static Rectangle basicArrowFrame = new Rectangle(10, 190, 16, 5);
        public static Rectangle silverArrowFrame = new Rectangle(36, 190, 16, 5);
        public static Rectangle arrowPopFrame = new Rectangle(53, 189, 8, 8);
        public static Rectangle bombFrame = new Rectangle(145, 185, 16, 16);
        public static List<Rectangle> bombExplodeFrames = new List<Rectangle>
        {
            new Rectangle(162, 185, 16, 16),
            new Rectangle(179, 185, 16, 16),
            new Rectangle(196, 185, 16, 16),
            new Rectangle(0, 0, 0, 0)
        };
        public static List<Rectangle> basicBoomerangFrames = new List<Rectangle>
        {
            new Rectangle(64, 189, 8, 8),
            new Rectangle(73, 189, 8, 8),
            new Rectangle(82, 189, 8, 8),
            new Rectangle(91, 189, 8, 8)
        };
        public static List<Rectangle> magicalBoomerangFrames = new List<Rectangle>
        {
            new Rectangle(100, 189, 8, 8),
            new Rectangle(109, 189, 8, 8),
            new Rectangle(118, 189, 8, 8),
            new Rectangle(127, 189, 8, 8)
        };
        public static Rectangle fireSpellFrame = new Rectangle(215, 185, 16, 16);
    }
}
