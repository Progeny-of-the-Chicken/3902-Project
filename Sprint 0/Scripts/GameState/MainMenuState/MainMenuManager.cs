using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.GameState.MainMenuState.Display;

namespace Sprint_0.Scripts.GameState.MainMenuState
{
    public class MainMenuManager : IMainMenuManager
    {
        private IDisplay display;

        private static MainMenuManager instance = new MainMenuManager();

        public static MainMenuManager Instance
        {
            get
            {
                return instance;
            }
        }

        private MainMenuManager()
        {
        }

        public void Init()
        {
            display = new MainMenuDisplay();
        }

        public void Update(GameTime gt)
        {
            display.Update(gt);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            display.Draw(spriteBatch, gt);
        }

        public void Scroll(Vector2 displacement)
        {

            display.Scroll(displacement);
        }

        public void MoveSelection(FacingDirection direction)
        {
            ((MainMenuDisplay)display).MoveSelection(direction);
        }

        public void SelectOption()
        {
            ((MainMenuDisplay)display).SelectOption();
        }
    }
}
