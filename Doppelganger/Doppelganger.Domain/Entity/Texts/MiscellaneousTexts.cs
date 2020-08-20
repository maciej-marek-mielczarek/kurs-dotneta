using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

namespace Doppelganger.Domain.Entity.Texts
{
    public class MiscellaneousTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict = new Dictionary<Enum, string>()
        {
            {
                TextLists.MiscTexts.WelcomeToGame,
                "Welcome to the Basic Level School Leaving Exam on Mathematics!\n" 
                + "As you surely know, every Shapeshifter in this country takes their Maturity Exam as they come of age.\n" 
                + "In a moment, you'll see 10 opponents. Turn yourself into one of them and then defeat as many of them as you can. Good Luck!"
            },
            {
                TextLists.MiscTexts.GetInfoOn,
                "Get informafion on: "
            },
            {
                TextLists.MiscTexts.Fight, 
                "Fight"
            },
            {
                TextLists.MiscTexts.AboutAlly, 
                "Ally"
            },
            {
                TextLists.MiscTexts.AboutOpponent, 
                "Opponent"
            },
            {
                TextLists.MiscTexts.FightWhom, 
                " Fight who?"
            },
            {
                TextLists.MiscTexts.WelcomeToFight, 
                "Let The Test begin!"
            },
            {
                TextLists.MiscTexts.StayHowLong, 
                "Stay how long?"
            },
            {
                TextLists.MiscTexts.YourScoreIs, 
                "Your score is: "
            },
            {
                TextLists.MiscTexts.PickAlly,
                "Please choose an opponent to turn into."
            }
        };
        
        private static Dictionary<Enum, string> _plDict = new Dictionary<Enum, string>()
        {
            {
                TextLists.MiscTexts.WelcomeToGame,
                "Witamy na Maturze Podstawowej z Matematyki!\n"
                + "Jak na pewno dobrze wiesz, każdy Zmiennokształtny w tym kraju po osiągnięciu dorosłości przystępuje do Egzaminu Dojrzałości.\n"
                + "Za chwilę zobaczysz 10 przeciwników. Zmień się w jednego z nich i pokonaj tylu z nich ilu zdołasz. Powodzenia!"
            },
            {
                TextLists.MiscTexts.GetInfoOn,
                "Dowiedz się o: "
            },
            {
                TextLists.MiscTexts.Fight, 
                "Walka"
            },
            {
                TextLists.MiscTexts.AboutAlly, 
                "Sojuszniku"
            },
            {
                TextLists.MiscTexts.AboutOpponent, 
                "Przeciwniku"
            },
            {
                TextLists.MiscTexts.FightWhom, 
                " Kogo bić?"
            },
            {
                TextLists.MiscTexts.WelcomeToFight, 
                "Rozpoczynamy Test!"
            },
            {
                TextLists.MiscTexts.StayHowLong, 
                "Jak długo bić?"
            },
            {
                TextLists.MiscTexts.YourScoreIs, 
                "Twój wynik to: "
            },
            {
                TextLists.MiscTexts.PickAlly,
                "Wybierz w którego przeciwnika chcesz się zmienić."
            }
        };

        public MiscellaneousTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public MiscellaneousTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}