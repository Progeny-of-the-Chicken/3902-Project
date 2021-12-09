using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.GameStateHandlers;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Terrain.LevelData;

namespace Sprint_0.Scripts.GameState
{
    public class DialogueBox
    {
        private Queue<string> lineQueue = new Queue<string>();
        private string currLine = "";
        private int frameCounter = 0;
        private int currIndex = 0;
        private bool active = false;

        private int[] linebreaks;
        private ISprite[] letterSprites = new ISprite[ObjectConstants.maxLetters];
        private IGameStateHandler gsh;

        // Origin point for printed dialogue
        private int initX = ObjectConstants.dialogueStartX;
        private int initY = ObjectConstants.dialogueStartY;

        public DialogueBox(IGameStateHandler gsh)
        {
            this.gsh = gsh;
        }

        public void Update()
        {
            string output;
            bool queueEmpty = !lineQueue.TryPeek(out output);

            if (queueEmpty)
            {
                active = false;
                currLine = "";
            }
            else
            {
                if (roomSuspendsForCutScene())
                {
                    gsh.SetSuspended(true);
                }

                active = true;
                if (currLine == "")
                {
                    currLine = lineQueue.Peek();
                    initLetterSpritesForLine();
                }
            }

            StartStopTextScrollSFX();
        }

        public void Draw(SpriteBatch sb)
        {
            if (active)
            {
                drawLetters(sb);
                frameCounter++;

                if (frameCounter == ObjectConstants.framesBetweenLetters)
                {
                    if (currIndex < currLine.Length - 1)
                    {
                        currIndex++;
                    }

                    frameCounter = 0;
                }
            }
        }

        public void AddDialogue(string[] dia)
        {
            foreach (string line in dia)
            {
                lineQueue.Enqueue(line);
            }
        }

        public void Next()
        {
            if (active)
            {
                string nextLine;

                lineQueue.Dequeue();
                currIndex = 0;
                frameCounter = 0;

                bool isEmpty = !lineQueue.TryPeek(out nextLine);

                if (isEmpty)
                {
                    active = false;
                    currLine = "";

                    if (roomSuspendsForCutScene())
                    {
                        gsh.SetSuspended(false);
                    }
                }
                else
                {
                    currLine = nextLine;
                    initLetterSpritesForLine();
                }
            }
        }


        // ----- Helper Methods ----- //

        // Creates the letter sprites for the line being shown on screen
        private void initLetterSpritesForLine()
        {
            Array.Clear(letterSprites, 0, ObjectConstants.maxLetters);

            for (int i = 0; i < currLine.Length; i++)
            {
                letterSprites[i] = FontSpriteFactory.Instance.CreateLetterSprite(currLine[i]);
            }

            linebreaks = calculateLineBreaks();
        }

        // Determines what indexes a string should begin printing on a new line based
        // on the attribute lettersPerLine
        private int[] calculateLineBreaks()
        {
            int[] bps = new int[ObjectConstants.maxLines];
            int i = 0;
            int len = 0;
            int total = 0;
            string[] tokens = currLine.Split(' ');

            for (int j = 0; j < ObjectConstants.maxLines; j++)
            {
                bps[j] = int.MaxValue;
            }

            // Loops through each word and determines at what indexes the string should
            // begin printing on a new line.
            foreach (string token in tokens)
            {
                len += token.Length;

                if (len >= ObjectConstants.lettersPerLine)
                {
                    len -= token.Length;
                    total += len;
                    bps[i] = total;
                    len = token.Length;

                    if (i != 0)
                    {
                        len++;
                    }

                    i++;
                }
                else
                {
                    len++;
                }
            }

            return bps;
        }

        // Draws the letters in currLine to the screen
        private void drawLetters(SpriteBatch sb)
        {
            int xOffset;
            int yOffset;
            int lineNum = 0;
            int currPos = 0;
            bool lineStartedWithSpace = false;

            for (int i = 0; i <= currIndex; i++)
            {
                if (i == linebreaks[lineNum])
                {
                    lineNum++;
                }

                currPos = getCurrCharLinePos(i);

                if (currPos == 0)
                {
                    if (currLine[i] == ' ')
                    {
                        lineStartedWithSpace = true;
                    }
                    else
                    {
                        lineStartedWithSpace = false;
                    }
                }

                if (lineStartedWithSpace)
                {
                    xOffset = (ObjectConstants.standardWidthHeight + ObjectConstants.letterSpacing) * (currPos - 1);
                } else
                {
                    xOffset = (ObjectConstants.standardWidthHeight + ObjectConstants.letterSpacing) * currPos;
                }
                
                yOffset = 24 * lineNum;

                letterSprites[i].Draw(sb, new Vector2(initX + xOffset, initY + yOffset));
            }
        }

        // Plays the text scrolling sound effect while new letters are being printed.
        // Stops the sound effect when new letters stop being printed.
        private void StartStopTextScrollSFX()
        {
            if (currIndex < currLine.Length - 1)
            {
                System.Console.WriteLine(currIndex);
                SFXManager.Instance.PlayTextScroll();
            }
            else
            {
                SFXManager.Instance.StopTextScroll();
            }
        }

        // Returns what position the letter is in the line it will be printed on
        private int getCurrCharLinePos(int j)
        {
            int pos = j;

            for (int i = ObjectConstants.maxLines - 1; i >= 0; i--)
            {
                if (pos >= linebreaks[i])
                {
                    return pos - linebreaks[i];
                }
            }

            return pos;
        }

        private bool roomSuspendsForCutScene()
        {
            return CutSceneData.IsSuspendedUntilDialogueCleared(RoomManager.Instance.CurrentRoom.RoomId());
        }
    }
}
