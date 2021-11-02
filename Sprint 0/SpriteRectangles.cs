using System.Collections.Generic;
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

        //----- Enemy source rectangles -----//
        //Aquamentus
        public static Rectangle[] aquamentusMoveFrames = { new Rectangle(51, 11, 24, 31), new Rectangle(76, 11, 24, 31) };
        public static Rectangle[] aquamentusShootFrames = { new Rectangle(1, 11, 24, 31), new Rectangle(26, 11, 24, 31) };
        //Magic Projectile
        public static Rectangle[] magicProjectileFrames = { new Rectangle(101, 14, 8, 10), new Rectangle(110, 14, 8, 10),
                                              new Rectangle(119, 14, 8, 10), new Rectangle(128, 14, 8, 10) };
        //Gel
        public static Rectangle[] gelFrames = { new Rectangle(1, 15, 8, 9), new Rectangle(10, 15, 8, 9) };
        //Goriya
        public static Rectangle goriyaFrontFrame = new Rectangle(222, 10, 15, 17);
        public static Rectangle goriyaBackFrame = new Rectangle(240, 10, 14, 17);
        public static Rectangle[] goriyaRightFrames = { new Rectangle(256, 10, 14, 17), new Rectangle(274, 11, 16, 16) };
        //Keese
        public static Rectangle[] keeseFrames = { new Rectangle(200, 14, 16, 12), new Rectangle(183, 14, 18, 10) };
        //Old Man
        public static Rectangle oldManFrame = new Rectangle(1, 11, 16, 16);
        //SpikeTrap
        public static Rectangle spikeTrapFrame = new Rectangle(164, 59, 16, 16);
        //Stalfos
        public static Rectangle stalfosFrame = new Rectangle(1, 59, 16, 16);
        //Wallmaster
        public static Rectangle wallMasterOpenFrame = new Rectangle(392, 10, 18, 16);
        public static Rectangle wallMasterCloseFrame = new Rectangle(410, 11, 14, 16);
        //Zol
        public static Rectangle[] zolFrames = { new Rectangle(78, 11, 14, 16), new Rectangle(95, 11, 14, 16) };
    }
}
