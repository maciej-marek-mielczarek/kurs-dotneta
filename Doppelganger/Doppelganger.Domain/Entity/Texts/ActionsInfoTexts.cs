using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class ActionsInfoTexts: TextsBase
    {
        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
            };
        
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
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