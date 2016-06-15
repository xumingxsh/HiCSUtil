using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUtil;

namespace HiCSUtil.Test
{
    [TestClass]
    public class UnitTest_ReadIni
    {
        string file = "../../../test.ini";
        public UnitTest_ReadIni()
        {

        }

        [TestMethod]
        public void ReadIni_All()
        {
            ReadIni read = new ReadIni();
            bool ret = read.Init(file);
            Assert.IsTrue(ret);
            ret = read.Init("test.ini");
            Assert.IsTrue(!ret);

            string name = read.ReadString("db", "name");
            Assert.AreEqual(name, "test"); 
            name = read.ReadString("db", "name2");
            Assert.AreEqual(name, "");

            name = read.ReadString("db", "name2", "--");
            Assert.AreEqual(name, "--"); 
            
            name = read.ReadString("db2", "name");
            Assert.AreEqual(name, "");

            name = read.ReadString("db", "sex");
            Assert.AreEqual(name, "");

            int val = read.ReadInt("db", "age");
            Assert.AreEqual(val, 5); 
            val = read.ReadInt("db", "age2");
            Assert.AreEqual(val, -1);
            val = read.ReadInt("db", "age2", 6000);
            Assert.AreEqual(val, 6000);
            val = read.ReadInt("db", "sex", 6000);
            Assert.AreEqual(val, 6000);
        }
    }
}
