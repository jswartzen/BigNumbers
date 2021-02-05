// Copyright 2021 John L. Swartzentruber

namespace UnitTests
{
    using BigNumbers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BigNumberTests
    {
        [TestMethod]
        public void TestConstructors()
        {
            var b = new BigNumber();
            Assert.AreEqual(b.ToString().Length, 0);

            b = new BigNumber("1234");
            Assert.AreEqual("1234", b.ToString());

            b = new BigNumber("12a345");
            Assert.AreEqual("12345", b.ToString());
        }

        [TestMethod]
        public void TestAddition()
        {
            // Both empty
            var lhs = new BigNumber();
            var rhs = new BigNumber();
            var result = lhs + rhs;
            Assert.AreEqual(result.ToString().Length, 0);

            // Left empty
            rhs = new BigNumber("991234599");
            result = lhs + rhs;
            Assert.AreEqual(result.ToString(), "991234599");

            // right empty
            lhs = new BigNumber("987659");
            rhs = new BigNumber();
            result = lhs + rhs;
            Assert.AreEqual(result.ToString(), "987659");

            // Left longer
            lhs = new BigNumber("12345");
            rhs = new BigNumber("234");
            result = lhs + rhs;
            Assert.AreEqual(result.ToString(), "12579");

            // right longer
            result = rhs + lhs; // Switched order
            Assert.AreEqual(result.ToString(), "12579");

            // mixed carries
            long l = 923456789;
            long r = 23456789012;
            lhs = new BigNumber(l.ToString());
            rhs = new BigNumber(r.ToString());
            result = lhs + rhs;
            Assert.AreEqual(result.ToString(), (l + r).ToString());

            // long carries
            l = 9999999999;
            r = 999999999999999;
            lhs = new BigNumber(l.ToString());
            rhs = new BigNumber(r.ToString());
            result = lhs + rhs;
            Assert.AreEqual(result.ToString(), (l + r).ToString());
        }

        [TestMethod]
        public void PrefixTest()
        {
            var n = new BigNumber();
            n.Prefix(4);
            Assert.AreEqual("4", n.ToString());
            n.Prefix(9);
            Assert.AreEqual("94", n.ToString());
            n.Prefix(19);
            Assert.AreEqual("94", n.ToString());
            n.Prefix(-1);
            Assert.AreEqual("94", n.ToString());
        }

        [TestMethod]
        public void SumDigitsTest()
        {
            var n = new BigNumber();
            Assert.AreEqual(0, n.SumDigits());
            n.Prefix(9);
            Assert.AreEqual(9, n.SumDigits());
            n.Prefix(9);
            Assert.AreEqual(18, n.SumDigits());
            n.Prefix(2);
            Assert.AreEqual(20, n.SumDigits());
        }
    }
}
