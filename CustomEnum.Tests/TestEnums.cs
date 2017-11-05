using CustomEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnum.Tests
{
    internal sealed class Test1Enum : BaseEnum<long, string, Test1Enum>
    {
        private Test1Enum(long key, string value) : base(key, value)
        { }

        public static Test1Enum Test1 = new Test1Enum(1, "Test1");
        public static Test1Enum Test2 = new Test1Enum(2, "Test2");

        public static implicit operator Test1Enum(long key)
        {
            return From(key);
        }

        public static explicit operator Test1Enum(string key)
        {
            return From(key);
        }

        public static implicit operator long(Test1Enum enm)
        {
            return enm.GetKey();
        }

        public static explicit operator string(Test1Enum enm)
        {
            return enm.GetValue();
        }
    }

    internal sealed class Test2Enum : BaseEnum<int, string, Test2Enum>
    {
        private Test2Enum(int key, string value) : base(key, value)
        { }

        public static Test2Enum Test1 = new Test2Enum(1, "Test1");
        public static Test2Enum Test2 = new Test2Enum(2, "Test2");

        public static implicit operator Test2Enum(int key) => From(key);
        public static explicit operator Test2Enum(string key) => From(key);
        public static implicit operator int(Test2Enum enm) => enm.GetKey();
        public static explicit operator string(Test2Enum enm) => enm.GetValue();
    }

    internal class Test3Enum : BaseEnum<string, string, Test3Enum>
    {
        public Test3Enum(string key, string value) : base(key, value)
        { }
    }

    internal sealed class TestFlagEnum : FlagEnum<string, TestFlagEnum>
    {
        public TestFlagEnum() : base()
        { }
       
        private TestFlagEnum(int key, string value) : base(key, value)
        { }

        public static TestFlagEnum None = new TestFlagEnum(0, "None");
        public static TestFlagEnum Flag1 = new TestFlagEnum(1 << 0, "FLag1");
        public static TestFlagEnum Flag2 = new TestFlagEnum(1 << 1, "FLag2");
        public static TestFlagEnum Flag3 = new TestFlagEnum(1 << 2, "FLag3");
    }
}
