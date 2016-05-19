using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiCSUtil.Test
{
    [TestClass]
    public sealed class UnitTest_TypeHelper
    {
        enum TypeEnum
        {
            X,
            Y
        }
        [TestMethod]
        public void TypeHelper_IsSubclassOf_ValueType()
        {
            Assert.IsTrue(typeof(int).IsSubclassOf(typeof(ValueType)));
            Assert.IsFalse(typeof(String).IsSubclassOf(typeof(ValueType)));
            Assert.IsFalse(typeof(Type).IsSubclassOf(typeof(ValueType)));
            Assert.IsTrue(typeof(DateTime).IsSubclassOf(typeof(ValueType)));
            Assert.IsTrue(typeof(TypeEnum).IsSubclassOf(typeof(ValueType)));
            Assert.IsTrue(typeof(char).IsSubclassOf(typeof(ValueType)));
        }
    }
}
