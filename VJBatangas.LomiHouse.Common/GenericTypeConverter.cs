using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Common
{
    public class GenericTypeConverter
    {
        private static IDictionary<Type, Func<object, object>> ConversionStrategy = new Dictionary<Type, Func<object, object>>();

        static GenericTypeConverter()
        {
            ConversionStrategy.Add(typeof(Int32), ToInt32);
            ConversionStrategy.Add(typeof(Int32?), ToInt32);
            ConversionStrategy.Add(typeof(Int16), ToInt16);
            ConversionStrategy.Add(typeof(Int16?), ToInt16);
            ConversionStrategy.Add(typeof(char), ToChar);
            ConversionStrategy.Add(typeof(char?), ToChar);
            ConversionStrategy.Add(typeof(byte), ToByte);
            ConversionStrategy.Add(typeof(byte?), ToByte);
            ConversionStrategy.Add(typeof(decimal), ToDecimal);
            ConversionStrategy.Add(typeof(decimal?), ToDecimal);
            ConversionStrategy.Add(typeof(bool), ToBoolean);
            ConversionStrategy.Add(typeof(bool?), ToBoolean);
            ConversionStrategy.Add(typeof(string), ToString);
        }

        public static object ToInt32(object data)
        {
            if (data is String)
            {
                String str = data as String;
                if (str.Trim().Length <= 0)
                {
                    return null;
                }
            }
            else if (data is char)
            {
                char c = (char)data;
                if (c == ' ')
                {
                    return null;
                }
            }
            return Convert.ToInt32(data);
        }

        public static object ToInt16(object data)
        {
            if (data is String)
            {
                String str = data as String;
                if (str.Trim().Length <= 0)
                {
                    return null;
                }
            }
            else if (data is char)
            {
                char c = (char)data;
                if (c == ' ')
                {
                    return null;
                }
            }
            return Convert.ToInt16(data);
        }

        public static object ToChar(object data)
        {
            return Convert.ToChar(data);
        }

        public static object ToByte(object data)
        {
            return Convert.ToByte(data);
        }

        public static object ToBoolean(object data)
        {
            return Convert.ToBoolean(data);
        }

        public static object ToDecimal(object data)
        {
            if (data is String)
            {
                String str = data as String;
                if (str.Trim().Length <= 0)
                {
                    return null;
                }
            }
            else if (data is char)
            {
                char c = (char)data;
                if (c == ' ')
                {
                    return null;
                }
            }
            return Convert.ToDecimal(data);
        }

        public static object ToString(object data)
        {
            return Convert.ToString(data);
        }



        public static DateTime ToUtc(DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Utc)
            {
                return dt.ToUniversalTime();
            }
            else
            {
                return dt;
            }
        }

        public static DateTime ToLocalTime(DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Local)
            {
                return dt.ToLocalTime();
            }
            else
            {
                return dt;
            }
        }

        public static T ConvertValue<T>(object fieldValue)
        {
            if (fieldValue == null || fieldValue.Equals(DBNull.Value))
            {
                return default(T);
            }
            else if (fieldValue is T)
            {
                return (T)fieldValue;
            }
            else
            {
                try
                {
                    return (T)ConversionStrategy[typeof(T)].Invoke(fieldValue);
                }
                catch (KeyNotFoundException)
                {
                    throw new NotSupportedException(String.Format("Converting '{0}' to type '{1}' is unsupported", fieldValue, typeof(T)));
                }
            }
        }
    }
}
