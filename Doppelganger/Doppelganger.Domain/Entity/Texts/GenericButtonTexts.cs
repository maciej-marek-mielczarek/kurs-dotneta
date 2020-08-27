using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;

namespace Doppelganger.Domain.Entity.Texts
{
    public class GenericButtonTexts : TextsBase
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")] private static Dictionary<Enum, string> _plDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.GenericButtonTexts.Back,
                    "Powrót"
                }
            };

        private static Dictionary<Enum, string> _enDict =
            new Dictionary<Enum, string>()
            {
                {
                    TextLists.GenericButtonTexts.Back,
                    "Back"
                }
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