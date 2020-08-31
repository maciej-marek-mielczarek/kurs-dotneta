using System;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Entity.Settings;
using Xunit;

namespace Doppelganger.Tests.App.Services.Concrete
{
    public class CreatureServiceTests
    {
        //Tests for method GenerateNewCrts
        [Fact]
        public void GenerateNewCrts_ShouldMakeEveryoneHostile()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            //Act
            creatureService.GenerateNewCrts();
            //Assert
            for (int id = 0; id < DisplaySettings.NumberOfOpps; id++)
            {
                Assert.False(creatureService.IsCreatureFriendly(id));
            }
        }
        
        [Fact]
        public void GenerateNewCrts_ShouldNotGenerateIdenticalStatsEveryTime()
        {
            //Arrange
            CreatureService creatureService1 = new CreatureService();
            CreatureService creatureService2 = new CreatureService();
            bool statsDiffer = false;
            //Act
            creatureService1.GenerateNewCrts();
            creatureService2.GenerateNewCrts();
            //Assert
            for (int id = 0; id < DisplaySettings.NumberOfOpps; id++)
            {
                if (creatureService1.GetCreatureAttackById(id) != creatureService2.GetCreatureAttackById(id)||creatureService1.GetCreatureSpeedById(id) != creatureService2.GetCreatureSpeedById(id)|| creatureService1.GetCreatureMaxHPById(id) !=creatureService2.GetCreatureMaxHPById(id))
                {
                    statsDiffer = true;
                    break;
                }
            }
            Assert.True(statsDiffer);
        }

