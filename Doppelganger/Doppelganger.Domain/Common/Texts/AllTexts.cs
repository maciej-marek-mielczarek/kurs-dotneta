using System.Collections.Generic;

namespace Doppelganger.Domain.Common.Texts
{
    public class AllTexts
    {
        public Dictionary<TextCategories, TextsBase> Dictionaries { get; }

        public AllTexts(Dictionary<TextCategories, TextsBase> dictionaries)
        {
            Dictionaries = dictionaries;
        }
    }
}