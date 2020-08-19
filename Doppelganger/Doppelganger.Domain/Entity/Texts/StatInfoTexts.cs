using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class StatInfoTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.StatInfoTexts.AttackInfo,
                    "Damage done per attack."
                },
                {
                    TextLists.StatInfoTexts.SpeedInfo,
                    "Number of turns between attacks."
                },
                {
                    TextLists.StatInfoTexts.HPInfo,
                    "Amount of damage you or your opponent can take."
                }
            };
        
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.StatInfoTexts.AttackInfo,
                    "Obrażenia zadawane w jednym ataku."
                },
                {
                    TextLists.StatInfoTexts.SpeedInfo,
                    "Liczba tur między atakami."
                },
                {
                    TextLists.StatInfoTexts.HPInfo,
                    "Ilość obrażeń jakie Ty lub przeciwnik możesz przyjąć."
                }
            };

        public StatInfoTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public StatInfoTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}