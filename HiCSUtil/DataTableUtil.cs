using System;
using System.Data;

namespace HiCSUtil
{
    /// <summary>
    /// DataTable辅助处理类
    /// </summary>
    public static class DataTableUtil
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T Create<T>(DataRow dr) where T:class, new()
        {
            if (dr == null)
            {
                return null;
            }

            T t = new T();
            CBO.FillObject(t, (string name) =>
            {
                return dr[name];
            });
            return t;
        }

        /// <summary>
        /// 值转换为int
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int ReadInt(DataTable dt, int rowIndex, int index)
        {
            if (dt == null || dt.Rows.Count <= rowIndex || 
                dt.Columns.Count <= index)
            {
                return -1;
            }
            return HiTypeHelper.Obj2Int(dt.Rows[rowIndex][index]);
        }

        /// <summary>
        /// 值转换为string
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ReadStr(DataTable dt, int rowIndex, int index)
        {
            if (dt == null || dt.Rows.Count <= rowIndex ||
                dt.Columns.Count <= index)
            {
                return "";
            }
            return HiTypeHelper.Obj2Str(dt.Rows[rowIndex][index]);
        }

        /// <summary>
        /// 值转换为DateTime
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static DateTime ReadDateTime(DataTable dt, int rowIndex, int index)
        {
            if (dt == null || dt.Rows.Count <= rowIndex ||
                dt.Columns.Count <= index)
            {
                return default(DateTime);
            }
            return HiTypeHelper.Obj2DateTime(dt.Rows[rowIndex][index]);
        }

        /// <summary>
        /// 值转换为int
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static int ReadInt(DataTable dt, int rowIndex, string field)
        {
            if (dt == null || dt.Rows.Count <= rowIndex)
            {
                return -1;
            }
            return HiTypeHelper.Obj2Int(dt.Rows[rowIndex][field]);
        }

        /// <summary>
        /// 值转换为string
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ReadStr(DataTable dt, int rowIndex, string field)
        {
            if (dt == null || dt.Rows.Count <= rowIndex)
            {
                return "";
            }
            return HiTypeHelper.Obj2Str(dt.Rows[rowIndex][field]);
        }

        /// <summary>
        /// 值转换为DateTime
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DateTime ReadDateTime(DataTable dt, int rowIndex, string field)
        {
            if (dt == null || dt.Rows.Count <= rowIndex)
            {
                return default(DateTime);
            }
            return HiTypeHelper.Obj2DateTime(dt.Rows[rowIndex][field]);
        }

        /// <summary>
        /// 值转换为int
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int ReadInt(DataRow dr, int index)
        {
            if (dr == null || dr.Table.Columns.Count <= index)
            {
                return -1;
            }
            return HiTypeHelper.Obj2Int(dr[index]);
        }

        /// <summary>
        /// 值转换为string
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ReadStr(DataRow dr, int index)
        {
            if (dr == null || dr.Table.Columns.Count <= index)
            {
                return "";
            }
            return HiTypeHelper.Obj2Str(dr[index]);
        }

        /// <summary>
        /// 值转换为int
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static int ReadInt(DataRow dr, string field)
        {
            if (dr == null)
            {
                return -1;
            }

            return HiTypeHelper.Obj2Int(dr[field]);
        }

        /// <summary>
        /// 值转换为string
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ReadStr(DataRow dr, string field)
        {
            if (dr == null)
            {
                return "";
            }

            return HiTypeHelper.Obj2Str(dr[field]);
        }

        /// <summary>
        /// 值转换为DateTime
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DateTime ReadDateTime(DataRow dr, string field)
        {
            if (dr == null)
            {
                return default(DateTime);
            }

            return HiTypeHelper.Obj2DateTime(dr[field]);
        }
    }
}
