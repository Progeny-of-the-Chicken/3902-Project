using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.GameState
{
    public class GameOverScreen
    {
        ISprite background;

        public GameOverScreen()
        {
            background = GameStateSpriteFactory.Instance.CreateBlackBackground();
        }

        public void Update()
        {
            // No animation
        }

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb, new Vector2(0, 0));
        }
    }
}
