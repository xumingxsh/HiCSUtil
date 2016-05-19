using System;

namespace HiCSUtil
{
    /// <summary>
    /// 类型辅助类
    /// 2016-05-18 徐敏荣
    /// 注:该类借鉴自ESBasic的同名类
    /// </summary>
    public sealed class HiTypeHelper
    {
        /// <summary>
        /// 是否为简单类型：数值、字符、字符串、日期、布尔、枚举、Type
        /// </summary>      
        public static bool IsSimpleType(Type t)
        {
            if (t.IsEnum)
            {
                return true;
            }

            if (t == typeof(string))
            {
                return true;
            }

            if (t == typeof(Type))
            {
                return true;
            }

            if (t.IsSubclassOf(typeof(ValueType)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为简单类型：数值、字符、字符串、日期、布尔、枚举、Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsSimpleType<T>(T v)
        {
            Type t = typeof(T);
            return IsSimpleType(t);
        }

        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="destDataType"></param>
        /// <returns></returns>
        public static bool IsNumbericType(Type destDataType)
        {
            if ((destDataType == typeof(int)) || (destDataType == typeof(uint)) || (destDataType == typeof(double))
                || (destDataType == typeof(short)) || (destDataType == typeof(ushort)) || (destDataType == typeof(decimal))
                || (destDataType == typeof(long)) || (destDataType == typeof(ulong)) || (destDataType == typeof(float))
                || (destDataType == typeof(byte)) || (destDataType == typeof(sbyte)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumbericType<T>()
        {
            Type destDataType = typeof(T);
            if ((destDataType == typeof(int)) || (destDataType == typeof(uint)) || (destDataType == typeof(double))
                || (destDataType == typeof(short)) || (destDataType == typeof(ushort)) || (destDataType == typeof(decimal))
                || (destDataType == typeof(long)) || (destDataType == typeof(ulong)) || (destDataType == typeof(float))
                || (destDataType == typeof(byte)) || (destDataType == typeof(sbyte)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为整数
        /// </summary>
        /// <param name="destDataType"></param>
        /// <returns></returns>
        public static bool IsIntegerType(Type destDataType)
        {
            if ((destDataType == typeof(int)) || (destDataType == typeof(uint)) || (destDataType == typeof(short)) || (destDataType == typeof(ushort))
                || (destDataType == typeof(long)) || (destDataType == typeof(ulong)) || (destDataType == typeof(byte)) || (destDataType == typeof(sbyte)))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 获得数据的默认值
        /// </summary>       
        public static object GetMyDefault<T>()
        {
            if (typeof(T) == typeof(String))
            {
                return "";
            }

            if (IsNumbericType<T>())
            {
                return -1;
            }

            return default(T);
        }

        /// <summary>
        /// 类型转转
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object ChangeType<T>(object val)
        {
            Type targetType = typeof(T);
            if (val == null || val is DBNull)
            {
                return GetMyDefault<T>();
            }

            if (targetType.IsAssignableFrom(val.GetType()))
            {
                return val;
            }

            if (targetType == val.GetType())
            {
                return val;
            }

            if (targetType == typeof(bool))
            {
                if (val.ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }

            if (targetType.IsEnum)
            {
                int intVal = 0;
                bool suc = int.TryParse(val.ToString(), out intVal);
                if (!suc)
                {
                    return Enum.Parse(targetType, val.ToString());
                }
                else
                {
                    return val;
                }
            }

            if (targetType == typeof(IComparable))
            {
                return val;
            }

            //将double赋值给数值型的DataRow的字段是可以的，但是通过反射赋值给object的非double的其它数值类型的属性，却不行        
            return System.Convert.ChangeType(val, targetType);
        }

        /// <summary>
        /// 将对象转换为int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Obj2Int(object obj)
        {
            return Obj2Val<int>(obj, -1, (val) =>
            {
                return Convert.ToInt32(val);
            });
        }

        /// <summary>
        /// 将对象转换为string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Obj2Str(object obj)
        {
            return Obj2Val<string>(obj, "", (val) =>
            {
                return Convert.ToString(val);
            });
        }

        /// <summary>
        /// 将对象转换为DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime Obj2DateTime(object obj)
        {
            return Obj2Val<DateTime>(obj, default(DateTime), (val) =>
            {
                return Convert.ToDateTime(val);
            });
        }

        /// <summary>
        /// 类型转换函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public delegate T OnConvertHandler<T>(object obj);

        /// <summary>
        /// 将对象转换为目标类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="def"></param>
        /// <param name="conv"></param>
        /// <returns></returns>
        public static T Obj2Val<T>(object obj, T def, OnConvertHandler<T> conv)
        {
            if (obj == null || obj is DBNull)
            {
                return def;
            }

            try
            {
                return conv(obj);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return def;
            }
        }          
    }
}
