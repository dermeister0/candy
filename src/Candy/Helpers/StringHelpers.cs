//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Text;
    using Candy.Extensions;

    /// <summary>
    /// String helpers.
    /// </summary>
    public static class StringHelpers
    {
        #region Manipulation

        /// <summary>
        /// Converts the string to snake case style (HelloWorld -> hello_world). The string will have underscore (_) in front of each upper case letter.
        /// The function does not remove spaces and does not make string lower case.
        /// </summary>
        public static String ConvertToSnakeCase(String target)
        {
            return Concat(target.Select((ch, index) => index > 0 && Char.IsUpper(ch) ? "_" + ch.ToString() : ch.ToString()));
        }

        /// <summary>
        /// Truncates string to max length.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <param name="maxLength">Max length.</param>
        /// <returns>Result.</returns>
        [DebuggerStepThrough]
        public static String Truncate(String target, Int32 maxLength)
        {
            return target.Length <= maxLength ? target : target.Substring(0, maxLength); 
        }

        /// <summary>
        /// Concatenates enumerable of strings using the specified separator.
        /// </summary>
        /// <param name="separator">The string to use as a separator.</param>
        /// <param name="values">A collection that contains the strings to concatenate.</param>
        /// <returns>Concatenated string.</returns>
        [DebuggerStepThrough]
        public static String Join(String separator, IEnumerable<String> values)
        {
#if !NET3_5
            return String.Join(separator, values);
#else
            return String.Join(separator, values.ToArray());
#endif
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
            return StringHelpers.Join(separator, values.Where(x => x.IsNotEmpty()));
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
            return StringHelpers.Join(separator, values.Where(x => x.IsNotEmpty()));
        }

        /// <summary>
        /// Concatenates enumerable of strings.
        /// </summary>
        /// <param name="values">Values of strings to concatenate.</param>
        /// <returns>Concatenated string.</returns>
        [DebuggerStepThrough]
        public static String Concat(IEnumerable<String> values)
        {
#if !NET3_5
            return String.Concat(values);
#else
            return String.Concat(values.ToArray());
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
            return
                ("^" + Regex.Escape(pattern)).
                Replace("\\*", ".*").
                Replace("\\?", ".") + "$";
        }

        #endregion

        #region Checks

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
#if !NET3_5
            return String.IsNullOrWhiteSpace(value);
#else
            if (value == null)
                return true;

            for (Int32 i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i]))
                    return false;
            }
            return true;
