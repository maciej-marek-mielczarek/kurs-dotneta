using System;
using Doppelganger.App.Helpers.Concrete;
using Xunit;

namespace Doppelganger.Tests.App.Helpers.Concrete
{
    public class MiscOutputTests
    {
        /*//Uncomment to write to console during tests,
         //just use output.WriteLine(...) instead of Console.WriteLine(...)
        private readonly ITestOutputHelper output;

        public HelperMethodsTests(ITestOutputHelper output)
        {
            this.output = output;
        }*/
        

        //Tests for Method Buttonize
        [Fact]
        public void Buttonize_GivenNullString_ShouldThrowArgumentException()
        {
            //Arrange
            const string inputText = null;
            const char inputKey = 'a';
            bool caught = false;
            //Act
            try
            {
                MiscOutput.Buttonize(inputText, inputKey);
            }
            catch (ArgumentException)
            {
                caught = true;
            }
            //Assert
            Assert.True(caught);
        }

        private static void Buttonize_GenericReturnTest(string inputText, char inputKey, string expectedResult)
        {
            //Arrange
            // Setting parameter values is all the arranging needed here.
            //Act
            var returned = MiscOutput.Buttonize(inputText, inputKey);
            //Assert
            Assert.Equal(expectedResult, returned);
        }

        [Fact]
        public void Buttonize_GivenEmptyString_ShouldReturnAMarkedAndButtonizedChar()
        {
            //Delegate
            Buttonize_GenericReturnTest("", 'a', " [(a)] ");
        }

        [Fact]
        public void Buttonize_GivenStringThatHasNoGivenChar_ShouldAddMarkedCharAtTheEndAfterASpace()
        {
            //Delegate
            Buttonize_GenericReturnTest("abc", 'd', " [abc (d)] ");
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharAtEnd_ShouldMarkThatChar()
        {
            //Delegate
            Buttonize_GenericReturnTest("abc", 'c', " [ab(c)] ");
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharAtStart_ShouldMarkThatChar()
        {
            //Delegate
            Buttonize_GenericReturnTest("abc", 'a', " [(a)bc] ");
        }

        [Fact]
        public void Buttonize_GivenStringThatHasGivenCharInTheMiddle_ShouldMarkThatChar()
        {
            //Delegate
            // ReSharper disable once StringLiteralTypo
            Buttonize_GenericReturnTest("abcde", 'd', " [abc(d)e] ");
        }

        [Fact]
        public void Buttonize_GivenStringThatHasMultipleGivenChars_ShouldMarkTheFirstOfThem()
        {
            //Delegate
            // ReSharper disable once StringLiteralTypo
            Buttonize_GenericReturnTest("baaba", 'a', " [b(a)aba] ");
        }

        [Fact]
        public void Buttonize_GivenStringWithDifferentCasingThanGivenChar_ShouldMarkThatCharAnyway()
        {
            //Delegate
            Buttonize_GenericReturnTest("AbCD", 'c', " [Ab(C)D] ");
            Buttonize_GenericReturnTest("abc", 'B', " [a(b)c] ");
        }

        [Fact]
        public void Buttonize_ShouldWorkWithConstArguments()
        {
            //Arrange
            const string inputText = "abc";
            const char inputKey = 'b';
            const string expected = " [a(b)c] ";
            //Act
            var output = MiscOutput.Buttonize(inputText, inputKey);
            //Assert
            Assert.Equal(expected, output);
        }
        
        [Fact]
        public void Buttonize_ShouldNotModifyItsArguments()
        {
            //Arrange
            string inputText = "abc";
            string inputTextCopy = "abc";
            char inputKey = 'd';
            //Act
            MiscOutput.Buttonize(inputText, inputKey);
            //Assert
            Assert.Equal(inputTextCopy, inputText);
        }
    }
}