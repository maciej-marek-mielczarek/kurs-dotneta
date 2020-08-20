using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

namespace Doppelganger.Domain.Entity.Texts
{
    public class MenuTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.MenuTexts.NewGame,
                    "New Game"
                },
                {
                    TextLists.MenuTexts.Instructions,
                    "Instructions"
                },
                {
                    TextLists.MenuTexts.Exit,
                    "Exit"
                }
            };
        
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.MenuTexts.NewGame,
                    "Nowa Gra"
                },
                {
                    TextLists.MenuTexts.Instructions,
                    "Instrukcje"
                },
                {
                    TextLists.MenuTexts.Exit,
                    "Wyjście"
                }
            };
        public MenuTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public MenuTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}