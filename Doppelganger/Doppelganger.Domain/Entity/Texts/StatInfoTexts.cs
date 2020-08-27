using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

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
        
        [SuppressMessage("ReSharper", "StringLiteralTypo")] private static Dictionary<Enum, string> _plDict =
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