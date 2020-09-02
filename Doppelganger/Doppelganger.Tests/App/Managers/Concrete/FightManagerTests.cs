using System;
using System.Linq;
using System.Reflection;
using Doppelganger.App.Managers.Concrete;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Common;
using Xunit;

namespace Doppelganger.Tests.App.Managers.Concrete
{
    public class FightManagerTests
    {
        //Tests for method FightTurnSimulation
        [Fact]
        public void FightTurnSimulation_Given_Should()
        {
            //Arrange
            ITextService textService = new TextService(Language.English);
            ICreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            //FightManager fightManager = new FightManager(textService, creatureService);
            Type type = typeof(FightManager);
            var fightManager = Activator.CreateInstance(type, textService, creatureService);
            MethodInfo method = type
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(m => m.Name == "FightTurnSimulation" && m.IsPrivate);
            int oppsId = 0, allysId = 3, turnNumber = 1;
            //Act
            method.Invoke(fightManager, new Object[]
            {
                oppsId, turnNumber, allysId
            });
            //Assert
        }
    }
}