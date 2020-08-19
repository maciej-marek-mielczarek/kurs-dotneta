using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class ButtonTexts : TextsBase
    {
        private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {TextLists.ButtonTexts.Back, "Powrót"}
            };

        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {TextLists.ButtonTexts.Back, "Back"}
            };

        public ButtonTexts(Dictionary<Enum, string> dictionary) : base(dictionary)
        {
        }

        public ButtonTexts(Language language) : base(language switch
        {
            Language.English => _enDict,
            Language.Polish => _plDict,
            _ => _enDict
        })
        {
        }
    }
}