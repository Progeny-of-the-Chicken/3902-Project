using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0
{
    public static class SpriteRectangles
    {

        //----- Link source rectangles -----//
        public static Rectangle linkForwardSpritesheetLocation_1 = new Rectangle(1, 11, 15, 16);
        public static Rectangle linkForwardSpritesheetLocation_2 = new Rectangle(19, 11, 15, 16);
        public static Rectangle linkRightSpritesheetLocation_1 = new Rectangle(34, 11, 16, 16);
        public static Rectangle linkRightSpritesheetLocation_2 = new Rectangle(51, 12, 16, 16);
        public static Rectangle linkBackwardSpritesheetLocation_1 = new Rectangle(70, 11, 15, 16);
        public static Rectangle linkBackwardSpritesheetLocation_2 = new Rectangle(87, 11, 15, 16);

        public static Rectangle[] linkSwordFramesRight = { new Rectangle(0, 77, 16, 16),
            new Rectangle(18, 77, 27, 16),
            new Rectangle(46, 77, 23, 16),
            new Rectangle(69, 77, 16, 16) };

        public static Rectangle[] linkSwordFramesUp = { new Rectangle(1, 108, 16, 18),
            new Rectangle(18, 97, 16, 29),
            new Rectangle(37, 97, 16, 29),
            new Rectangle(54, 108, 16, 18) };

        public static Rectangle[] linkSwordFramesDown = { new Rectangle(1, 47, 16, 18),
            new Rectangle(18, 47, 16, 29),
            new Rectangle(35, 47, 16, 29),
            new Rectangle(53, 47, 16, 18) };

        public static Rectangle linkUsingItemDownFrame = new Rectangle(107, 11, 16, 16);
        public static Rectangle linkUsingItemRightFrame = new Rectangle(124, 12, 16, 16);
        public static Rectangle linkUsingItemUpFrame = new Rectangle(141, 11, 16, 16);
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
        public static Rectangle weaponBackdropFrame = new Rectangle(1, 11, 256, 88);
        public static Rectangle mapBackdropFrame = new Rectangle(258, 112, 256, 88);
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
        public static Rectangle inventoryCompassFrame = new Rectangle(612, 156, 15, 16);
        public static List<Rectangle> backdropCoverFrames = new List<Rectangle>
        {
            new Rectangle(44, 152, 15, 16),
            new Rectangle(48, 112, 8, 16),
            new Rectangle(68, 48, 8, 16),
            new Rectangle(132, 48, 80, 32),
            new Rectangle(128, 24, 88, 16)
        };
        public static Rectangle discoveredRoomIndex0Frame = new Rectangle(519, 108, 8, 8);
        public static List<Rectangle> playerDotFrames = new List<Rectangle>
        {
            new Rectangle(528, 126, 3, 3),
            new Rectangle(582, 126, 3, 3)
        };
        public static Rectangle mapColorCoverSpriteFrame = new Rectangle(458, 120, 16, 16);

        //----- Wall source rectangles -----//
        public static Rectangle MovableBlockFrame = new Rectangle(1001, 11, 16, 16);
        public static Rectangle StairFrame = new Rectangle(1035, 28, 16, 16);
        public static Rectangle EastDoorSpriteFrame = new Rectangle(848, 77, 32, 32);
        public static Rectangle EastBombableSpriteFrame = new Rectangle(814, 77, 32, 32);
        public static Rectangle EastBombedSpriteFrame = new Rectangle(947, 77, 32, 32);
        public static Rectangle WestLockedSpriteFrame = new Rectangle(881, 44, 32, 32);
        public static Rectangle WestDoorSpriteFrame = new Rectangle(848, 44, 32, 32);
        public static Rectangle WestWallSpriteFrame = new Rectangle(815, 44, 32, 32);
        public static Rectangle WestClosedSpriteFrame = new Rectangle(914, 44, 32, 32);
        public static Rectangle WestBombedSpriteFrame = new Rectangle(947, 44, 32, 32);
        public static Rectangle WestBombableSpriteFrame = new Rectangle(815, 44, 32, 32);
        public static Rectangle SouthWallSpriteFrame = new Rectangle(815, 110, 32, 32);
        public static Rectangle SouthLockedSpriteFrame = new Rectangle(881, 110, 32, 32);
        public static Rectangle SouthDoorSpriteFrame = new Rectangle(848, 110, 32, 32);
        public static Rectangle SouthClosedSpriteFrame = new Rectangle(914, 110, 32, 32);
        public static Rectangle SouthBombedSpriteFrame = new Rectangle(947, 110, 32, 32);
        public static Rectangle SouthBombableSpriteFrame = new Rectangle(815, 110, 32, 32);
        public static Rectangle NorthWallSpriteFrame = new Rectangle(815, 11, 32, 32);
        public static Rectangle NorthLockedSpriteFrame = new Rectangle(881, 11, 32, 32);
        public static Rectangle NorthDoorSpriteFrame = new Rectangle(848, 11, 32, 32);
        public static Rectangle NorthClosedSpriteFrame = new Rectangle(914, 11, 32, 32);
        public static Rectangle NorthBombedSpriteFrame = new Rectangle(947, 11, 32, 32);
        public static Rectangle NorthBombableSpriteFrame = new Rectangle(815, 11, 32, 32);
        public static Rectangle InvisibleVerticleWallFrame = new Rectangle(814, 143, 32, 72);
        public static Rectangle InvisibleHorizontalWallFrame = new Rectangle(814, 143, 112, 32);
        public static Rectangle EastWallSpriteFrame = new Rectangle(815, 77, 32, 32);
        public static Rectangle EastLockedSpriteFrame = new Rectangle(881, 77, 32, 32);
        public static Rectangle EastClosedSpriteFrame = new Rectangle(914, 77, 32, 32);
    }
}
