namespace Translations
{
    internal class Texts
    {
        private char languageCode;

        public Texts(char languageCode)
        {
            this.languageCode = languageCode;
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
    }
}