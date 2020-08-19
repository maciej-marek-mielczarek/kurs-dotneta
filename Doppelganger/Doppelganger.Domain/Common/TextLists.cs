using System;

namespace Doppelganger.Domain.Common
{
    public static class TextLists
    {
        public enum ActionsInfoTexts
        {
            FightInfo,
            PickOpponentInfo,
            PickAllyInfo
        }
        public enum MiscTexts
        {
            WelcomeToGame,
            GetInfoOn,
            AboutAlly,
            AboutOpponent,
            Fight,
            WelcomeToFight,
            YourScoreIs,
            FightWhom,
            StayHowLong,
            PickAlly
        }

        public enum MenuTexts
        {
            NewGame,
            Instructions,
            Exit
        }

        public enum GenericButtonTexts
        {
            Back
        }

        public enum StatInfoTexts
        {
            SpeedInfo,
            HPInfo,
            AttackInfo
        }

        public enum MenuInfoTexts
        {
            Stats,
            Actions,
        }

        public enum StatNames
        {
            Id,
            Attack,
            Speed,
            HP,
            MaxHP
        }

        public enum MechanicsInfoTexts
        {
        }
    }
}