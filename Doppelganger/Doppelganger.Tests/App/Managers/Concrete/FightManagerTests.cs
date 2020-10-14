using System;
using System.Linq;
using Doppelganger.App.Helpers.Abstract;
using Doppelganger.App.Helpers.Concrete;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Managers.Concrete;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Settings;
using Moq;
using Xunit;

namespace Doppelganger.Tests.App.Managers.Concrete
{
    public class FightManagerTests
    {
        //Tests for method CalculateScore
        [Fact]
        public void CalculateScore_GivenZeroCurrentHPs_ShouldReturn100()
        {
            //Arrange
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            foreach (int id in Enumerable.Range(0,DisplaySettings.NumberOfOpps))
            {
                mock.Setup(m => m.GetCreatureCurrentHPById(id)).Returns(0);
                mock.Setup(m => m.GetCreatureMaxHPById(id)).Returns(10);
            }
            IFightManager fightManager = new FightManager(new TextService(Language.English), mock.Object , new UserInput());
            int expectedScore = 100;
            //Act
            int score = fightManager.CalculateScore();
            //Assert
            Assert.Equal(expectedScore, score);
        }
        
        [Fact]
        public void CalculateScore_GivenLessThan10PercentDamageOnEveryone_ShouldReturnZero()
        {
            //Arrange
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            foreach (int id in Enumerable.Range(0,DisplaySettings.NumberOfOpps))
            {
                mock.Setup(m => m.GetCreatureCurrentHPById(id)).Returns(90);
                mock.Setup(m => m.GetCreatureMaxHPById(id)).Returns(99);
            }
            IFightManager fightManager = new FightManager(new TextService(Language.English), mock.Object , new UserInput());
            int expectedScore = 0;
            //Act
            int score = fightManager.CalculateScore();
            //Assert
            Assert.Equal(expectedScore, score);
        }
        
        [Fact]
        public void CalculateScore_GivenFullHPs_ShouldReturnZero()
        {
            //Arrange
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            foreach (int id in Enumerable.Range(0,DisplaySettings.NumberOfOpps))
            {
                mock.Setup(m => m.GetCreatureCurrentHPById(id)).Returns(67);
                mock.Setup(m => m.GetCreatureMaxHPById(id)).Returns(67);
            }
            IFightManager fightManager = new FightManager(new TextService(Language.English), mock.Object , new UserInput());
            int expectedScore = 0;
            //Act
            int score = fightManager.CalculateScore();
            //Assert
            Assert.Equal(expectedScore, score);
        }
        
        [Fact]
        public void CalculateScore_Given20PercentDamageOnOneCreature_ShouldReturn2()
        {
            //Arrange
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(m => m.GetCreatureCurrentHPById(0)).Returns(40);
            mock.Setup(m => m.GetCreatureMaxHPById(0)).Returns(50);
            foreach (int id in Enumerable.Range(1,DisplaySettings.NumberOfOpps))
            {
                mock.Setup(m => m.GetCreatureCurrentHPById(id)).Returns(99);
                mock.Setup(m => m.GetCreatureMaxHPById(id)).Returns(99);
            }
            IFightManager fightManager = new FightManager(new TextService(Language.English), mock.Object , new UserInput());
            int expectedScore = 2;
            //Act
            int score = fightManager.CalculateScore();
            //Assert
            Assert.Equal(expectedScore, score);
        }

        [Fact]
        public void CalculateScore_GivenOneDeadCreature_ShouldReturn10()
        {
            //Arrange
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(m => m.GetCreatureCurrentHPById(0)).Returns(0);
            mock.Setup(m => m.GetCreatureMaxHPById(0)).Returns(15);
            foreach (int id in Enumerable.Range(1,DisplaySettings.NumberOfOpps))
            {
                mock.Setup(m => m.GetCreatureCurrentHPById(id)).Returns(99);
                mock.Setup(m => m.GetCreatureMaxHPById(id)).Returns(99);
            }
            IFightManager fightManager = new FightManager(new TextService(Language.English), mock.Object , new UserInput());
            int expectedScore = 10;
            //Act
            int score = fightManager.CalculateScore();
            //Assert
            Assert.Equal(expectedScore, score);
        }

        //Tests for method PickAlly
        [Fact]
        public void PickAlly_GivenX_ShouldReturnFalse()
        {
            //Arrange
            Mock<IUserInput> mock = new Mock<IUserInput>();
            const string allowedChars = "x0123456789";
            mock.Setup(m => m.GetChar(allowedChars)).Returns('x');
            IFightManager fightManager = new FightManager(new TextService(Language.Polish), new CreatureService(), mock.Object);
            fightManager.Initialize();
            const bool expected = false;
            //Act
            bool returned = fightManager.PickAlly();
            //Assert
            Assert.Equal(expected, returned);
        }

        [Fact]
        public void PickAlly_GivenX_ShouldNotCallCreatureServiceMethodMakeGivenCreatureFriendly()
        {
            //Arrange
            Mock<IUserInput> mock = new Mock<IUserInput>();
            const string allowedChars = "x0123456789";
            mock.Setup(m => m.GetChar(allowedChars)).Returns('x');
            Mock<ICreatureService> mockCrS = new Mock<ICreatureService>();
            IFightManager fightManager =
                new FightManager(new TextService(Language.Polish), mockCrS.Object, mock.Object);
            fightManager.Initialize();
            //Act
            fightManager.PickAlly();
            //Assert
            foreach (int id in Enumerable.Range(0, DisplaySettings.NumberOfOpps))
            {
                mockCrS.Verify(m => m.MakeGivenCreatureFriendly(id), Times.Never);
            }
        }

        [Fact]
        public void PickAlly_GivenNumber_ShouldPassThatNumberToCreatureServiceMethodMakeGivenCreatureFriendly()
        {
            Mock<IUserInput> mock = new Mock<IUserInput>();
            const string allowedChars = "x0123456789";
            const int chosenId = 3;
            mock.Setup(m => m.GetChar(allowedChars)).Returns('3');
            mock.Setup(m => m.CharDigitToInt('3')).Returns(chosenId);
            Mock<ICreatureService> mockCrS = new Mock<ICreatureService>();
            IFightManager fightManager =
                new FightManager(new TextService(Language.Polish), mockCrS.Object, mock.Object);
            fightManager.Initialize();
            //Act
            fightManager.PickAlly();
            //Assert
            mockCrS.Verify(m=>m.MakeGivenCreatureFriendly(chosenId));
        }

        [Fact]
        public void PickAlly_GivenNumber_ShouldReturnTrue()
        {
            //Arrange
            Mock<IUserInput> mock = new Mock<IUserInput>();
            const string allowedChars = "x0123456789";
            mock.Setup(m => m.GetChar(allowedChars)).Returns('0');
            mock.Setup(m => m.CharDigitToInt('0')).Returns(0);
            IFightManager fightManager = new FightManager(new TextService(Language.Polish), new CreatureService(), mock.Object);
            fightManager.Initialize();
            const bool expected = true;
            //Act
            bool returned = fightManager.PickAlly();
            //Assert
            Assert.Equal(expected, returned);
        }

        //Tests for method PickOpp
        [Fact]
        public void PickOpp_GivenX_ShouldReturnMinusOne()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }
        
        [Fact]
        public void PickOpp_GivenValidNumber_ShouldReturnIt()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        [Fact]
        public void PickOpp_GivenInvalidNumber_ShouldReturnMinusOne()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        //Tests for method FightSubMenu
        [Fact]
        public void FightSubMenu_Given_Should()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }
    }
}