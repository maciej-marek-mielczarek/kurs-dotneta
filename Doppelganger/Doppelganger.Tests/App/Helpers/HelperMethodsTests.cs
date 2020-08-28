using Doppelganger.App.Helpers;
using Moq;
using Xunit;

namespace Doppelganger.Tests.App.Helpers
{
    public class HelperMethodsTests
    {
        //Tests for Method CharDigitToInt
        [Fact]
        public void CharDigitToInt_GivenZero_ShouldReturnZero()
        {
            //Arrange
            char input = '0';
            int expected = 0;
            //Act
            int result = HelperMethods.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void CharDigitToInt_GivenFive_ShouldReturnFive()
        {
            //Arrange
            char input = '5';
            int expected = 5;
            //Act
            int result = HelperMethods.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void CharDigitToInt_GivenSmallC_ShouldReturnTwelve()
        {
            //Arrange
            char input = 'c';
            int expected = 12;
            //Act
            int result = HelperMethods.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
            
        }
        [Fact]
        public void CharDigitToInt_GivenBigZ_ShouldReturn35()
        {
            //Arrange
            char input = 'Z';
            int expected = 35;
            //Act
            int result = HelperMethods.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
            
        }
        [Fact]
        public void CharDigitToInt_GivenLetters_ShouldIgnoreCase()
        {
            //Arrange
            char input1 = 'D', input2 = 'd';
            //Act
            int result1 = HelperMethods.CharDigitToInt(input1);
            int result2 = HelperMethods.CharDigitToInt(input2);
            //Assert
            Assert.True(result1 == result2);
        } 
    }
}