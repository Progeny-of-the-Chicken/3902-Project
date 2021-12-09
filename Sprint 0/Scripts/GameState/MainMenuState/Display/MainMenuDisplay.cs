using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.MainMenuState.Display
{
    public class MainMenuDisplay : IDisplay
    {
        private ISprite backgroundSprite;
        private ISprite selectedSettingsSprite;
        private Vector2 selectedSettingsLocation1;
        private Vector2 selectedSettingsLocation2;
        private ISprite selectionSprite;
        private Vector2 selectionLocation;
        private int selectionIndex;
        private Vector2 backdropLocation = ObjectConstants.backdropSpawnLocation;
        public bool superhot = false;
        public bool randomize = false;

        public MainMenuDisplay()
        {
            InitializeSelection();
            backgroundSprite = MainMenuSpriteFactory.Instance.CreateBackgroundSprite();
            selectedSettingsSprite = MainMenuSpriteFactory.Instance.CreateCurrentSettingsSprite();
        }

        public void Update(GameTime gt)
        {
            selectionSprite.Update(gt);
            // No animation for weapons
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            backgroundSprite.Draw(spriteBatch, ObjectConstants.zeroVector);
            selectedSettingsSprite.Draw(spriteBatch, selectedSettingsLocation1);
            selectedSettingsSprite.Draw(spriteBatch, selectedSettingsLocation2);
            selectionSprite.Draw(spriteBatch, selectionLocation);
        }

        public void MoveSelection(FacingDirection direction)
        {
            int index = ComputeIndexFromDirection(direction);

            selectionIndex = index;
            selectionLocation = ObjectConstants.mainMenuSlotLocations[selectionIndex];
        }

        public void SelectOption()
        {
            switch (selectionIndex) { 
                case 0:
                    superhot = true;
                    selectedSettingsLocation1 = ObjectConstants.mainMenuSettingsLocations[selectionIndex];
                    break;
                case 1:
                    selectedSettingsLocation1 = ObjectConstants.mainMenuSettingsLocations[selectionIndex];
                    superhot = false;
                    break;
                case 2:
                    selectedSettingsLocation2 = ObjectConstants.mainMenuSettingsLocations[selectionIndex];
                    randomize = true;
                    break;
                case 3:
                    selectedSettingsLocation2 = ObjectConstants.mainMenuSettingsLocations[selectionIndex];
                    randomize = false;
                    break;
                }
        }

        private void InitializeSelection()
        {
            selectionSprite = MainMenuSpriteFactory.Instance.CreateSelectionSprite();
            selectionLocation = backdropLocation + ObjectConstants.mainMenuSlotLocations[0];
            selectedSettingsLocation1 = ObjectConstants.mainMenuSettingsLocations[ObjectConstants.superhotFalse];
            selectedSettingsLocation2 = ObjectConstants.mainMenuSettingsLocations[ObjectConstants.randomizeFalse];
        }

        //----- Helper method for selection movement -----//

        private int ComputeIndexFromDirection(FacingDirection direction)
        {
            return direction switch
            {
                FacingDirection.Right => (selectionIndex + 1)% ObjectConstants.halfMainMenuOptionsCount + ObjectConstants.halfMainMenuOptionsCount * (selectionIndex/ ObjectConstants.halfMainMenuOptionsCount),
                FacingDirection.Up => (selectionIndex + ObjectConstants.halfMainMenuOptionsCount) % ObjectConstants.mainMenuOptionsCount,
                FacingDirection.Left => (selectionIndex + 1) % ObjectConstants.halfMainMenuOptionsCount + ObjectConstants.halfMainMenuOptionsCount * (selectionIndex/ObjectConstants.halfMainMenuOptionsCount),
                FacingDirection.Down => (selectionIndex + ObjectConstants.halfMainMenuOptionsCount) % ObjectConstants.mainMenuOptionsCount,
                // Default should never happen
                _ => selectionIndex
            };
        }

        
    }
}
