using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public class SuperHotStateHandler : IGameStateHandler
    {
        private IRoomManager roomManager;
        private HUD headsUpDisplay;
        private bool paused = false;
        private bool suspended = false;
        private ISprite[] pausedLetterSprites = new ISprite[ObjectConstants.pausedLetters.Length];
        private Link link;
        private Game1 game;
        private DialogueBox db;

        public SuperHotStateHandler(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;
            db = new DialogueBox(this);

            roomManager = RoomManager.Instance;
            headsUpDisplay = new HUD(ObjectConstants.counterInitialVal_int);
            initializeLetterSprites();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            roomManager.Draw(sb);
            headsUpDisplay.Draw(sb);
            db.Draw(sb);

            if (paused)
            {
                drawPausedLetters(sb);
            }
        }

        public void Update(GameTime gameTime)
        {
            link.Update(gameTime);
            if (!paused)
            {
                if (link.AdvanceTime)
                {
                    if (!suspended)
                    {
                        roomManager.Update(gameTime);
                        headsUpDisplay.Update();
                    }
                }
                db.Update();
            }
        }

        public void TogglePause()
        {
            paused = !paused;

            if (paused)
            {
                link.Suspend();
                game.kc = new PausedKeyboardController(game, Keyboard.GetState());
                SFXManager.Instance.PauseMusic();
            }
            else
            {
                link.UnSuspend();
                game.kc = new KeyboardController(game, Keyboard.GetState());
                SFXManager.Instance.PlayMusic();
            }
        }

        public void DialogueNext()
        {
            db.Next();
        }

        public void ClearDialogue()
        {
            db.ClearDialogue();
        }

        public void AddDialogue(string[] dia, bool forCutscene = false)
        {
            db.AddDialogue(dia, forCutscene);
        }

        public void SetSuspended(bool sus)
        {
            suspended = sus;
        }

        //----- Helper Methods -----//


        private void drawPausedLetters(SpriteBatch sb)
        {
            int xRef = ObjectConstants.pauseDisplayStartingPointX;
            int yRef = ObjectConstants.pauseDisplayStartingPointY;
            int letterSpacing = 8;
            int xStep = ObjectConstants.standardWidthHeight * ObjectConstants.scale + letterSpacing;

            for (int i = 0; i < ObjectConstants.pausedLetters.Length; i++)
            {
                Vector2 drawLocation = new Vector2(xRef + xStep * i, yRef);
                pausedLetterSprites[i].Draw(sb, drawLocation);
            }
        }

        private void initializeLetterSprites()
        {
            for (int i = 0; i < pausedLetterSprites.Length; i++)
            {
                pausedLetterSprites[i] = FontSpriteFactory.Instance.CreateLetterSprite(ObjectConstants.pausedLetters[i]);
            }
        }
    }
}
