using System;
using Xunit;

namespace Doppelganger.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 0);
            Assert.True(2 / 3 + 1 / 3 == 1);//second assert won't be checked if first assert fails
        }
    }
}
