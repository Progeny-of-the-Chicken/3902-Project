using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.GameState
{
    public class DialogueBox
    {
        private Queue<string> lineQueue = new Queue<string>();
        private string currLine = "";
        private int letterSpacing = 6;
        private int framesBetweenLetters = 2;
        private int frameCounter = 0;
        private int currIndex = 0;
        private bool active = false;

        static int maxLetters = 400;
        static int lettersPerLine = 35;
        static int maxLines = 7;
        private int midpoint;
        private int[] linebreaks;
        private ISprite[] letterSprites = new ISprite[maxLetters];

        // Origin point for printed dialogue
        private int initX = 40;
        private int initY = ObjectConstants.yOffsetForRoom + 2 * ObjectConstants.standardWidthHeight;

        public DialogueBox()
        {
        }

        public void Update()
        {
            string output;
            bool queueEmpty = !lineQueue.TryPeek(out output);

            if (queueEmpty)
            {
                active = false;
                currLine = "";
            } else
            {
                active = true;
                if (currLine == "")
                {
                    currLine = lineQueue.Peek();
                    initLetterSpritesForLine();
                }
            }

            if (isPrinting())
            {
                SFXManager.Instance.PlayTextScroll();
            } else
            {
                SFXManager.Instance.StopTextScroll();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (active)
            {
                drawLetters(sb);

                frameCounter++;

                // If the frame counter is equal to the frame buffer, increase
                // currIndex to print the next letter. Also reset the frame counter
                if (frameCounter == framesBetweenLetters)
                {
                    // Only move onto the next char if there's another character
                    // to print.
                    if (currIndex < currLine.Length - 1)
                    {
                        currIndex++;
                    }

                    frameCounter = 0;
                }
            }
        }

        // ALL DIALOGUE LINES CAN MAX BE 70 CHARACTERS, LESS IF WORDS DON'T ALIGN
        // WITH LINE BREAKS!
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
                } else
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
            Array.Clear(letterSprites, 0, maxLetters);

            for (int i = 0; i < currLine.Length; i++)
            {
                letterSprites[i] = FontSpriteFactory.Instance.CreateLetterSprite(currLine[i]);
            }

            midpoint = calculateMidpoint();
            linebreaks = calculateLineBreaks();
        }

        private int calculateMidpoint()
        {
            int len = 0;
            string[] tokens = currLine.Split(" ");

            foreach (string token in tokens)
            {
                len += token.Length;

                if (len > (maxLetters / 2))
                {
                    System.Diagnostics.Debug.WriteLine(len);
                    len -= token.Length;
                    System.Diagnostics.Debug.WriteLine(len);
                    return len - 1;
                } else
                {
                    len++;
                }
            }

            return maxLetters / 2;
        }

        private int[] calculateLineBreaks()
        {
            int[] bps = new int[maxLines];
            int i = 0;
            int len = 0;
            int total = 0;
            string[] tokens = currLine.Split(' ');

            for (int j = 0; j < maxLines; j++)
            {
                bps[j] = lettersPerLine * maxLines + 1;
            }

            foreach (string token in tokens)
            {
                len += token.Length;

                if (len >= lettersPerLine)
                {
                    len -= token.Length;
                    total += len;
                    bps[i] = total;
                    len = token.Length + 1;
                    i++;
                }
                else
                {
                    len++;
                }
            }

            return bps;
        }

        private void drawLetters(SpriteBatch sb)
        {
            int xOffset;
            int yOffset;
            int lineNum = 0;

            for (int i = 0; i <= currIndex; i++)
            {
                if (i == linebreaks[lineNum])
                {
                    lineNum++;
                }

                
                xOffset = (ObjectConstants.standardWidthHeight + letterSpacing) * getCurrCharLinePos(i);
                //System.Diagnostics.Debug.WriteLine(getCurrCharLinePos(i));
                yOffset = 24 * lineNum;

                letterSprites[i].Draw(sb, new Vector2(initX + xOffset, initY + yOffset));
            }
        }

        private bool isPrinting()
        {
            if (currIndex < currLine.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getCurrCharLinePos(int j)
        {
            int pos = j;

            for (int i = maxLines - 1; i >= 0; i--)
            {
                if (pos >= linebreaks[i])
                {
                    return pos - linebreaks[i];
                }
            }

            return pos;
        }
    }
}
