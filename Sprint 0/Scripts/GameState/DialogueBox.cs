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
        private int letterBuffer = 6;
        private int frameBuffer = 2;
        private int frameCounter = 0;
        private int currIndex = 0;
        private bool active = false;

        static int maxLetters = 70;
        private int midpoint;
        private ISprite[] letterSprites = new ISprite[maxLetters];

        private int initX = 40;
        private int initY = ObjectConstants.yOffsetForRoom + 2*ObjectConstants.standardWidthHeight;

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
        }

        public void Draw(SpriteBatch sb)
        {
            if (active)
            {
                drawLetters(sb);

                frameCounter++;

                // If the frame counter is equal to the frame buffer, increase
                // currIndex to print the next letter. Also reset the frame counter
                if (frameCounter == frameBuffer)
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

        private void drawLetters(SpriteBatch sb)
        {
            int xOffset = 0;
            int yOffset = 0;

            for (int i = 0; i <= currIndex; i++)
            {
                bool on1stLine = i <= midpoint;

                if (on1stLine)
                {
                    xOffset = (ObjectConstants.standardWidthHeight + letterBuffer) * i;
                    yOffset = 0;
                }
                else
                {
                    xOffset = (ObjectConstants.standardWidthHeight + letterBuffer) * (i - 1 - midpoint);
                    yOffset = 24;
                }

                letterSprites[i].Draw(sb, new Vector2(initX + xOffset, initY + yOffset));
            }
        }
    }
}
