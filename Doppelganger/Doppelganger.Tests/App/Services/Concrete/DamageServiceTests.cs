using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Moq;
using Xunit;

namespace Doppelganger.Tests.App.Services.Concrete
{
    public class DamageServiceTests
    {
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
        public void DamageTakenInCombatTurn_GivenTurnNumberDivisibleBySpeed_ShouldReturnCreaturesAttack()
        {
            //Arrange
            //Act
            //Assert
        }
        
        [Fact]
        public void DamageTakenInCombatTurn_WhenCreatureWithGivenIdIsFriendly_ShouldReturnZero()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}