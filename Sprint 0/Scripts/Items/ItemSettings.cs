using System;

namespace Sprint_0.Scripts.Items
{
    public static class ItemSettings
    {
        // General
        public static int animationDelay = 50;

        // Arrow
        public static double arrowSpeed = 10.0;
        public static int arrowDistance = 200;
        public static double silverArrowSpeedCoef = 2.0;

        // Boomerang
        public static double boomerangSpeed = 5.0;
        public static double boomerangAccel = -2.5;
        public static double magicalBoomerangSpeedCoef = 2.0;

        // Fire spell
        public static double fireSpeed = 10.0;
        public static int fireDistance = 200;
        public static double lingerDuration = 2.0;

        // Bomb
        public static int bombDisplacement = 50;
        public static double fuseDuration = 2.0;
    }
}
