using System;
using Doppelganger.App.Helpers;
using Xunit;

namespace Doppelganger.Tests.App.Helpers
{
    public class HelperMethodsTests
    {
        /*//Uncomment to write to console during tests,
         //just use output.WriteLine(...) instead of Console.WriteLine(...)
        private readonly ITestOutputHelper output;

        public HelperMethodsTests(ITestOutputHelper output)
        {
            this.output = output;
        }*/
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

        [Fact]
        public void CharDigitToInt_GivenNonAlphanumericCharacter_ShouldThrowArgumentException()
        {
            //Arrange
            char input = '-';
            bool caught = false;
            //Act
            try
            {
                HelperMethods.CharDigitToInt(input);
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
            //Act
            try
            {
                HelperMethods.CharDigitToInt(input);
            }
            catch (ArgumentException)
            {
                caught = true;
            }

            //Assert
            Assert.True(caught);
        }

        //Tests for Method Buttonize
        [Fact]
        public void Buttonize_GivenNullString_ShouldThrowArgumentException()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenEmptyString_ShouldReturnAMarkedAndButtonizedChar()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringThatHasNoGivenChar_ShouldAddMarkedCharAtTheEndAfterASpace()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharAtEnd_ShouldMarkThatChar()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharAtStart_ShouldMarkThatChar()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharInTheMiddle_ShouldMarkThatChar()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringThatHasMultipleGivenChars_ShouldMarkTheFirstOfThem()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Buttonize_GivenStringWithDifferentCasingThanGivenChar_ShouldMarkThatCharAnyway()
        {
            throw new NotImplementedException();
        }

        //Tests for Method DisplayCurrentHPs
    }

}