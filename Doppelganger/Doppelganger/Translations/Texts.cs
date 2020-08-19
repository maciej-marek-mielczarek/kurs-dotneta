namespace Translations
{
    internal class Texts
    {
        private char languageCode;

        public Texts(char languageCode)
        {
            this.languageCode = languageCode;
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

        internal string HPButton()
        {
            string hp = "(h)";
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

        internal string SpeedButton()
        {
            string speed = "(s)";
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
                    pickAlly = "Sojuszniku";
                    break;
                case 'e':
                    pickAlly = "Ally";
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
                    pickOpp = "Przeciwniku";
                    break;
                case 'e':
                    pickOpp = "Opponent";
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
                    fight = "Walka";
                    break;
                case 'e':
                    fight = "Fight";
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

        internal string FightWhom()
        {
            string fightWhom = "";
            switch (languageCode)
            {
                case 'p':
                    fightWhom = " Kogo bić?";
                    break;
                case 'e':
                    fightWhom = " Fight who?";
                    break;
                default:
                    break;
            }
            return fightWhom;
        }

        internal string StayHowLong()
        {
            string stayHowLong = "";
            switch (languageCode)
            {
                case 'p':
                    stayHowLong = "Jak długo bić?";
                    break;
                case 'e':
                    stayHowLong = "Stay how long?";
                    break;
                default:
                    break;
            }
            return stayHowLong;
        }
    }
}