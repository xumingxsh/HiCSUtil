using System;
using System.Reflection;

namespace HiCSUtil
{
    static partial class  CBO
    {
        private static void SetValue(object obj, object value, PropertyInfo property)
        {
            Type type = property.PropertyType;
            if (value is DBNull || value == null ||
                (type != typeof(string) && value is string && Convert.ToString(value).Trim().Equals("")))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    property.SetValue(obj, null);
                    return;
                }
                else if (type.BaseType != typeof(System.ValueType))
                {
                    property.SetValue(obj, null);
                    return;
                }
                return;
            }

            if (type.FullName == typeof(Int16).FullName ||
                type.FullName == typeof(Int16?).FullName)
            {
                property.SetValue(obj, Convert.ToInt16(value), null);
                return;
            }

            if (type.FullName == typeof(Int64).FullName ||
                type.FullName == typeof(Int64?).FullName)
            {
                property.SetValue(obj, Convert.ToInt64(value), null);
                return;
            }

            if (type.FullName == typeof(int).FullName ||
                type.FullName == typeof(int?).FullName)
            {
                property.SetValue(obj, Convert.ToInt32(value), null);
                return;
            }

            if (type.FullName == typeof(UInt32).FullName ||
                type.FullName == typeof(UInt32?).FullName)
            {
                property.SetValue(obj, Convert.ToUInt32(value), null);
                return;
            }

            if (type.FullName == typeof(UInt16).FullName ||
                type.FullName == typeof(UInt16?).FullName)
            {
                property.SetValue(obj, Convert.ToUInt16(value), null);
                return;
            }

            if (type.FullName == typeof(UInt64).FullName ||
                type.FullName == typeof(UInt64?).FullName)
            {
                property.SetValue(obj, Convert.ToUInt64(value), null);
                return;
            }

            if (type.FullName == typeof(DateTime).FullName ||
                type.FullName == typeof(DateTime?).FullName)
            {
                property.SetValue(obj, Convert.ToDateTime(value), null);
                return;
            }

            if (type.FullName == typeof(Decimal).FullName ||
                type.FullName == typeof(Decimal?).FullName)
            {
                property.SetValue(obj, Convert.ToDecimal(value), null);
                return;
            }

            if (type.FullName == typeof(double).FullName ||
                type.FullName == typeof(double?).FullName)
            {
                property.SetValue(obj, Convert.ToDouble(value), null);
                return;
            }

            if (type.FullName == typeof(float).FullName ||
                type.FullName == typeof(float?).FullName)
            {
                property.SetValue(obj, Convert.ToSingle(value), null);
                return;
            }

            if (type.FullName == typeof(bool).FullName ||
                type.FullName == typeof(bool?).FullName)
            {
                property.SetValue(obj, Convert.ToBoolean(value), null);
                return;
            }

            if (type.FullName == typeof(string).FullName)
            {
                if (value is String)
                {
                    property.SetValue(obj, value, null);
                }
                else
                {
                    property.SetValue(obj, Convert.ToString(value), null);
                }
                return;
            }

            if (type.BaseType == typeof(System.Enum))
            {
                if (value is DBNull || value == null)
                {
                    return;
                }

                try
                {
                    int val = Convert.ToInt32(value);
                    property.SetValue(obj, Enum.ToObject(type, val), null);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return;
                }
                return;
            }

            try
            {
                property.SetValue(obj, value, null);
            }
            catch (Exception ex)
            {
                ex.ToString();
                try
                {
                    property.SetValue(obj, value, null);
                }
                catch (Exception e)
                {
                    e.ToString();
                    property.SetValue(obj, null, null);
                }
            }
            return;
        }
    }
}
