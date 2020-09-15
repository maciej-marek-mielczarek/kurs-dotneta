using System;
using Doppelganger.App.Helpers.Abstract;
using Doppelganger.App.Helpers.Concrete;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Managers.Concrete;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger
{
    internal static class Program
    {
        private static void Main()
        {
            //Display title
            Console.Write(TitleText.Text);
            //Create Menu Action Service and partly initialize it (further initialization requires language choice)
            IMenuActionService menuActionService = new MenuActionService();
            ICreatureService creatureService = new CreatureService();
            //Create a UserInput, then give it to all the managers
            IUserInput userInput = new UserInput();
            //Create Language Manager and ask it to pick a language
            ILanguageManager languageManager = new LanguageManager(menuActionService, userInput);
            Language languageChoice = languageManager.ChooseLanguage();
            //Use the language choice to initialize Text and Menu Action Services
            ITextService textService = new TextService(languageChoice);
            menuActionService.Initialize(textService);
            //Write a one-time welcome message in the chosen language
            Console.Write(textService.Welcome());
            //Use services to initialize Game Manager
            IGameManager gameManager = new GameManager(textService, menuActionService, creatureService, userInput);
            //Start game
            gameManager.MainMenu();
        }
    }
}
