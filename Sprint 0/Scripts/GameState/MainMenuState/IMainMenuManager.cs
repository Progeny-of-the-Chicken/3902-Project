using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.GameState.MainMenuState
{
    public interface IMainMenuManager
    {
        void Init();

        void Update(GameTime gt);

        void Draw(SpriteBatch spriteBatch, GameTime gt);

        void Scroll(Vector2 displacement);
    }
}
