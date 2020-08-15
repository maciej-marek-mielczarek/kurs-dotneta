using System;
using System.Collections.Generic;

namespace Doppelganger
{
    internal static class Helpers
    {
        internal static char GetChar(string possibleChoices)
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

        internal static void ClearLine(int lineLength = 80)
        {
            string enoughSpaces = new string(' ', lineLength);
            Console.Write('\r' + enoughSpaces + '\r');
        }

        internal static int CharDigitToInt(char v)
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

        internal static int CalculateScore(List<Creature> creatures)
        {
            int score = 0;
            foreach (var creature in creatures)
            {
                int creatureScore = 0;
                if (creature is Ally)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * ((decimal)((Ally)creature).CurrentHP) / (decimal)creature.MaxHP);
                }
                else if (creature is Opponent)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * ((decimal)((Opponent)creature).CurrentHP) / (decimal)creature.MaxHP);
                }
                score += creatureScore;
            }
            return score;
        }
    }
}
