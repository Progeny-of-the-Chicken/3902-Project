namespace Sprint_0
{
    public static class ObjectConstants
    {
        //----- Sprite constant values -----//
        public const int scale = 2;

        //----- Item constant values -----//
        // Arrow
        public const double arrowSpeedPerSecond = 150.0;
        public const int arrowMaxDistance = 200;
        public const double silverArrowSpeedCoef = 1.5;
        public const double arrowPopDurationSeconds = 0.2;
        // Bomb
        public const int bombDisplacement = 50;
        public const double bombFuseDurationSeconds = 2.0;
        public const double bombExplodeDurationSeconds = 0.3;
        // Boomerang
        public const double boomerangSpeedPerSecond = 10.0;
        public const double boomerangDecelPerSecond = -5.0;
        public const double magicalBoomerangSpeedCoef = 1.2;
        public const double boomerangTOffset = 1;
        // FireSpell
        public const double fireSpellSpeedPerSecond = 150.0;
        public const int fireSpellMaxDistance = 200;
        public const double fireSpellLingerDuration = 2.0;
        // SwordAttackHitbox
        public const int swordHitboxCounter = 17;
        public const int swordHitboxLength = 11;
        public const int swordHitboxWidth = 3;

        //----- Item source rectangles -----//
    }
}
