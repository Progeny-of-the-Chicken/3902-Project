using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState.InventoryState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.GameState
{
    //TODO: Update Map thingy when player can pick up map
    //TODO: Update health to when moved to Link/Inventory
    //TODO: Update counters when moved to Link/Inventory
    public class HUD : IHUD
    {
        ISprite backgroundSprite;
        ISprite[] rupeeCounter;
        ISprite[] keyCounter;
        ISprite[] bombCounter;
        ISprite[] heartArray;
        ISprite secondaryWeaponSprite;
        ISprite primaryWeaponSprite;
        ISprite levelDisplay;
        ISprite levelNumber;
        ISprite currentRoomMapMarker;
        ISprite treasureRoomMapMarker;

        Vector2 currentRoom;

        int health;
        int maxHealth;

        public HUD()
        {
            backgroundSprite = InventorySpriteFactory.Instance.CreateHUDBackdropSprite();
            rupeeCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];
            keyCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];
            bombCounter = new ISprite[ObjectConstants.maxDisplayableNumbers];

            //Replace numbers with link's inventory when added
            rupeeCounter = numToSprites(Inventory.Instance.Rupee);
            keyCounter = numToSprites(Inventory.Instance.Key);
            bombCounter = numToSprites(Inventory.Instance.Bomb);

            //Replace numbers with link's health/max health when added
            heartArray = new ISprite[ObjectConstants.maxMaxHealth / 2];
            health = 7;
            maxHealth = 12;
            makeHeartArray();

            secondaryWeaponSprite = InventorySpriteFactory.Instance.CreateWeaponSprite(getFrameForWeapon(Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex]));
            primaryWeaponSprite = InventorySpriteFactory.Instance.CreateWhiteSwordSprite();

            levelDisplay = InventorySpriteFactory.Instance.CreateLevelNumberSprite();
            levelNumber = FontSpriteFactory.Instance.CreateOneSprite();
            currentRoomMapMarker = InventorySpriteFactory.Instance.CreateCurrentRoomMapMarkerSprite();
            treasureRoomMapMarker = InventorySpriteFactory.Instance.CreateTreasureRoomMapMarkerSprite();

            currentRoom = RoomManager.Instance.CurrentRoom.roomLocation;
        }

        public void Update()
        {
            //Replace numbers with link's inventory when added
            rupeeCounter = numToSprites(Inventory.Instance.Rupee);
            keyCounter = numToSprites(Inventory.Instance.Key);
            bombCounter = numToSprites(Inventory.Instance.Bomb);
            //Reminder to update link's health (Although we could pull directly from the instance in draw)
            secondaryWeaponSprite = InventorySpriteFactory.Instance.CreateWeaponSprite(getFrameForWeapon(Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex]));
            makeHeartArray();
            currentRoom = RoomManager.Instance.CurrentRoom.roomLocation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Background
            backgroundSprite.Draw(spriteBatch, new Vector2(0, 0));
            drawNumbers(spriteBatch);
            drawHealth(spriteBatch);
            secondaryWeaponSprite.Draw(spriteBatch, ObjectConstants.secondaryWeaponLocation);
            primaryWeaponSprite.Draw(spriteBatch, ObjectConstants.primaryWeaponLocation);
            drawMap(spriteBatch);
        }

        //-----  Map Related -----//
        private void drawMap(SpriteBatch spriteBatch)
        {
            //Display above map
            levelDisplay.Draw(spriteBatch, ObjectConstants.DungeonLevelDisplayLocation);
            levelNumber.Draw(spriteBatch, ObjectConstants.DungeonLevelNumberDisplayLocation);

            string filePath = Environment.CurrentDirectory.ToString() + ObjectConstants.pathForCsvFiles + "RoomLayout" + ObjectConstants.cvsExtension;
            TextFieldParser csvReader = new TextFieldParser(filePath);
            csvReader.Delimiters = new string[] { ObjectConstants.separator };
            for (int i = 0; i < ObjectConstants.maxDungeonWidthHeight; i++)
            {
                string[] roomRow = csvReader.ReadFields();
                for (int j = 0; j < ObjectConstants.maxDungeonWidthHeight; j++)
                {
                    ISprite roomSprite;
                    if (Inventory.Instance.Map && roomRow[j].Equals("1"))
                    {
                        roomSprite = InventorySpriteFactory.Instance.CreateRoomMapSprite();
                    }
                    else
                    {
                        roomSprite = InventorySpriteFactory.Instance.CreateEmptyMapSprite();
                    }
                    Vector2 drawLocation = ObjectConstants.mapDrawLocation + Vector2.Multiply(new Vector2(j, i), ObjectConstants.roomMapSize);
                    roomSprite.Draw(spriteBatch, drawLocation);
                }
            }
            currentRoomMapMarker.Draw(spriteBatch, ObjectConstants.mapDrawLocation + ObjectConstants.roomMapSize + ObjectConstants.markerXOffset + Vector2.Multiply(currentRoom, ObjectConstants.roomMapSize));
            if (Inventory.Instance.Compass)
            {
                treasureRoomMapMarker.Draw(spriteBatch, ObjectConstants.mapDrawLocation + ObjectConstants.roomMapSize + ObjectConstants.markerXOffset + Vector2.Multiply(ObjectConstants.TreasureRoomLocation, ObjectConstants.roomMapSize));
            }
        }


        //-----  Weapon Related  -----//
        private Rectangle getFrameForWeapon(WeaponType weapon)
        {
            return weapon switch
            {
                WeaponType.BasicBoomerang => SpriteRectangles.weaponBasicBoomerangFrame,
                WeaponType.MagicalBoomerang => SpriteRectangles.weaponMagicalBoomerangFrame,
                WeaponType.Bomb => SpriteRectangles.weaponBombFrame,
                WeaponType.BasicArrow => SpriteRectangles.weaponBasicArrowFrame,
                WeaponType.SilverArrow => SpriteRectangles.weaponSilverArrowFrame,
                WeaponType.Bow => SpriteRectangles.weaponBowFrame,
                WeaponType.BlueCandle => SpriteRectangles.weaponBlueCandleFrame,
                // Default should never happen
                _ => SpriteRectangles.weaponBlueCandleFrame
            };
        }

        //-----  Health Related  -----//
        private void drawHealth(SpriteBatch spriteBatch)
        {
            //Do stuff with getting health from link here
            for (int i = 0; i < ObjectConstants.maxMaxHealth / 2; i++)
            {
                Vector2 drawLocation = new Vector2((176 + 8 * (i % 8)) * ObjectConstants.scale, (32 + 8 * (i / 8)) * ObjectConstants.scale);
                heartArray[i].Draw(spriteBatch, drawLocation);
            }
        }

        private void makeHeartArray()
        {
            for (int i = 0; i < ObjectConstants.maxMaxHealth; i += 2)
            {
                ISprite heart = InventorySpriteFactory.Instance.CreateFullHeartSprite();
                if (i > maxHealth)
                {
                    //black square
                    heart = InventorySpriteFactory.Instance.CreateBlackHUDCoverSprite();
                } else if (i >= health) {
                    //empty heart
                    heart = InventorySpriteFactory.Instance.CreateEmptyHeartSprite();
                } else if (i == health - 1)
                {
                    //half heart
                    heart = InventorySpriteFactory.Instance.CreateHalfHeartSprite();
                } else
                {
                    //full heart
                }
                heartArray[i / 2] = heart;
            }
        }

        //----- Item Count Related -----//
        private void drawNumbers(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < ObjectConstants.maxDisplayableNumbers; i++)
            {
                int xOffset = ObjectConstants.standardWidthHeight / 2 * i * ObjectConstants.scale;
                rupeeCounter[i].Draw(spriteBatch, new Vector2(ObjectConstants.rupeeCounterLocation.X + xOffset, ObjectConstants.rupeeCounterLocation.Y));
                keyCounter[i].Draw(spriteBatch, new Vector2(ObjectConstants.keyCounterLocation.X + xOffset, ObjectConstants.keyCounterLocation.Y));
                bombCounter[i].Draw(spriteBatch, new Vector2(ObjectConstants.bombCounterLocation.X + xOffset, ObjectConstants.bombCounterLocation.Y));
            }
        }

        private ISprite[] numToSprites(int num)
        {
            ISprite[] spriteArray = new ISprite[ObjectConstants.maxDisplayableNumbers];
            for (int i = ObjectConstants.maxDisplayableNumbers - 1; i >= 0; i--)
            {
                spriteArray[i] = singleDigitToSprite(num % 10);
                num /= 10;
            }

            return spriteArray;
        }

        private ISprite singleDigitToSprite(int num)
        {
            switch (num)
            {
                case 0:
                    return FontSpriteFactory.Instance.CreateZeroSprite();
                case 1:
                    return FontSpriteFactory.Instance.CreateOneSprite();
                case 2:
                    return FontSpriteFactory.Instance.CreateTwoSprite();
                case 3:
                    return FontSpriteFactory.Instance.CreateThreeSprite();
                case 4:
                    return FontSpriteFactory.Instance.CreateFourSprite();
                case 5:
                    return FontSpriteFactory.Instance.CreateFiveSprite();
                case 6:
                    return FontSpriteFactory.Instance.CreateSixSprite();
                case 7:
                    return FontSpriteFactory.Instance.CreateSevenSprite();
                case 8:
                    return FontSpriteFactory.Instance.CreateEightSprite();
                case 9:
                    return FontSpriteFactory.Instance.CreateNineSprite();
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