        [Fact]
        public void GenerateNewCrts_ShouldGenerateCreaturesAtFullHealth()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            //Act
            creatureService.GenerateNewCrts();
            //Assert
            for (int id = 0; id < DisplaySettings.NumberOfOpps; id++)
            {
                Assert.Equal(creatureService.GetCreatureMaxHPById(id), creatureService.GetCreatureCurrentHPById(id));
            }
        }
        
        //Tests for method MakeGivenCreatureFriendly
        [Fact]
        public void MakeGivenCreatureFriendly_GivenCorrectId_ShouldNotChangeCreatureStats()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            int id = 5;
            var oldMaxHP = creatureService.GetCreatureMaxHPById(id);
            var oldCurrHP = creatureService.GetCreatureCurrentHPById(id);
            var oldSpeed = creatureService.GetCreatureSpeedById(id);
            var oldAttack = creatureService.GetCreatureAttackById(id);
            //Act
            creatureService.MakeGivenCreatureFriendly(id);
            //Assert
            Assert.Equal(oldAttack, creatureService.GetCreatureAttackById(id));
            Assert.Equal(oldSpeed, creatureService.GetCreatureSpeedById(id));
            Assert.Equal(oldCurrHP, creatureService.GetCreatureCurrentHPById(id));
            Assert.Equal(oldMaxHP, creatureService.GetCreatureMaxHPById(id));
        }
        
        [Fact]
        public void MakeGivenCreatureFriendly_GivenNegativeId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            bool caught = false;
            //Act
            try
            {
                creatureService.MakeGivenCreatureFriendly(-1);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
        
        [Fact]
        public void MakeGivenCreatureFriendly_GivenTooLargeId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            bool caught = false;
            //Act
            try
            {
                creatureService.MakeGivenCreatureFriendly(100);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
        
        [Fact]
        public void MakeGivenCreatureFriendly_GivenCorrectId_ShouldChangeGivenCreatureToAlly()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int id = 5;
            // check assumption:
            Assert.False(creatureService.IsCreatureFriendly(id));
            //Act
            creatureService.MakeGivenCreatureFriendly(id);
            //Assert
            Assert.True(creatureService.IsCreatureFriendly(id));
        }
        
        [Fact]
        public void MakeGivenCreatureFriendly_GivenCorrectId_ShouldNotChangeOtherCreaturesToAlly()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int id = 0;
            const int otherId = 1;
            // check assumption:
            Assert.False(creatureService.IsCreatureFriendly(otherId));
            //Act
            creatureService.MakeGivenCreatureFriendly(id);
            //Assert
            Assert.False(creatureService.IsCreatureFriendly(otherId));
        }
        
        //Tests for method RegisterHit
        [Fact]
        public void RegisterHit_GivenLowDamage_ShouldDecreaseTargetsCurrentHPByGivenDamage()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const byte damage = 2;
            const int targetId = 7;
            byte expected = (byte)(creatureService.GetCreatureCurrentHPById(targetId) - damage);
            //Act
            creatureService.RegisterHit(damage, targetId);
            //Assert
            Assert.Equal(expected, creatureService.GetCreatureCurrentHPById(targetId));
        }
        
        [Fact]
        public void RegisterHit_GivenOverkillDamage_ShouldDecreaseTargetsHPToZero()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const byte damage = byte.MaxValue;
            const int targetId = 9;
            //Act
            creatureService.RegisterHit(damage, targetId);
            //Assert
            Assert.Equal(0, creatureService.GetCreatureCurrentHPById(targetId));
        }
        
        [Fact]
        public void RegisterHit_GivenNegativeId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            const int targetId = -1;
            const byte damage = 3;
            creatureService.GenerateNewCrts();
            bool caught = false;
            //Act
            try
            {
                creatureService.RegisterHit(damage, targetId);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
        
        //Tests for method SwitchBodiesWith
        [Fact]
        public void SwitchBodiesWith_GivenCorrectIdDifferentFromPreviousAllysId_ShouldSwitchAllegiancesOfOldAllyAndGivenOpponent()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 1;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 0;
            //Act
            creatureService.SwitchBodiesWith(newAllysId);
            //Assert
            Assert.True(creatureService.IsCreatureFriendly(newAllysId));
            Assert.False(creatureService.IsCreatureFriendly(oldAllysId));
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenCorrectIdDifferentFromPreviousAllysId_ShouldPreserveAllysHPLeftPercentageRoundedUp()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 1;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 0;
            byte oldAllysMaxHP = creatureService.GetCreatureMaxHPById(oldAllysId);
            creatureService.RegisterHit((byte)(oldAllysMaxHP/3), oldAllysId);
            byte oldAllysHP = creatureService.GetCreatureCurrentHPById(oldAllysId);
            //Act
            creatureService.SwitchBodiesWith(newAllysId);
            //Assert
            byte newAllysHP = creatureService.GetCreatureCurrentHPById(newAllysId);
            byte newAllysMaxHP = creatureService.GetCreatureMaxHPById(newAllysId);
            // oldHP/oldMax + epsilon = newHP/newMax, 0 <= epsilon < 1/newMax (round up, but by no more than 1 point)
            // multiply both sides by oldMax*newMax to get: 
            // epsilon*oldMax*newMax = newHP*oldMax - oldHP*newMax
            // so that thing on the right is between 0 (inclusive) and oldMax (exclusive) 
            // Assert.InRange(5, 5, 7) and Assert.InRange(7, 5, 7) both pass, so that's an inclusive range.
            Assert.InRange(newAllysHP * oldAllysMaxHP - oldAllysHP * newAllysMaxHP, 0, oldAllysMaxHP - 1);
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenCorrectIdDifferentFromPreviousAllysId_ShouldPreserveOpponentsHPLeftPercentageRoundedUp()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 9;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 2;
            byte oldOppsMaxHP = creatureService.GetCreatureMaxHPById(newAllysId);
            creatureService.RegisterHit((byte)(oldOppsMaxHP/3), newAllysId);
            byte oldOppsHP = creatureService.GetCreatureCurrentHPById(newAllysId);
            //Act
            creatureService.SwitchBodiesWith(newAllysId);
            //Assert
            byte newOppsHP = creatureService.GetCreatureCurrentHPById(oldAllysId);
            byte newOppsMaxHP = creatureService.GetCreatureMaxHPById(oldAllysId);
            // oldHP/oldMax + epsilon = newHP/newMax, 0 <= epsilon < 1/newMax (round up, but by no more than 1 point)
            // multiply both sides by oldMax*newMax to get: 
            // epsilon*oldMax*newMax = newHP*oldMax - oldHP*newMax
            // so that thing on the right is between 0 (inclusive) and oldMax (exclusive) 
            // Assert.InRange(5, 5, 7) and Assert.InRange(7, 5, 7) both pass, so that's an inclusive range.
            Assert.InRange(newOppsHP * oldOppsMaxHP - oldOppsHP * newOppsMaxHP, 0, oldOppsMaxHP - 1);
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenCorrectIdDifferentFromPreviousAllysId_ShouldPreserveBothCreaturesOtherStats()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 2;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 7;
            byte oldAllysPrevSpeed = creatureService.GetCreatureSpeedById(oldAllysId);
            byte oldAllysPrevAttack = creatureService.GetCreatureAttackById(oldAllysId);
            byte newAllysPrevSpeed = creatureService.GetCreatureSpeedById(newAllysId);
            byte newAllysPrevAttack = creatureService.GetCreatureAttackById(newAllysId);
            //Act
            creatureService.SwitchBodiesWith(newAllysId);
            //Assert
            Assert.Equal(oldAllysPrevSpeed, creatureService.GetCreatureSpeedById(oldAllysId));
            Assert.Equal(oldAllysPrevAttack, creatureService.GetCreatureAttackById(oldAllysId));
            Assert.Equal(newAllysPrevSpeed, creatureService.GetCreatureSpeedById(newAllysId));
            Assert.Equal(newAllysPrevAttack, creatureService.GetCreatureAttackById(newAllysId));
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenNegativeId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 1;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = -3;
            bool caught = false;
            //Act
            try
            {
                creatureService.SwitchBodiesWith(newAllysId);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenTooHighId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 1;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 100;
            bool caught = false;
            //Act
            try
            {
                creatureService.SwitchBodiesWith(newAllysId);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
        
        [Fact]
        public void SwitchBodiesWith_GivenCurrentAllysId_ShouldThrowArgumentException()
        {
            //Arrange
            CreatureService creatureService = new CreatureService();
            creatureService.GenerateNewCrts();
            const int oldAllysId = 1;
            creatureService.MakeGivenCreatureFriendly(oldAllysId);
            const int newAllysId = 1;
            bool caught = false;
            //Act
            try
            {
                creatureService.SwitchBodiesWith(newAllysId);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }
    }
}