using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUtil;

namespace HiCSUtil.Test
{
    [TestClass]
    public class UnitTest_TryHepler
    {
        [TestMethod]
        public void TryHepler_String()
        {
            string ret = TryHelper.OnTry<string>(() =>
            {
                return null;
            });
            Assert.AreEqual(ret, "");
        }
    }
}
