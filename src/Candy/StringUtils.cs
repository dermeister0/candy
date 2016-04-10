//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Strings utils.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Truncates string to max length.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <param name="maxLength">Max length.</param>
        /// <returns>Result.</returns>
        [DebuggerStepThrough]
        public static String Truncate(String target, Int32 maxLength)
        {
            ValidateUtils.IsNotEmpty(target, nameof(target));
            ValidateUtils.IsNotNegativeOrZero(maxLength, nameof(maxLength));
            return target.Length <= maxLength ? target : target.Substring(0, maxLength); 
        }

        /// <summary>
        /// Joins the objects ignore empty ones.
        /// </summary>
        /// <param name="separator">The string to use as a separator.</param>
        /// <param name="values">The values.</param>
        /// <returns>Concatenated string.</returns>
        [DebuggerStepThrough]
        public static String JoinIgnoreEmpty(String separator, params String[] values)
        {
            ValidateUtils.IsNotEmpty(separator, nameof(separator));
            ValidateUtils.IsNotNull(values, nameof(values));
#if !NET3_5
            return String.Join(separator, values.Where(x => x.IsNotEmpty()));
#else
            return String.Join(separator, values.Where(x => x.IsNotEmpty()).ToArray());
#endif
        }

        /// <summary>
        /// Joins the strings ignore empty ones.
        /// </summary>
        /// <param name="separator">The string to use as a separator.</param>
        /// <param name="values">The values.</param>
        /// <returns>Concatenated string.</returns>
        [DebuggerStepThrough]
        public static String JoinIgnoreEmpty(String separator, IEnumerable<String> values)
        {
            ValidateUtils.IsNotEmpty(separator, nameof(separator));
            ValidateUtils.IsNotNull(values, nameof(values));
#if !NET3_5
            return String.Join(separator, values.Where(x => x.IsNotEmpty()));
#else
            return String.Join(separator, values.Where(x => x.IsNotEmpty()).ToArray());
#endif
        }

        /// <summary>
        /// Converts wildcards to regex. Determines what reg exp correspond to string with * and ? chars.
        /// </summary>
        /// <param name="pattern">The wildcards pattern.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static String WildcardToRegex(String pattern)
        {
            ValidateUtils.IsNotEmpty(pattern, nameof(pattern));
            return ("^" + Regex.Escape(pattern)).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        }

        /// <summary>
        /// Reverse string characters. "123" -> "321".
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <returns>Reversed string.</returns>
        [DebuggerStepThrough]
        public static String Reverse(String target)
        {
            ValidateUtils.IsNotEmpty(target, nameof(target));

            Char[] arr = target.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }

        /// <summary>
        /// Retrieves a substring from this instance. If start index had negative value it will be replaced
        /// to 0. If substring exceed length of target string the end of string will be returned.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>Substring.</returns>
        [DebuggerStepThrough]
        public static String SafeSubstring(String target, int startIndex, int length = 0)
        {
            ValidateUtils.IsNotEmpty(target, nameof(target));

            if (startIndex < 0)
            {
                startIndex = 0;
            }
            else if (startIndex > target.Length)
            {
                return string.Empty;
            }
            if (length == 0)
            {
                length = target.Length;
            }
            else if (startIndex + length > target.Length)
            {
                length = target.Length - startIndex;
            }
            return target.Substring(startIndex, length);
        }

        /// <summary>
        /// Converts the string to snake case style (HelloWorld -> Hello_World). The string will have underscore (_) in front of
        /// each upper case letter. The function does not remove spaces and does not make string lower case.
        /// </summary>
        public static String ConvertToSnakeCase(String target)
        {
#if !PORTABLE
            return String.Concat(target.Select((ch, index) => index > 0 && Char.IsUpper(ch) ? "_" + ch.ToString() : ch.ToString()).ToArray());
#else
            var sb = new System.Text.StringBuilder(target.Length + 4);
            for (Int32 index = 0; index < target.Length; index++)
            {
                sb.Append(index > 0 && Char.IsUpper(target[index]) ? "_" + target[index].ToString() : target[index].ToString());
            }
            return sb.ToString();
#endif
        }

