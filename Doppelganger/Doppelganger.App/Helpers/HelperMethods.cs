﻿using System;
using System.Collections.Generic;
using Doppelganger.App.Services.Abstract.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Helpers
{
    public static class HelperMethods
    {
        public static char GetChar(string possibleChoices)
        {//Not "try to get a correct char", rather "try until you get a correct char".
            char choice;
            bool madeChoice;
            do
            {
                madeChoice = char.TryParse(Console.ReadKey().KeyChar.ToString(), out choice);
                Console.Write("\b \b");
            }
            while (!madeChoice || !possibleChoices.Contains(choice));
            return choice;
        }

        public static void ClearLine(int lineLength = 80)
        {
            string enoughSpaces = new string(' ', lineLength);
            Console.Write('\r' + enoughSpaces + '\r');
        }

        public static int CharDigitToInt(char v)
        {
            if (v >= '0' && v <= '9')
            {
                return v - '0';
            }
            else if (v >= 'a' && v <= 'z')
            {
                return v - 'a' + 10;
            }
            else if (v >= 'A' && v <= 'Z')
            {
                return v - 'A' + 10;
            }
            else
            {
                return v;
            }
        }

        public static string Buttonize(string buttonText, char buttonKey)
        {
            int indexOfKey;
            if (buttonText.Contains(char.ToUpper(buttonKey)))
            {
                indexOfKey = buttonText.IndexOf(char.ToUpper(buttonKey));
            }
            else if(buttonText.Contains(char.ToLower(buttonKey)))
            {
                indexOfKey = buttonText.IndexOf(char.ToLower(buttonKey));
            }
            else
            {
                buttonText += " " + buttonKey;
                indexOfKey = buttonText.Length - 1;
            }
            buttonText = buttonText.Insert(indexOfKey + 1, ")");
            buttonText = buttonText.Insert(indexOfKey, "(");

            return " [" + buttonText + "] ";
        }

        public static int CalculateScore(List<Creature> creatures)
        {
            int score = 0;
            foreach (var creature in creatures)
            {
                int creatureScore = 0;
                if (creature is Ally ally)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * ally.CurrentHP / ally.MaxHP);
                }
                else if (creature is Opponent opponent)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * opponent.CurrentHP / opponent.MaxHP);
                }
                score += creatureScore;
            }
            return score;
        }

        public static void DisplayCurrentHPs(ITextService textService, ICreatureService creatureService, int chosenOppId = -1)
        {
            List<Creature> creatures = creatureService.GetCrts();
            Console.Write(textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; ++i)
            {
                Console.Write(("|"
                               + creatures[i].CurrentHP
                               + (creatures[i] is Ally ? "*" : "")
                               + (i == chosenOppId ? "x" : ""))
                    .PadRight(DisplaySettings.OtherColumnsWidth));
            }
        }
    }
}
