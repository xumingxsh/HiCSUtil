﻿using System;
using System.Data;
using System.Reflection;

namespace HiCSUtil
{
    /// <summary>
    /// 根据数据源填充对象的类。
    /// XuminRong 2016-04-18
    /// </summary>
    public static partial class CBO
    {
        /// <summary>
        /// 根据属性名称，取得对应的值。
        /// </summary>
        /// <param name="objVal">赋值对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>true:属性存在；false:属性不存在</returns>
        public delegate bool OnGetObjectHandler(ref object objVal, string propertyName);
        
        /// <summary>
        /// 根据DataRow填充对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T CreateObj<T>(DataRow dr) where T : class, new()
        {
            T t = new T();

            bool result = HiCSUtil.CBO.FillObject<T>(t, (string name) =>
            {
                if (!dr.Table.Columns.Contains(name))
                {
                    return null;
                }
                return dr[name];
            });

            if (result)
            {
                return t;
            }
            return null;
        }

        /// <summary>
        /// 填充数据对象。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="handler"></param>
        /// <returns>出错的列索引，如果为-1，则成功;1000:列不确定</returns>
        public static bool FillObject<T>(T obj, OnGetObjectHandler handler)
        {
            if (obj == null || obj is DBNull)
            {
                return false;
            }

            // 循环遍历属性集成
            foreach (PropertyInfo it in typeof(T).GetProperties())
            {
                // 如果该属性允许写入/含有Set的属性
                if (!it.CanWrite)
                {
                    continue;
                }

                object objVal = null;
                if (!handler(ref objVal, it.Name))
                {
                    continue;
                }
                SetValue(obj, objVal, it);
            }
            return true;
        }

        /// <summary>
        /// 填充数据对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static bool FillObject<T>(T obj, Func<string, object> handler)
        {
            if (obj == null || obj is DBNull)
            {
                return false;
            }

            // 循环遍历属性集成
            foreach (PropertyInfo it in typeof(T).GetProperties())
            {
                // 如果该属性允许写入/含有Set的属性
                if (!it.CanWrite)
                {
                    continue;
                }

                object objVal = handler(it.Name);
                SetValue(obj, objVal, it);
            }
            return true;
        }

        /// <summary>
        /// 根据属性拷贝对象
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="src"></param>
        /// <param name="d"></param>
        public static void Copy8Property<S, D>(S src, D d) where S :class
            where D: class
        {
            CBO.FillObject<D>(d, (ref object objVal, string propertyName) =>
            {
                objVal = "";
                // 循环遍历属性集成
                foreach (PropertyInfo proper in typeof(S).GetProperties())
                {
                    if (proper.Name.ToLower().Equals(propertyName.ToLower()))
                    {
                        object obj = proper.GetValue(src, null);
                        if (obj != null)
                        {
                            objVal = Convert.ToString(obj);
                        }
                        return true;
                    }
                }
                return false;
            });
        }

        /// <summary>
        /// 根据源对象创建对象
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static D Create8Property<S, D>(S src)
            where S : class
            where D : class, new()
        {
            D d = new D();
            Copy8Property(src, d);
            return d;
        }

        /// <summary>
        /// 根据属性名称，设置属性值。
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">赋值对象</param>
        /// <param name="val">值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>true：成功；false：属性不存在</returns>
        public static bool SetValue<T>(T t, object val, string propertyName)
        {
            if (t == null || t is DBNull)
            {
                return false;
            }

            // 循环遍历属性集成
            foreach (PropertyInfo it in typeof(T).GetProperties())
            {
                if (propertyName.ToLower().Equals(it.Name.ToLower()))
                {
                    SetValue(t, val, it);
                    return true;
                }
            }
            return false;
        }
    }
}
