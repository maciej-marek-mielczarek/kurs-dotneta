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
                    Console.WriteLine("Witamy na Maturze Podstawowej z Matematyki!\n" +
                    	"Jak na pewno dobrze wiesz, każdy Zmiennokształtny w tym kraju po osiągnięciu dorosłości przystępuje do Egzaminu Dojrzałości.\n" +
                    	"Za chwilę zobaczysz 10 przeciwników. Zmień się w jednego z nich i pokonaj tylu z pozostałych ilu zdołasz. Powodzenia!");
                    break;
                case 'e':
                    Console.WriteLine("Welcome to the Basic Level School Leaving Exam on Mathematics!\n" +
                    	"As you surely know, every Shapeshifter in this country takes their Maturity Exam as they come of age.\n" +
                    	"In a moment, you'll see 10 opponents. Turn yourself into one of them and then defeat as many of the rest as you can. Good Luck!");
                    break;
                default:
                    break;
            }
        }

        internal string NewGame()
        {
            string newGame = "(n)";
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
            string instructions = "(i)";
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
            string exit = "(x)";
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

        internal string Stats()
        {
            string stats = "(s)";
            switch (languageCode)
            {
                case 'p':
                    stats = "(S)tatystyki";
                    break;
                case 'e':
                    stats = "(S)tats";
                    break;
                default:
                    break;
            }
            return stats;
        }

        internal string Actions()
        {
            string actions = "(a)";
            switch (languageCode)
            {
                case 'p':
                    actions = "(A)kcje";
                    break;
                case 'e':
                    actions = "(A)ctions";
                    break;
                default:
                    break;
            }
            return actions;
        }

        internal string GetInfoOn()
        {
            string getInfoOn = "";
            switch (languageCode)
            {
                case 'p':
                    getInfoOn = "Dowiedz się o: ";
                    break;
                case 'e':
                    getInfoOn = "Get informafion on: ";
                    break;
                default:
                    break;
            }
            return getInfoOn;
        }

        internal string Attack()
        {
            string attack = "(a)";
            switch (languageCode)
            {
                case 'p':
                    attack = "(A)tak";
                    break;
                case 'e':
                    attack = "(A)ttack";
                    break;
                default:
                    break;
            }
            return attack;
        }

        internal string HP()
        {
            string hp = "(h)";
            switch (languageCode)
            {
                case 'p':
                    hp = "Zdrowie (h)";
                    break;
                case 'e':
                    hp = "(H)ealth";
                    break;
                default:
                    break;
            }
            return hp;
        }

        internal string Speed()
        {
            string speed = "(s)";
            switch (languageCode)
            {
                case 'p':
                    speed = "(S)zybkość";
                    break;
                case 'e':
                    speed = "(S)peed";
                    break;
                default:
                    break;
            }
            return speed;
        }

        internal string Back()
        {
            string back = "(b)";
            switch (languageCode)
            {
                case 'p':
                    back = "Wstecz (b)";
                    break;
                case 'e':
                    back = "(B)ack";
                    break;
                default:
                    break;
            }
            return back;
        }

        internal string PickAlly()
        {
            string pickAlly = "(a)";
            switch (languageCode)
            {
                case 'p':
                    pickAlly = "Sojuszniku (a)";
                    break;
                case 'e':
                    pickAlly = "(A)lly";
                    break;
                default:
                    break;
            }
            return pickAlly;
        }

        internal string PickOpponent()
        {
            string pickOpp = "(o)";
            switch (languageCode)
            {
                case 'p':
                    pickOpp = "Przeciwniku (o)";
                    break;
                case 'e':
                    pickOpp = "(O)pponent";
                    break;
                default:
                    break;
            }
            return pickOpp;
        }

        internal string Fight()
        {
            string fight = "(f)";
            switch (languageCode)
            {
                case 'p':
                    fight = "Walka (f)";
                    break;
                case 'e':
                    fight = "(F)ight";
                    break;
                default:
                    break;
            }
            return fight;
        }
    }
}