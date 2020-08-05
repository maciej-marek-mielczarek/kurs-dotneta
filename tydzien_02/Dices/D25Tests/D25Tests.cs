using Microsoft.VisualStudio.TestTools.UnitTesting;
using D25;
using System;
using System.Collections.Generic;
using System.Text;

namespace D25.Tests
{
    [TestClass()]
    public class D25Tests
    {
        [TestMethod()]
        public void RollTest()
        {
            const int numberOfRolls = 1000000;
            D25 d25 = new D25();
            List<bool> observedFaces = new List<bool>(25);
            for(int face = 1; face <= 25; ++face)
            {
                observedFaces.Add(false);
            }
            for(int rollNumber = 1; rollNumber <= numberOfRolls; ++rollNumber)
            {
                int rollResult = d25.Roll(); 
                Assert.IsTrue(rollResult >= 1);
                Assert.IsTrue(rollResult <= 25);
                observedFaces[rollResult - 1] = true;
            }
            Assert.IsFalse(observedFaces.Contains(false));
        }
    }
}