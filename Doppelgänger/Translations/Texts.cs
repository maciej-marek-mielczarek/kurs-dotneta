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

        internal string AttackButton()
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

        internal string HPButton()
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

        internal string SpeedButton()
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

        internal string SpeedInfo()
        {
            string speedInfo = "";
            switch(languageCode)
            {
                case 'p':
                    speedInfo = "Liczba tur między atakami.";
                    break;
                case 'e':
                    speedInfo = "Number of turns between attacks.";
                    break;
                default:
                    break;
            }
            return speedInfo;
        }

        internal string PickAllyButton()
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

        internal string HPInfo()
        {
            string hpInfo = "";
            switch (languageCode)
            {
                case 'p':
                    hpInfo = "Ilość obrażeń jakie Ty lub przeciwnik możesz przyjąć.";
                    break;
                case 'e':
                    hpInfo = "Amount of damage you or your opponent can take.";
                    break;
                default:
                    break;
            }
            return hpInfo;
        }

        internal string PickOpponentButton()
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

        internal string FightButton()
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

        internal string AttackInfo()
        {
            string attackInfo = "";
            switch (languageCode)
            {
                case 'p':
                    attackInfo = "Obrażenia zadawane w jednym ataku.";
                    break;
                case 'e':
                    attackInfo = "Damage done per attack.";
                    break;
                default:
                    break;
            }
            return attackInfo;
        }

        internal string FightInfo()
        {
            string fightInfo = "";
            switch (languageCode)
            {
                case 'p':
                    fightInfo = "Wciśnij 1-9 by kontynuować walkę przez 1-9 tur, 0 by uciec.";
                    break;
                case 'e':
                    fightInfo = "Press 1-9 to keep fighting for 1-9 turns, 0 to run.";
                    break;
                default:
                    break;
            }
            return fightInfo;
        }

        internal string PickOpponentInfo()
        {
            string oppInfo = "";
            switch (languageCode)
            {
                case 'p':
                    oppInfo = "Wciśnij 0-9 by walczyć z potworem numer 0-9, x by skończyć grę.";
                    break;
                case 'e':
                    oppInfo = "Press 0-9 to fight creature number 0-9, x to end the game.";
                    break;
                default:
                    break;
            }
            return oppInfo;
        }

        internal string PickAllyInfo()
        {
            string allyInfo = "";
            switch (languageCode)
            {
                case 'p':
                    allyInfo = "Wciśnij 0-9 by zacząć jako potwór numer 0-9, x by skończyć grę.";
                    break;
                case 'e':
                    allyInfo = "Press 0-9 to start as creature number 0-9, x to end the game.";
                    break;
                default:
                    break;
            }
            return allyInfo;
        }

        internal string WelcomeToFight()
        {
            string welcomeToFight = "";
            switch(languageCode)
            {
                case 'p':
                    welcomeToFight = "Rozpoczynamy Test!";
                    break;
                case 'e':
                    welcomeToFight = "Let The Test begin!";
                    break;
                default:
                    break;
            }
            return welcomeToFight;
        }

        internal string Id()
        {
            string id = "";
            switch(languageCode)
            {
                case 'p':
                    id = "Id";
                    break;
                case 'e':
                    id = "Id";
                    break;
                default:
                    break;
            }
            return id;
        }

        internal string Attack()
        {
            string attack = "";
            switch (languageCode)
            {
                case 'p':
                    attack = "Atak";
                    break;
                case 'e':
                    attack = "Attack";
                    break;
                default:
                    break;
            }
            return attack;
        }

        internal string Speed()
        {
            string speed = "";
            switch (languageCode)
            {
                case 'p':
                    speed = "Szybkość";
                    break;
                case 'e':
                    speed = "Speed";
                    break;
                default:
                    break;
            }
            return speed;
        }

        internal string HP()
        {
            string hp = "";
            switch (languageCode)
            {
                case 'p':
                    hp = "Zdrowie";
                    break;
                case 'e':
                    hp = "Health";
                    break;
                default:
                    break;
            }
            return hp;
        }

        internal string MaxHP()
        {
            string maxHP = "";
            switch (languageCode)
            {
                case 'p':
                    maxHP = "Maks. Zdrowie";
                    break;
                case 'e':
                    maxHP = "Max Health";
                    break;
                default:
                    break;
            }
            return maxHP;
        }

        internal string PickAlly()
        {
            string pickAlly = "";
            switch(languageCode)
            {
                case 'p':
                    pickAlly = "Wybierz w którego przeciwnika chcesz się zmienić.";
                    break;
                case 'e':
                    pickAlly = "Please choose an opponent to turn into.";
                    break;
                default:
                    break;
            }
            return pickAlly;
        }

        internal string YourScoreIs()
        {
            string yourScoreIs = "";
            switch (languageCode)
            {
                case 'p':
                    yourScoreIs = "Twój wynik to: ";
                    break;
                case 'e':
                    yourScoreIs = "Your score is: ";
                    break;
                default:
                    break;
            }
            return yourScoreIs;
        }

    }
}