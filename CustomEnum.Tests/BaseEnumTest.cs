using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CustomEnum.Tests
{
    [TestClass]
    public class BaseEnumTest
    {
        [TestInitialize]
        public void Init()
        {
            var t1 = Test1Enum.Test1;
            var t2 = Test2Enum.Test2;
        }

        [TestMethod]
        public void Cast_StringEnum_To_StringEnum2()
        {
            Assert.AreEqual((Test1Enum)Test2Enum.Test2.GetValue(), Test1Enum.Test2);
        }

        [TestMethod]
        public void Cast_StringEnum_From_Int()
        {
            Assert.AreEqual((Test1Enum)1, Test1Enum.Test1);
        }

        [TestMethod]
        public void Cast_StringEnum_From_String()
        {
            Assert.AreEqual((Test1Enum)"Test2", Test1Enum.Test2);
        }

        [TestMethod]
        public void Cast_Int_From_StringEnum()
        {
            Assert.AreEqual((long)Test1Enum.Test1, 1);
        }

        [TestMethod]
        public void Cast_String_From_StringEnum()
        {
            Assert.AreEqual((string)Test1Enum.Test2, "Test2");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Throws_Int_Key_Not_Found()
        {
            var t1 = (Test1Enum)123;
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Throws_String_Key_Not_Found()
        {
            var t1 = (Test1Enum)123;
        }

        [TestMethod]
        public void BaseEnum_GetKey()
        {
            Assert.AreEqual(Test1Enum.Test1.GetKey(), 1);
        }

        [TestMethod]
        public void GetHashCode_Equals()
        {
            Assert.AreEqual(Test1Enum.Test1.GetHashCode(), Test2Enum.Test1.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_NotEquals()
        {
            Assert.AreNotEqual(Test1Enum.Test1.GetHashCode(), Test2Enum.Test2.GetHashCode());
        }

        [TestMethod]
        public void Equals_True()
        {
            Assert.AreEqual(true, Test1Enum.Test1.Equals(Test1Enum.Test1));
        }

        [TestMethod]
        public void Equals_False()
        {
            Assert.AreEqual(false, Test1Enum.Test1.Equals(Test1Enum.Test2));
        }

        [TestMethod]
        public void Equals_False_Null()
        {
            Assert.AreEqual(false, Test1Enum.Test1.Equals(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Key_Null()
        {
            var t = new Test3Enum(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Value_Null()
        {
            var t = new Test3Enum(null, "");
        }

        [TestMethod]
        public void Contains_Key_True()
        {
            Assert.AreEqual(true, Test1Enum.Contains(1));
        }

        [TestMethod]
        public void Contains_Key_False()
        {
            Assert.AreEqual(false, Test1Enum.Contains(123));
        }

        [TestMethod]
        public void Contains_Value_True()
        {
            Assert.AreEqual(true, Test1Enum.Contains("Test1"));
        }

        [TestMethod]
        public void Contains_Value_False()
        {
            Assert.AreEqual(false, Test1Enum.Contains("1"));
        }
    }
}
