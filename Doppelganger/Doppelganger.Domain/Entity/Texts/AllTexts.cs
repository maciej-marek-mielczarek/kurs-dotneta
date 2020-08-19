using System;
using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.Domain.Entity.Texts
{
    public class AllTexts
    {
        public Dictionary<TextCathegories, TextsBase> Dictionaries { get; private set; }

        public AllTexts(Dictionary<TextCathegories, TextsBase> dictionaries)
        {
            Dictionaries = dictionaries;
        }
    }
}