#region Parse with default

        /// <summary>
        /// Tries to convert target string to Boolean. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Boolean ParseDefault(String target, Boolean defaultValue)
        {
            Boolean result;
            var success = Boolean.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Byte. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Byte ParseDefault(String target, Byte defaultValue)
        {
            Byte result;
            var success = Byte.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Byte. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Byte ParseDefault(String target, NumberStyles style, IFormatProvider provider, Byte defaultValue)
        {
            Byte result;
            var success = Byte.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Char. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Char ParseDefault(String target, Char defaultValue)
        {
            Char result;
            var success = Char.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to DateTime. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static DateTime ParseDefault(String target, DateTime defaultValue)
        {
            DateTime result;
            var success = DateTime.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to DateTime. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static DateTime ParseDefault(String target, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)
        {
            DateTime result;
            var success = DateTime.TryParse(target, provider, styles, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Decimal. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Decimal ParseDefault(String target, Decimal defaultValue)
        {
            Decimal result;
            var success = Decimal.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Decimal. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Decimal ParseDefault(String target, NumberStyles style, IFormatProvider provider, Decimal defaultValue)
        {
            Decimal result;
            var success = Decimal.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Double. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double ParseDefault(String target, Double defaultValue)
        {
            Double result;
            var success = Double.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Double. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double ParseDefault(String target, NumberStyles style, IFormatProvider provider, Double defaultValue)
        {
            Double result;
            var success = Double.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int16 ParseDefault(String target, Int16 defaultValue)
        {
            Int16 result;
            var success = Int16.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int16 ParseDefault(String target, NumberStyles style, IFormatProvider provider, Int16 defaultValue)
        {
            Int16 result;
            var success = Int16.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int32 ParseDefault(String target, Int32 defaultValue)
        {
            Int32 result;
            var success = Int32.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int32 ParseDefault(String target, NumberStyles style, IFormatProvider provider, Int32 defaultValue)
        {
            Int32 result;
            var success = Int32.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int64 ParseDefault(String target, Int64 defaultValue)
        {
            Int64 result;
            var success = Int64.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int64 ParseDefault(String target, NumberStyles style, IFormatProvider provider, Int64 defaultValue)
        {
            Int64 result;
            var success = Int64.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to SByte. If fails returns default value.
        /// </summary>
        [CLSCompliant(false)]
        [DebuggerStepThrough]
        public static SByte ParseDefault(String target, SByte defaultValue)
        {
            SByte result;
            var success = SByte.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to SByte. If fails returns default value.
        /// </summary>
        [CLSCompliant(false)]
        [DebuggerStepThrough]
        public static SByte ParseDefault(String target, NumberStyles style, IFormatProvider provider, SByte defaultValue)
        {
            SByte result;
            var success = SByte.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Single. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Single ParseDefault(String target, Single defaultValue)
        {
            Single result;
            var success = Single.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Single. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double ParseDefault(String target, NumberStyles style, IFormatProvider provider, Single defaultValue)
        {
            Single result;
            var success = Single.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt16 ParseDefault(String target, UInt16 defaultValue)
        {
            UInt16 result;
            var success = UInt16.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt16 ParseDefault(String target, NumberStyles style, IFormatProvider provider, UInt16 defaultValue)
        {
            UInt16 result;
            var success = UInt16.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt32 ParseDefault(String target, UInt32 defaultValue)
        {
            UInt32 result;
            var success = UInt32.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt32 ParseDefault(String target, NumberStyles style, IFormatProvider provider, UInt32 defaultValue)
        {
            UInt32 result;
            var success = UInt32.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt64 ParseDefault(String target, UInt64 defaultValue)
        {
            UInt64 result;
            var success = UInt64.TryParse(target, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt64 ParseDefault(String target, NumberStyles style, IFormatProvider provider, UInt64 defaultValue)
        {
            UInt64 result;
            var success = UInt64.TryParse(target, style, provider, out result);
            return success ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Enum. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static T ParseDefault<T>(String target, T defaultValue) where T : struct
        {
#if !NET3_5
            T result;
            var success = Enum.TryParse<T>(target, out result);
            return success ? result : defaultValue;
#else
            return Enum.IsDefined(typeof(T), target) ? (T) Enum.Parse(typeof(T), target, true) : defaultValue;
#endif
        }

        /// <summary>
        /// Tries to convert target string to Enum. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static T ParseDefault<T>(String target, Boolean ignoreCase, T defaultValue) where T : struct
        {
#if !NET3_5
            T result;
            var success = Enum.TryParse<T>(target, ignoreCase, out result);
            return success ? result : defaultValue;
#else
            return Enum.IsDefined(typeof(T), target) ? (T) Enum.Parse(typeof(T), target, true) : defaultValue;
#endif
        }

#endregion

#region .NET 3.5

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of
        /// white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>
        /// True if the value parameter is null or System.String.Empty, or if value consists
        /// exclusively of white-space characters.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(String value)
        {
            if (value == null)
            {
                return true;
            }

            for (Int32 i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks string is it null or empty.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>Returns true if it is null or empty or false otherwise.</returns>
        public static bool IsNullOrEmpty(String value)
        {
            return value == null || value.Length == 0;
        }

        /// <summary>
        /// Concatenates enumerable of strings.
        /// </summary>
        /// <param name="values">Values of strings to concatenate.</param>
        /// <returns>Concatenated string.</returns>
        [DebuggerStepThrough]
        public static String Concat(IEnumerable<String> values)
        {
            return String.Concat(values.ToArray());
        }
#endregion
    }
}
