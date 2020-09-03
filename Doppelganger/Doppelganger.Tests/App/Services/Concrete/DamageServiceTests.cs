using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Moq;
using Xunit;

namespace Doppelganger.Tests.App.Services.Concrete
{
    public class DamageServiceTests
    {
        //Tests for method DamageDealtInCombatTurn
        [Fact]
        public void DamageDealtInCombatTurn_GivenCreatureTurnNumberDivisibleBySpeed_ShouldReturnCreaturesAttack()
        {
            //Arrange
            const byte allysAttack = 13;
            const int allysId = 2;
            const int turnNumber = 54;
            const byte speed = 6;
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(c => c.GetCreatureSpeedById(allysId)).Returns(speed);
            mock.Setup(c => c.GetCreatureAttackById(allysId)).Returns(allysAttack);
            IDamageService damageService = new DamageService();
            //Act
            var damage = damageService.DamageDealtInCombatTurn(allysId, turnNumber, mock.Object);
            //Assert
            Assert.Equal(allysAttack, damage);
        }
        
        [Fact]
        public void DamageDealtInCombatTurn_GivenCreatureTurnNumberNotDivisibleBySpeed_ShouldReturnZero()
        {
            //Arrange
            const byte allysAttack = 13;
            const int allysId = 2;
            const int turnNumber = 53;
            const byte speed = 6;
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(c => c.GetCreatureSpeedById(allysId)).Returns(speed);
            mock.Setup(c => c.GetCreatureAttackById(allysId)).Returns(allysAttack);
            IDamageService damageService = new DamageService();
            //Act
            var damage = damageService.DamageDealtInCombatTurn(allysId, turnNumber, mock.Object);
            //Assert
            Assert.Equal(0, damage);
        }

        //Tests for method DamageTakenInCombatTurn
        [Fact]
        public void DamageTakenInCombatTurn_GivenTurnNumberDivisibleBySpeed_ShouldReturnCreaturesAttack()
        {
            //Arrange
            const byte oppsAttack = 13;
            const int oppsId = 2;
            const int turnNumber = 54;
            const byte speed = 6;
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(c => c.GetCreatureSpeedById(oppsId)).Returns(speed);
            mock.Setup(c => c.GetCreatureAttackById(oppsId)).Returns(oppsAttack);
            mock.Setup(c => c.IsCreatureFriendly(oppsId)).Returns(false);
            IDamageService damageService = new DamageService();
            //Act
            var damage = damageService.DamageTakenInCombatTurn(oppsId, turnNumber, mock.Object);
            //Assert
            Assert.Equal(oppsAttack, damage);
        }
        
        [Fact]
        public void DamageTakenInCombatTurn_GivenTurnNumberNotDivisibleBySpeed_ShouldReturnZero()
        {
            //Arrange
            const byte oppsAttack = 13;
            const int oppsId = 2;
            const int turnNumber = 53;
            const byte speed = 6;
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(c => c.GetCreatureSpeedById(oppsId)).Returns(speed);
            mock.Setup(c => c.GetCreatureAttackById(oppsId)).Returns(oppsAttack);
            mock.Setup(c => c.IsCreatureFriendly(oppsId)).Returns(false);
            IDamageService damageService = new DamageService();
            //Act
            var damage = damageService.DamageTakenInCombatTurn(oppsId, turnNumber, mock.Object);
            //Assert
            Assert.Equal(0, damage);
        }
        
        [Fact]
        public void DamageTakenInCombatTurn_WhenCreatureWithGivenIdIsFriendly_ShouldReturnZero()
        {
            //Arrange
            const byte oppsAttack = 13;
            const int oppsId = 2;
            const int turnNumber = 54;
            const byte speed = 6;
            Mock<ICreatureService> mock = new Mock<ICreatureService>();
            mock.Setup(c => c.GetCreatureSpeedById(oppsId)).Returns(speed);
            mock.Setup(c => c.GetCreatureAttackById(oppsId)).Returns(oppsAttack);
            mock.Setup(c => c.IsCreatureFriendly(oppsId)).Returns(true);
            IDamageService damageService = new DamageService();
            //Act
            var damage = damageService.DamageTakenInCombatTurn(oppsId, turnNumber, mock.Object);
            //Assert
            Assert.Equal(0, damage);
        }
    }
}