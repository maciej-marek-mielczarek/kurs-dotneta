using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class GenericButtonTexts : TextsBase
    {
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {TextLists.GenericButtonTexts.Back, "Powrót"}
            };

        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {TextLists.GenericButtonTexts.Back, "Back"}
            };

        public GenericButtonTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }

        public GenericButtonTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}