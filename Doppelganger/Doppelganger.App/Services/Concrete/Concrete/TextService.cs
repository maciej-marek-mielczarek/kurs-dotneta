using System;
using System.Collections.Generic;
using Doppelganger.App.Services.Abstract.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Texts;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Services.Concrete.Concrete
{
    public class TextService: ITextService
    {
        private readonly AllTexts _allTexts;
        public TextService(Language language)
        {
            var dictionaries = new Dictionary<TextCategories, TextsBase>
            {
                {TextCategories.ActionsInfoTexts, new ActionsInfoTexts(language)},
                {TextCategories.GenericButtonTexts, new GenericButtonTexts(language)},
                {TextCategories.MenuTexts, new MenuTexts(language)},
                {TextCategories.MiscellaneousTexts, new MiscellaneousTexts(language)},
                {TextCategories.MechanicsInfoTexts, new MechanicsInfoTexts(language)},
                {TextCategories.MenuInfoTexts, new MenuInfoTexts(language)},
                {TextCategories.StatInfoTexts, new StatInfoTexts(language)},
                {TextCategories.StatNameTexts, new StatNameTexts(language)}
            };
            _allTexts = new AllTexts(dictionaries);
        }

        private string GetText(TextCategories category, Enum message)
        {
            return _allTexts.Dictionaries[category].Dict[message];
        }

        public string Welcome()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.WelcomeToGame);
        }

        public string NewGame()
        {
            return GetText(TextCategories.MenuTexts,TextLists.MenuTexts.NewGame);
        }

        public string Instructions()
        {
            return GetText(TextCategories.MenuTexts,TextLists.MenuTexts.Instructions);
        }

        public string Exit()
        {
            return GetText(TextCategories.MenuTexts, TextLists.MenuTexts.Exit);
        }

        public string Stats()
        {
            return GetText(TextCategories.MenuInfoTexts, TextLists.MenuInfoTexts.Stats);
        }

        public string Actions()
        {
            return GetText(TextCategories.MenuInfoTexts, TextLists.MenuInfoTexts.Actions);
        }

        public string Back()
        {
            return GetText(TextCategories.GenericButtonTexts, TextLists.GenericButtonTexts.Back);
        }

        public string GetInfoOn()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.GetInfoOn);
        }

        public string AttackInfo()
        {
            return GetText(TextCategories.StatInfoTexts, TextLists.StatInfoTexts.AttackInfo);
        }

        public string HPInfo()
        {
            return GetText(TextCategories.StatInfoTexts, TextLists.StatInfoTexts.HPInfo);
        }

        public string SpeedInfo()
        {
            return GetText(TextCategories.StatInfoTexts, TextLists.StatInfoTexts.SpeedInfo);
        }

        public string AboutAlly()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.AboutAlly);
        }

        public string AboutOpponent()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.AboutOpponent);
        }

        public string Fight()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.Fight);
        }

        public string WelcomeToFight()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.WelcomeToFight);
        }

        public string YourScoreIs()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.YourScoreIs);
        }

        public string FightWhom()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.FightWhom);
        }

        public string StayHowLong()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.StayHowLong);
        }

        public string FightInfo()
        {
            return GetText(TextCategories.ActionsInfoTexts, TextLists.ActionsInfoTexts.FightInfo);
        }

        public string PickOpponentInfo()
        {
            return GetText(TextCategories.ActionsInfoTexts, TextLists.ActionsInfoTexts.PickOpponentInfo);
        }

        public string PickAllyInfo()
        {
            return GetText(TextCategories.ActionsInfoTexts, TextLists.ActionsInfoTexts.PickAllyInfo);
        }

        public string Id()
        {
            return GetText(TextCategories.StatNameTexts, TextLists.StatNames.Id);
        }

        public string Attack()
        {
            return GetText(TextCategories.StatNameTexts, TextLists.StatNames.Attack);
        }

        public string Speed()
        {
            return GetText(TextCategories.StatNameTexts, TextLists.StatNames.Speed);
        }

        public string HP()
        {
            return GetText(TextCategories.StatNameTexts, TextLists.StatNames.HP);
        }

        public string MaxHP()
        {
            return GetText(TextCategories.StatNameTexts, TextLists.StatNames.MaxHP);
        }

        public string PickAlly()
        {
            return GetText(TextCategories.MiscellaneousTexts, TextLists.MiscTexts.PickAlly);
        }
    }
}