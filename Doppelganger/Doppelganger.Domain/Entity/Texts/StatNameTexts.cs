using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class StatNameTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.StatNames.Attack,
                    "Attack"
                },
                {
                    TextLists.StatNames.Id,
                    "Id"
                },
                {
                    TextLists.StatNames.Speed,
                    "Speed"
                },
                {
                    TextLists.StatNames.HP,
                    "Health"
                },
                {
                    TextLists.StatNames.MaxHP,
                    "Max Health"
                }
            };
        
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.StatNames.Attack,
                    "Atak"
                },
                {
                    TextLists.StatNames.Id,
                    "Id"
                },
                {
                    TextLists.StatNames.Speed,
                    "Szybkość"
                },
                {
                    TextLists.StatNames.HP,
                    "Zdrowie"
                },
                {
                    TextLists.StatNames.MaxHP,
                    "Maks. Zdrowie"
                }
            };

        public StatNameTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }
        
        public StatNameTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}