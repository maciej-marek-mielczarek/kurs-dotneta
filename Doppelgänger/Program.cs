﻿using System;
using System.Collections.Generic;
using Translations;

namespace Doppelgänger
{
    class Program
    {
        private static Texts texts;
        static void Main(string[] args)
        {
            MenuActionService menuActionService = new MenuActionService();
            InitializeLang(menuActionService);

            Console.WriteLine("Doppelgänger, a puzzle/rpg game.");

            {
                Console.Write("Please choose your language: ");
                List<MenuAction> actions = menuActionService.GetActionsForMenu("Lang");
                string possibleChoices = "";
                foreach (var action in actions)
                {
                    Console.Write('[' + action.ActionName + ']');
                    possibleChoices += action.KeyToChoose;
                }
                char languageCode = Helpers.GetChar(possibleChoices);
                Helpers.ClearLine();
                texts = new Texts(languageCode);
                Initialize(menuActionService);
            }
            texts.Welcome();

            {
                List<MenuAction> actions = menuActionService.GetActionsForMenu("Main");
                string possibleChoices = "";
                foreach (var action in actions)
                {
                    Console.Write('[' + action.ActionName + ']');
                    possibleChoices += action.KeyToChoose;
                }
                char menuChoice = Helpers.GetChar(possibleChoices);
                Helpers.ClearLine();
                Console.WriteLine("Your menu choice: " + menuChoice);
            }
            //2. main menu
            ///2a. new game: generate enemies and go to fight menu, choose ally submenu

            ////2a1. fight menu:
            //// display opponents' invariant stats
            //// and do sth in last line
            //// x to end game and go to end game submenu (e is too close to numbers on keyboard)

            /////2a1a. choose ally submenu:
            ///// pick one opp to replace (0-9) (keep their stats),
            ///// then go to choose opp submenu

            /////2a1b. choose opponent submenu:
            /////display everyones' current hp
            /////mark which is you next to curr hp
            /////display 'choose next opp (0-9)' at line's end
            //////2a1b1. choose opponent (0-9)

            /////2a1c. fight submenu:
            ///// display everyones' curr hp,
            ///// mark the fighters
            ///// display turn number
            ///// (1-9) continue fight for another 1-9 turns
            /////or until somebody dies, whichever's first
            /////you die or last opp dies -> go to end game menu
            /////opp dies, some opps left -> turn into him, go to choose opp submenu
            ///// 0 disengage and go back to choose opp submenu

            //////2a2. end game menu
            //////display score (roughly % of everyone's hp missing),
            //////(1 point for each fully defeated opp, max 10 score, min 0)
            //////(2 decimal places after .)
            ////// go to new line
            //////start new game (n)
            //////end program (x)

            ///2b. instructions: display all instructions:
            ////2b1. explain what each stat does
            /////attack damage done per hit
            /////current hp decreases when you're hit
            /////speed number of turns between hits
            ////2b2. explain possible actions in each submenu:
            ///// - fight: x to end current game and see your score,
            /////other actions based on combat phase
            ///// - choose ally: choose 1 opponent to turn into,
            /////you will keep their stats, you will not fight this opp
            ///// - choose opp: start a fight with chosen opponent
            ///// - fight: continue for n turns or retreat

            ///2c. exit
        }

        private static void InitializeLang(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('p', "(p)l", "Lang");
            menuActionService.AddNewAction('e', "(e)ng", "Lang");
        }

        private static void Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('n', texts.NewGame(), "Main");
            menuActionService.AddNewAction('i', texts.Instructions(), "Main");
            menuActionService.AddNewAction('x', texts.Exit(), "Main");
        }
    }
}
