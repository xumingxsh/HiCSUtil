﻿using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUtil;

namespace HiCSUtil.Test
{
    [TestClass]
    public class UnitTestCBO
    {
        class CCBOTest
        {
            public string Str { get; set; }
            public DateTime DT_val { get; set; }
            public DateTime? DTNull_val { get; set; }
            public Int32 Int32_val { get; set; }
            public Int32? Int32Null_val { get; set; }
            public Int16 Int16_val { get; set; }
            public Int64 Int64_val { get; set; }
            public UInt32 UInt32_val { get; set; }
            public UInt16 UInt16_val { get; set; }
            public UInt64 UInt64_val { get; set; }
            public double Double_val { get; set; }
            public decimal Decimal_val { get; set; }
            public float Float_val { get; set; }
            public string NotContains { get; set; }
        }

        /// <summary>
        /// 正常测试，设置属性成功，并获得期望结果
        /// </summary>
        [TestMethod]
        public void CBOTest_FillObject_Normal()
        {
            CCBOTest obj = new CCBOTest();
            DataRow dr = GetDataRow();
            SetData(dr);
            FillDR(obj, dr);
            AssertObj(obj);
        }
        /// <summary>
        /// DataRow中无数据，设置属性成功，并获得期望结果
        /// </summary>
        [TestMethod]
        public void CBOTest_TestMethod_FillObject_DataRowNoData()
        {
            DataRow dr = GetDataRow();
            CCBOTest obj = new CCBOTest();
            FillDR(obj, dr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CBOTest_TestMethod_FillObject_Exception()
        {
            DataRow dr = GetDataRow();
            CCBOTest obj = new CCBOTest();
            FillDR(obj, dr);
            Assert.IsTrue(true);

            SetData(dr);

            dr["DT_val"] = "2015-02-34";
            try
            {
                FillDR(obj, dr);
                Assert.IsFalse(true);
            }
            catch(Exception ex)
            {
                ex.ToString();
                Assert.IsTrue(true);
            }
            dr["DT_val"] = "2015-02-03";
            FillDR(obj, dr);
            Assert.IsTrue(true);

            dr["UInt32_val"] = -5;
            try
            {
                FillDR(obj, dr);
                Assert.IsFalse(true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                Assert.IsTrue(true);
            }
            dr["UInt32_val"] = "abc";
            try
            {
                FillDR(obj, dr);
                Assert.IsFalse(true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        public void CBOTest_TestMethod_FillObject_Delegate()
        {
            CCBOTest obj = new CCBOTest();
            DataRow dr = GetDataRow();
            SetData(dr);
            CBO.FillObject(obj, (ref object objVal, string name) =>
            {
                if (!dr.Table.Columns.Contains(name))
                {
                    return false;
                }
                objVal = dr[name];
                return true;
            });
            AssertObj(obj);
        }

        [TestMethod]
        public void CBOTest_TestMethod_FillObject_Delegate2()
        {
            CCBOTest obj = new CCBOTest();
            DataRow dr = GetDataRow();
            SetData(dr);
            CBO.FillObject(obj, (string name) =>
            {
                if (!dr.Table.Columns.Contains(name))
                {
                    return null;
                }
                return dr[name];
            });
            AssertObj(obj);
        }

        private DataRow GetDataRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Str");
            dt.Columns.Add("DT_val");
            dt.Columns.Add("DTNull_val");
            dt.Columns.Add("Int32_val");
            dt.Columns.Add("Int32Null_val");
            dt.Columns.Add("Int16_val");
            dt.Columns.Add("Int64_val");
            dt.Columns.Add("UInt32_val");
            dt.Columns.Add("UInt16_val");
            dt.Columns.Add("UInt64_val");
            dt.Columns.Add("Double_val");
            dt.Columns.Add("Decimal_val");
            dt.Columns.Add("Float_val");
            DataRow dr = dt.NewRow();
            return dr;
        }

        private void SetData(DataRow dr)
        {

            dr["str"] = "test";
            dr["dTNull_val"] = "";
            dr["Int32_val"] = 3;
            dr["int32Null_val"] = "";
            dr["Int16_val"] = 2;
            dr["Int64_val"] = "1";
            dr["UInt32_val"] = 5;
            dr["UInt16_val"] = 7;
            dr["UInt64_val"] = 23;
            dr["Double_val"] = 9;
            dr["Decimal_val"] = "7";
            dr["Float_val"] = "67";
            dr["DT_val"] = "2015-02-03";
        }

        private void AssertObj(CCBOTest obj)
        {
            Assert.IsTrue(obj.DTNull_val == null &&
                obj.Int32_val == 3 && obj.Int16_val == 2 && obj.Int64_val == 1 && obj.UInt32_val == 5 &&
                obj.UInt16_val == 7 && obj.UInt64_val == 23 && obj.Double_val == 9 && obj.Decimal_val == 7 &&
                obj.Float_val == 67 && obj.Int32Null_val == null &&
                obj.DT_val == Convert.ToDateTime("2015-02-03"));
        }

        private void FillDR<T>(T obj, DataRow dr)
        {
            CBO.FillObject(obj, (string name) =>
            {
                if (!dr.Table.Columns.Contains(name))
                {
                    return null;
                }
                return dr[name];
            });
        }
    }
}
