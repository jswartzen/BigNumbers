// Copyright 2021 John L. Swartzentruber

namespace UnitTests
{
    using BigNumbers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntegramTests
    {
        [TestMethod]
        public void CompareTwoMethods()
        {
            var testCases = new int[] { 1, 10, 11, 12, 321, 1110, 11112 };
            foreach (var i in testCases)
            {
                Assert.AreEqual(Integram.BruteForceDigitSum(i), Integram.PatternDigitSum(i), $"Comparing {i} nines");
            }
        }
    }
}
