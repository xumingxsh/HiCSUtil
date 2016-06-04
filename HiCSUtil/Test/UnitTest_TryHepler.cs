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
            string ret = TryHelper.OnTry<string>("", () =>
            {
                return null;
            });
            Assert.AreEqual(ret, "");
        }

        [TestMethod]
        public void TryHepler_Object()
        {
            string ret = TryHelper.OnTryEx<string>("", () =>
            {
                return null;
            });
            Assert.AreEqual(ret, "");
        }

        [TestMethod]
        public void TryHepler_Object2()
        {
            string ret = TryHelper.OnTryEx<string>("", () =>
            {
                return "3";
            });
            Assert.AreEqual(ret, "3");
        }

        [TestMethod]
        public void TryHepler_Double2()
        {
            double ret = TryHelper.OnTryEx<double>(-1, () =>
            {
                return null;
            });
            Assert.AreEqual(ret, -1);
        }

        [TestMethod]
        public void TryHepler_byte2()
        {
            byte ret = TryHelper.OnTryEx<byte>(0, () =>
            {
                return null;
            });
            Assert.AreEqual(ret, 0);
        }
    }
}
