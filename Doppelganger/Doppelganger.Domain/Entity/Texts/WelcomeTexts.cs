using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class WelcomeTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict = new Dictionary<Enum, string>()
        {
            {
                TextLists.WelcomeTexts.WelcomeToGame,
                "Welcome to the Basic Level School Leaving Exam on Mathematics!\n" 
                + "As you surely know, every Shapeshifter in this country takes their Maturity Exam as they come of age.\n" 
                + "In a moment, you'll see 10 opponents. Turn yourself into one of them and then defeat as many of the rest as you can. Good Luck!"
            }
        };
        
        private static Dictionary<Enum, string> _plDict = new Dictionary<Enum, string>()
        {
            {
                TextLists.WelcomeTexts.WelcomeToGame,
                "Witamy na Maturze Podstawowej z Matematyki!\n"
                + "Jak na pewno dobrze wiesz, każdy Zmiennokształtny w tym kraju po osiągnięciu dorosłości przystępuje do Egzaminu Dojrzałości.\n"
                + "Za chwilę zobaczysz 10 przeciwników. Zmień się w jednego z nich i pokonaj tylu z pozostałych ilu zdołasz. Powodzenia!"
            }
        };

        public WelcomeTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public WelcomeTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}