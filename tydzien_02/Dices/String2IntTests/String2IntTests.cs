using Microsoft.VisualStudio.TestTools.UnitTesting;
using String2Int;
using System;
using System.Collections.Generic;
using System.Text;

namespace String2Int.Tests
{
    public class String2IntTests
    {
        [TestMethod()]
        public void TransformTest()
        {
            string[] questions = { "0", "1", "5", "100", "999", "1234567890" };
            int[] answers = {0, 1, 5, 100, 999, 1234567890 };
            for(int testNumber = 1; testNumber <= answers.Length; ++testNumber)
            {
                Assert.Equals(String2Int.Transform(questions[testNumber]), answers[testNumber]);
            }
        }
    }
}