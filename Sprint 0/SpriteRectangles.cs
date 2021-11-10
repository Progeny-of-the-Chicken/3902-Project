﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0
{
    public static class SpriteRectangles
    {
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

        //----- Projectile source rectangles -----//
        public static Rectangle basicArrowFrame = new Rectangle(10, 190, 16, 5);
        public static Rectangle silverArrowFrame = new Rectangle(36, 190, 16, 5);
        public static Rectangle bombFrame = new Rectangle(145, 185, 16, 16);
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

        //----- Effect source rectangles -----//
        public static Rectangle popFrame = new Rectangle(53, 189, 8, 8);
        public static List<Rectangle> explosionFrames = new List<Rectangle>
        {
            new Rectangle(162, 185, 16, 16),
            new Rectangle(179, 185, 16, 16),
            new Rectangle(196, 185, 16, 16),
            new Rectangle(0, 0, 0, 0)
        };

        //----- Inventory GUI source rectangles -----//
        public static Rectangle backdropFrame = new Rectangle(1, 11, 256, 88);
        public static List<Rectangle> selectionFrames = new List<Rectangle>
        {
            new Rectangle(519, 137, 16, 16),
            new Rectangle(536, 137, 16, 16)
        };
        public static Rectangle weaponBasicSwordFrame = new Rectangle(555, 137, 8, 16);
        public static Rectangle weaponBasicBoomerangFrame = new Rectangle(584, 137, 8, 16);
        public static Rectangle weaponMagicalBoomerangFrame = new Rectangle(593, 137, 8, 16);
        public static Rectangle weaponBombFrame = new Rectangle(604, 137, 8, 16);
        public static Rectangle weaponBasicArrowFrame = new Rectangle(615, 137, 8, 16);
        public static Rectangle weaponSilverArrowFrame = new Rectangle(624, 137, 8, 16);
        public static Rectangle weaponBowFrame = new Rectangle(633, 137, 8, 16);
        public static Rectangle weaponBlueCandleFrame = new Rectangle(644, 137, 8, 16);
        public static Rectangle inventoryMapFrame = new Rectangle(601, 156, 8, 16);
        public static Rectangle inventoryCompassFrame = new Rectangle(612, 156, 16, 16);

    }
}
