using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomEnum.Tests
{
    [TestClass]
    public class FlagEnumTests
    {
        [TestMethod]
        public void HasFlag_True()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreEqual(true, flagged.HasFlag(TestFlagEnum.Flag1) && flagged.HasFlag(TestFlagEnum.Flag3));
        }

        [TestMethod]
        public void HasFlag_False ()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreEqual(false, flagged.HasFlag(TestFlagEnum.Flag2));
        }

        [TestMethod]
        public void Operator_AND_Equals()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreEqual(flagged, flagged & (TestFlagEnum.Flag1 | TestFlagEnum.Flag3));
        }

        [TestMethod]
        public void Operator_AND_NotEquals()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreNotEqual((int)flagged, flagged & (TestFlagEnum.Flag1 | TestFlagEnum.Flag2));
        }

        [TestMethod]
        public void HasFlags_True()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreEqual(true, flagged.HasFlags(TestFlagEnum.Flag1, TestFlagEnum.Flag3));
        }

        [TestMethod]
        public void HasFlags_False()
        {
            TestFlagEnum flagged = TestFlagEnum.Flag1 | TestFlagEnum.Flag3;
            Assert.AreEqual(false, flagged.HasFlags(TestFlagEnum.Flag1, TestFlagEnum.Flag2));
        }
    }
}
