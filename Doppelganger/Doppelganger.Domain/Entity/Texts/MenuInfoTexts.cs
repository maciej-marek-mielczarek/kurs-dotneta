using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

namespace Doppelganger.Domain.Entity.Texts
{
    public class MenuInfoTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.MenuInfoTexts.Actions,
                    "Actions"
                },
                {
                    TextLists.MenuInfoTexts.Stats,
                    "Stats"
                }
            };
        
        [SuppressMessage("ReSharper", "StringLiteralTypo")] private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.MenuInfoTexts.Actions,
                    "Akcje"
                },
                {
                    TextLists.MenuInfoTexts.Stats,
                    "Statystyki"
                }
            };

        public MenuInfoTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public MenuInfoTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}