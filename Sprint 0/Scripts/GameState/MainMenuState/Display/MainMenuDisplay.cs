using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.MainMenuState.Display
{
    public class MainMenuDisplay : IDisplay
    {
        private Dictionary<ISprite, Vector2> itemSprites = new Dictionary<ISprite, Vector2>();
        private ISprite backgroundSprite;
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
        }

        public void Update(GameTime gt)
        {
            selectionSprite.Update(gt);
            // No animation for weapons
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            backgroundSprite.Draw(spriteBatch, new Vector2(0, 0));
            selectionSprite.Draw(spriteBatch, selectionLocation);
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (KeyValuePair<ISprite, Vector2> item in itemSprites)
            {
                itemSprites[item.Key] += displacement;
            }
            selectionLocation += displacement;
        }

        public void MoveSelection(FacingDirection direction)
        {
            System.Diagnostics.Debug.WriteLine("Selection Index:" + selectionIndex);
            int index = ComputeIndexFromDirection(direction);
            System.Diagnostics.Debug.WriteLine("Computed Index:" + index);

            selectionIndex = index;
            selectionLocation = ObjectConstants.mainMenuSlotLocations[selectionIndex];
        }

        public void SelectOption()
        {
            switch (selectionIndex) { 
                case 0:
                    superhot = true;
                    break;
                case 1:
                    superhot = false;
                    break;
                case 2:
                    randomize = true;
                    break;
                case 3:
                    randomize = false;
                    break;
                }
        }

        private void InitializeSelection()
        {
            selectionSprite = MainMenuSpriteFactory.Instance.CreateSelectionSprite();
            selectionLocation = backdropLocation + ObjectConstants.mainMenuSlotLocations[0];
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
