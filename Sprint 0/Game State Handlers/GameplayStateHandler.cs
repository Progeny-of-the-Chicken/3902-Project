﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public class GameplayStateHandler: IGameStateHandler
    {
        private IRoomManager roomManager;
        private HUD headsUpDisplay;
        private bool paused = false;
        private ISprite[] pausedLetterSprites = new ISprite[ObjectConstants.pausedLetters.Length];
        private Link link;
        private Game1 game;

        public GameplayStateHandler(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;

            roomManager = RoomManager.Instance;
            roomManager.Init(link);
            headsUpDisplay = HUD.Instance;
            initializeLetterSprites();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            roomManager.Draw(sb);
            headsUpDisplay.Draw(sb);

            if (paused)
            {
                drawPausedLetters(sb);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!paused)
            {
                roomManager.Update(gameTime);
                headsUpDisplay.Update();
            }
        }

        public void TogglePause()
        {
            paused = !paused;
            game.kc.SetPauseState(paused);

            if (paused)
            {
                link.Suspend();
            } else
            {
                link.UnSuspend();
            }
        }


        //----- Helper Methods -----//


        private void drawPausedLetters(SpriteBatch sb)
        {
            int xRef = 200;
            int yRef = 400;
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
