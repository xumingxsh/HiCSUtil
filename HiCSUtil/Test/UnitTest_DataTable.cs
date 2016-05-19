using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiCSUtil.Test
{
    [TestClass]
    public class UnitTest_DataTable
    {
        /// <summary>
        /// 正常测试，设置属性成功，并获得期望结果
        /// </summary>
        [TestMethod]
        public void DataTable_Default_Int()
        {
            int val = Get<int>();
            Assert.IsTrue(val == -1);
        }

        private T Get<T>()
        {
            if (typeof(T).Equals(typeof(int)))
            {
                object val = -1;
                return (T)val;
            }
            return GetDefault<T>(); ;
        }

        private int GetDefault()
        {
           return -1;
        }

        private T GetDefault<T>()
        {
            return default(T);
        }
    }
}