#endif
        }

        /// <summary>
        /// Checks string is it null or empty.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>Returns true if it is null or empty or false otherwise.</returns>
        public static bool IsNullOrEmpty(String value)
        {
#if !NET3_5
            return String.IsNullOrEmpty(value);
#else
            return value == null || value.Length == 0;
#endif
        }

        #endregion

        #region Parse with default

        /// <summary>
        /// Tries to convert target string to Boolean. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Boolean TryParseBooleanDefault(String target, Boolean defaultValue)
        {
            Boolean result;
            var bRet = Boolean.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Byte. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Byte TryParseByteDefault(String target, Byte defaultValue)
        {
            Byte result;
            var bRet = Byte.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Byte. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Byte TryParseByteDefault(String target, NumberStyles style, IFormatProvider provider, Byte defaultValue)
        {
            Byte result;
            var bRet = Byte.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Char. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Char TryParseCharDefault(String target, Char defaultValue)
        {
            Char result;
            var bRet = Char.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to DateTime. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static DateTime TryParseDateTimeDefault(String target, DateTime defaultValue)
        {
            DateTime result;
            var bRet = DateTime.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to DateTime. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static DateTime TryParseDateTimeDefault(String target, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)
        {
            DateTime result;
            var bRet = DateTime.TryParse(target, provider, styles, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Decimal. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Decimal TryParseDecimalDefault(String target, Decimal defaultValue)
        {
            Decimal result;
            var bRet = Decimal.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Decimal. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Decimal TryParseDecimalDefault(String target, NumberStyles style, IFormatProvider provider, Decimal defaultValue)
        {
            Decimal result;
            var bRet = Decimal.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Dobule. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double TryParseDoubleDefault(String target, Double defaultValue)
        {
            Double result;
            var bRet = Double.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Dobule. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double TryParseDoubleDefault(String target, NumberStyles style, IFormatProvider provider, Double defaultValue)
        {
            Double result;
            var bRet = Double.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int16 TryParseInt16Default(String target, Int16 defaultValue)
        {
            Int16 result;
            var bRet = Int16.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int16 TryParseInt16Default(String target, NumberStyles style, IFormatProvider provider, Int16 defaultValue)
        {
            Int16 result;
            var bRet = Int16.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int32 TryParseInt32Default(String target, Int32 defaultValue)
        {
            Int32 result;
            var bRet = Int32.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int32 TryParseInt64Default(String target, NumberStyles style, IFormatProvider provider, Int32 defaultValue)
        {
            Int32 result;
            var bRet = Int32.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int64 TryParseInt64Default(String target, Int64 defaultValue)
        {
            Int64 result;
            var bRet = Int64.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Int64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Int64 TryParseInt64Default(String target, NumberStyles style, IFormatProvider provider, Int64 defaultValue)
        {
            Int64 result;
            var bRet = Int64.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to SByte. If fails returns default value.
        /// </summary>
        [CLSCompliant(false)]
        [DebuggerStepThrough]
        public static SByte TryParseSByteDefault(String target, SByte defaultValue)
        {
            SByte result;
            var bRet = SByte.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to SByte. If fails returns default value.
        /// </summary>
        [CLSCompliant(false)]
        [DebuggerStepThrough]
        public static SByte TryParseSByteDefault(String target, NumberStyles style, IFormatProvider provider, SByte defaultValue)
        {
            SByte result;
            var bRet = SByte.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Single. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Single TryParseSingleDefault(String target, Single defaultValue)
        {
            Single result;
            var bRet = Single.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Single. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static Double TryParseSingleDefault(String target, NumberStyles style, IFormatProvider provider, Single defaultValue)
        {
            Single result;
            var bRet = Single.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt16 TryParseUInt16Default(String target, UInt16 defaultValue)
        {
            UInt16 result;
            var bRet = UInt16.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt16. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt16 TryParseUInt16Default(String target, NumberStyles style, IFormatProvider provider, UInt16 defaultValue)
        {
            UInt16 result;
            var bRet = UInt16.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt32 TryParseUInt32Default(String target, UInt32 defaultValue)
        {
            UInt32 result;
            var bRet = UInt32.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt32. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt32 TryParseUInt64Default(String target, NumberStyles style, IFormatProvider provider, UInt32 defaultValue)
        {
            UInt32 result;
            var bRet = UInt32.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt64 TryParseUInt64Default(String target, UInt64 defaultValue)
        {
            UInt64 result;
            var bRet = UInt64.TryParse(target, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to UInt64. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static UInt64 TryParseUInt64Default(String target, NumberStyles style, IFormatProvider provider, UInt64 defaultValue)
        {
            UInt64 result;
            var bRet = UInt64.TryParse(target, style, provider, out result);
            return bRet ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert target string to Enum. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static T TryParseEnumDefault<T>(String target, T defaultValue) where T : struct
        {
#if !NET3_5
            T result;
            var bRet = Enum.TryParse<T>(target, out result);
            return bRet ? result : defaultValue;
#else
            return Enum.IsDefined(typeof(T), target) ? (T) Enum.Parse(typeof(T), target, true) : defaultValue;
#endif
        }

        /// <summary>
        /// Tries to convert target string to Enum. If fails returns default value.
        /// </summary>
        [DebuggerStepThrough]
        public static T TryParseEnumDefault<T>(String target, Boolean ignoreCase, T defaultValue) where T : struct
        {
#if !NET3_5
            T result;
            var bRet = Enum.TryParse<T>(target, ignoreCase, out result);
            return bRet ? result : defaultValue;
#else
            return Enum.IsDefined(typeof(T), target) ? (T) Enum.Parse(typeof(T), target, true) : defaultValue;
#endif
        }

        #endregion
    }
}
