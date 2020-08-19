using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Concrete
{
    public class TextService: ITextService
    {
        private AllTexts _allTexts;
        public TextService(Language language)
        {
            var dictionaries = new Dictionary<TextCathegories, TextsBase>();
            
            dictionaries.Add(TextCathegories.ButtonTexts, new ButtonTexts(language));
            dictionaries.Add(TextCathegories.MenuTexts, new MenuTexts(language));
            dictionaries.Add(TextCathegories.WelcomeTexts, new WelcomeTexts(language));
            dictionaries.Add(TextCathegories.MechanicsInfoTexts, new MechanicsInfoTexts(language));
            dictionaries.Add(TextCathegories.MenuInfoTexts, new MenuInfoTexts(language));
            dictionaries.Add(TextCathegories.StatInfoTexts, new StatInfoTexts(language));
            dictionaries.Add(TextCathegories.StatNameTexts, new StatNameTexts(language));
            
            _allTexts = new AllTexts(dictionaries);
        }

        public string Welcome()
        {
            return _allTexts.Dictionaries[TextCathegories.WelcomeTexts].Dict[TextLists.WelcomeTexts.WelcomeToGame];
        }
    }
}