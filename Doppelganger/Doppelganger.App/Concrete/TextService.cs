using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Concrete
{
    public class TextService: ITextService
    {
        private readonly AllTexts _allTexts;
        public TextService(Language language)
        {
            var dictionaries = new Dictionary<TextCathegories, TextsBase>
            {
                {TextCathegories.ActionsInfoTexts, new ActionsInfoTexts(language)},
                {TextCathegories.GenericButtonTexts, new GenericButtonTexts(language)},
                {TextCathegories.MenuTexts, new MenuTexts(language)},
                {TextCathegories.MiscellaneousTexts, new MiscellaneousTexts(language)},
                {TextCathegories.MechanicsInfoTexts, new MechanicsInfoTexts(language)},
                {TextCathegories.MenuInfoTexts, new MenuInfoTexts(language)},
                {TextCathegories.StatInfoTexts, new StatInfoTexts(language)},
                {TextCathegories.StatNameTexts, new StatNameTexts(language)}
            };
            _allTexts = new AllTexts(dictionaries);
        }

        private string GetText(TextCathegories cathegory, Enum message)
        {
            return _allTexts.Dictionaries[cathegory].Dict[message];
        }

        public string Welcome()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.WelcomeToGame);
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

        public string Stats()
        {
            return GetText(TextCathegories.MenuInfoTexts, TextLists.MenuInfoTexts.Stats);
        }

        public string Actions()
        {
            return GetText(TextCathegories.MenuInfoTexts, TextLists.MenuInfoTexts.Actions);
        }

        public string Back()
        {
            return GetText(TextCathegories.GenericButtonTexts, TextLists.GenericButtonTexts.Back);
        }

        public string GetInfoOn()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.GetInfoOn);
        }

        public string AttackInfo()
        {
            return GetText(TextCathegories.StatInfoTexts, TextLists.StatInfoTexts.AttackInfo);
        }

        public string HPInfo()
        {
            return GetText(TextCathegories.StatInfoTexts, TextLists.StatInfoTexts.HPInfo);
        }

        public string SpeedInfo()
        {
            return GetText(TextCathegories.StatInfoTexts, TextLists.StatInfoTexts.SpeedInfo);
        }

        public string AboutAlly()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.AboutAlly);
        }

        public string AboutOpponent()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.AboutOpponent);
        }

        public string Fight()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.Fight);
        }

        public string WelcomeToFight()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.WelcomeToFight);
        }

        public string YourScoreIs()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.YourScoreIs);
        }

        public string FightWhom()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.FightWhom);
        }

        public string StayHowLong()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.StayHowLong);
        }

        public string FightInfo()
        {
            return GetText(TextCathegories.ActionsInfoTexts, TextLists.ActionsInfoTexts.FightInfo);
        }

        public string PickOpponentInfo()
        {
            return GetText(TextCathegories.ActionsInfoTexts, TextLists.ActionsInfoTexts.PickOpponentInfo);
        }

        public string PickAllyInfo()
        {
            return GetText(TextCathegories.ActionsInfoTexts, TextLists.ActionsInfoTexts.PickAllyInfo);
        }

        public string Id()
        {
            return GetText(TextCathegories.StatNameTexts, TextLists.StatNames.Id);
        }

        public string Attack()
        {
            return GetText(TextCathegories.StatNameTexts, TextLists.StatNames.Attack);
        }

        public string Speed()
        {
            return GetText(TextCathegories.StatNameTexts, TextLists.StatNames.Speed);
        }

        public string HP()
        {
            return GetText(TextCathegories.StatNameTexts, TextLists.StatNames.HP);
        }

        public string MaxHP()
        {
            return GetText(TextCathegories.StatNameTexts, TextLists.StatNames.MaxHP);
        }

        public string PickAlly()
        {
            return GetText(TextCathegories.MiscellaneousTexts, TextLists.MiscTexts.PickAlly);
        }
    }
}