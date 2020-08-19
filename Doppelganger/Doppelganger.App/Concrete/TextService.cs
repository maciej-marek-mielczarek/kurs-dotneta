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

        private string GetText(TextCathegories cathegory, Enum message)
        {
            return _allTexts.Dictionaries[cathegory].Dict[message];
        }

        public string Welcome()
        {
            return GetText(TextCathegories.WelcomeTexts, TextLists.WelcomeTexts.WelcomeToGame);
        }

        public string NewGame()
        {
            return GetText(TextCathegories.MenuTexts,TextLists.MenuTexts.NewGame);
        }

        public string Instructions()
        {
            return GetText(TextCathegories.MenuTexts,TextLists.MenuTexts.Instructions);
        }

        public string Exit()
        {
            return GetText(TextCathegories.MenuTexts, TextLists.MenuTexts.Exit);
        }
    }
}