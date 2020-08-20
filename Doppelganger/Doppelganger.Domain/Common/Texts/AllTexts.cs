using System.Collections.Generic;

namespace Doppelganger.Domain.Common.Texts
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