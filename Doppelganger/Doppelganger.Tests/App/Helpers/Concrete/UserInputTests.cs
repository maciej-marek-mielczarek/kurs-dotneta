using System;
using Doppelganger.App.Helpers.Abstract;
using Doppelganger.App.Helpers.Concrete;
using Xunit;

namespace Doppelganger.Tests.App.Helpers.Concrete
{
    public class UserInputTests
    {
        //Tests for Method CharDigitToInt
        [Fact]
        public void CharDigitToInt_GivenZero_ShouldReturnZero()
        {
            //Arrange
            char input = '0';
            int expected = 0;
            IUserInput userInput = new UserInput();
            //Act
            int result = userInput.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CharDigitToInt_GivenFive_ShouldReturnFive()
        {
            //Arrange
            char input = '5';
            int expected = 5;
            IUserInput userInput = new UserInput();
            //Act
            int result = userInput.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CharDigitToInt_GivenSmallC_ShouldReturnTwelve()
        {
            //Arrange
            char input = 'c';
            int expected = 12;
            IUserInput userInput = new UserInput();
            //Act
            int result = userInput.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CharDigitToInt_GivenBigZ_ShouldReturn35()
        {
            //Arrange
            char input = 'Z';
            int expected = 35;
            IUserInput userInput = new UserInput();
            //Act
            int result = userInput.CharDigitToInt(input);
            //Assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void CharDigitToInt_GivenLetters_ShouldIgnoreCase()
        {
            //Arrange
            char input1 = 'D', input2 = 'd';
            IUserInput userInput = new UserInput();
            //Act
            int result1 = userInput.CharDigitToInt(input1);
            int result2 = userInput.CharDigitToInt(input2);
            //Assert
            Assert.True(result1 == result2);
        }

        [Fact]
        public void CharDigitToInt_GivenNonAlphanumericCharacter_ShouldThrowArgumentException()
        {
            //Arrange
            char input = '-';
            bool caught = false;
            IUserInput userInput = new UserInput();
            //Act
            try
            {
                userInput.CharDigitToInt(input);
            }
            catch (ArgumentException)
            {
                caught = true;
            }

            //Assert
            Assert.True(caught);
        }

        [Fact]
        public void CharDigitToInt_GivenNonLatinLetter_ShouldThrowArgumentException()
        {
            //Arrange
            char input = 'ą';
            bool caught = false;
            IUserInput userInput = new UserInput();
            //Act
            try
            {
                userInput.CharDigitToInt(input);
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