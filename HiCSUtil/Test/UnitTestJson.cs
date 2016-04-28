using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUtil;

namespace HiCSUtil.Test
{
    [TestClass]
    public class UnitTestJson
    {
        [TestMethod]
        public void UnitTestJson_DataTable()
        {
            DataTable dt = GetTable();
            dt.TableName = "table";
            string str = Json.DataTable2Json(dt);
            System.Diagnostics.Debug.WriteLine(str);
            DataTable dt2 = Json.Json2DataTable(str);
            Assert.IsTrue(dt2.Rows.Count > 0);
        }

        [TestMethod]
        public void UnitTestJson_DataTable2()
        {
            DataTable dt = GetTable(false);
            dt.TableName = "table";
            string str = Json.DataTable2Json(dt);
            System.Diagnostics.Debug.WriteLine(str);
            DataTable dt2 = Json.Json2DataTable(str);
            Assert.IsTrue(dt2.Columns.Count > 0);
        }

        [TestMethod]
        public void UnitTestJson_Dictionary()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic["x"] = "x";
            dic["y"] = "y";
            string text = Json.Obj2Json(dic);
            Assert.IsFalse(string.IsNullOrWhiteSpace(text));
            System.Diagnostics.Trace.WriteLine(text);
            Dictionary<string, string> dic2 = Json.Json2Obj<Dictionary<string, string>>(text);
            Assert.IsTrue(dic2.Count == 2);
        }

        public DataTable GetTable(bool hasRow = true)
        {
            DataTable dt = GetDataRow();
            if (!hasRow)
            {
                return dt;
            }
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                SetData(dr);
            }

            return dt;
        }

        private DataTable GetDataRow()
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
            return dt;
        }

        private void SetData(DataRow dr)
        {

            dr["str"] = "test";
            dr["dTNull_val"] = DBNull.Value;
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
    }
}
