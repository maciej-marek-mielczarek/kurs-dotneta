using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

namespace Doppelganger.Domain.Entity.Texts
{
    public class ActionsInfoTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.ActionsInfoTexts.FightInfo,
                    "Press 1-9 to keep fighting for 1-9 turns, 0 to run."
                },
                {
                    TextLists.ActionsInfoTexts.PickAllyInfo,
                    "Press 0-9 to start as creature number 0-9, x to end the game."
                },
                {
                    TextLists.ActionsInfoTexts.PickOpponentInfo,
                    "Press 0-9 to fight creature number 0-9, x to end the game."
                }
            };
        
        [SuppressMessage("ReSharper", "StringLiteralTypo")] private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.ActionsInfoTexts.FightInfo,
                    "Wciśnij 1-9 by kontynuować walkę przez 1-9 tur, 0 by uciec."
                },
                {
                    TextLists.ActionsInfoTexts.PickAllyInfo,
                    "Wciśnij 0-9 by zacząć jako potwór numer 0-9, x by skończyć grę."
                },
                {
                    TextLists.ActionsInfoTexts.PickOpponentInfo,
                    "Wciśnij 0-9 by walczyć z potworem numer 0-9, x by skończyć grę."
                }
            };

        public ActionsInfoTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public ActionsInfoTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}