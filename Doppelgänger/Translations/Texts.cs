using System;

namespace Translations
{
    internal class Texts
    {
        private char languageCode;

        public Texts(char languageCode)
        {
            this.languageCode = languageCode;
        }

        internal void Welcome()
        {
            switch (languageCode)
            {
                case 'p':
                    Console.WriteLine("Witamy na Maturze Podstawowej z Transformacji!\n" +
                    	"Jak na pewno dobrze wiesz, każdy Zmiennokształtny w tym kraju po osiągnięciu dorosłości przystępuje do Egzaminu Dojrzałości.\n" +
                    	"Za chwilę zobaczysz 10 przeciwników. Zmień się w jednego z nich i pokonaj tylu z pozostałych ilu zdołasz. Powodzenia!");
                    break;
                case 'e':
                    Console.WriteLine("Welcome to the Basic Level School Leaving Exam on Transformation!\n" +
                    	"As you surely know, every Shapeshifter in this country takes their Maturity Exam as they come of age.\n" +
                    	"In a moment, you'll see 10 opponents. Turn yourself into one of them and then defeat as many of the rest as you can. Good Luck!");
                    break;
                default:
                    break;
            }
        }

        internal string NewGame()
        {
            string newGame = "\n(n)";
            switch (languageCode)
            {
                case 'p':
                    newGame = "(N)owa Gra";
                    break;
                case 'e':
                    newGame = "(N)ew Game";
                    break;
                default:
                    break;
            }
            return newGame;
        }

        internal string Instructions()
        {
            string instructions = "\n(i)";
            switch (languageCode)
            {
                case 'p':
                    instructions = "(I)nstrukcje";
                    break;
                case 'e':
                    instructions = "(I)nstructions";
                    break;
                default:
                    break;
            }
            return instructions;
        }

        internal string Exit()
        {
            string exit = "\n(x)";
            switch (languageCode)
            {
                case 'p':
                    exit = "Wyjście (x)";
                    break;
                case 'e':
                    exit = "E(x)it";
                    break;
                default:
                    break;
            }
            return exit;
        }
    }
}