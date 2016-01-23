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
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// String class extensions.
    /// </summary>
    [CLSCompliant(true)]
    public static class StringExtensions
    {
        /// <summary>
        /// Formats target string with number of arguments. Equivalent of String.Format.
        /// </summary>
        /// <param name="format">Target string.</param>
        /// <param name="arg0">Argument 1.</param>
        /// <returns>Formatted string.</returns>
        [DebuggerStepThrough]
        public static String FormatWith(this String format, Object arg0)
        {
            return String.Format(format, arg0);
        }

        /// <summary>
        /// Formats target string with number of arguments. Equivalent of String.Format.
        /// </summary>
        /// <param name="format">Target string.</param>
        /// <param name="arg0">Argument 1.</param>
        /// <param name="arg1">Argument 2.</param>
        /// <returns>Formatted string.</returns>
        [DebuggerStepThrough]
        public static String FormatWith(this String format, Object arg0, Object arg1)
        {
            return String.Format(format, arg0, arg1);
        }

        /// <summary>
        /// Formats target string with number of arguments. Equivalent of String.Format.
        /// </summary>
        /// <param name="format">Target string.</param>
        /// <param name="arg0">Argument 1.</param>
        /// <param name="arg1">Argument 2.</param>
        /// <param name="arg2">Argument 3.</param>
        /// <returns>Formatted string.</returns>
        [DebuggerStepThrough]
        public static String FormatWith(this String format, Object arg0, Object arg1, Object arg2)
        {
            return String.Format(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Formats target string with number of arguments. Equivalent of String.Format.
        /// </summary>
        /// <param name="format">Target string.</param>
        /// <param name="args">Arguments.</param>
        /// <returns>Formatted string.</returns>
        [DebuggerStepThrough]
        public static String FormatWith(this String format, params Object[] args)
        {
            return String.Format(format, args);
        }

        /// <summary>
        /// Formats target string with number of arguments. Equivalent of String.Format.
        /// </summary>
        /// <param name="format">Target string.</param>
        /// <param name="provider">Format provider.</param>
        /// <param name="args">Arguments.</param>
        /// <returns>Formatted string.</returns>
        [DebuggerStepThrough]
        public static String FormatWith(this String format, IFormatProvider provider, params Object[] args)
        {
            return String.Format(provider, format, args);
        }

        /// <summary>
        /// Checks that target string is null or empty.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <returns>True if empty. False otherwise.</returns>
        [DebuggerStepThrough]
        public static Boolean IsEmpty(this String target)
        {
            return String.IsNullOrEmpty(target);
        }

        /// <summary>
        /// Checks that target string is not null or empty.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <returns>True if not empty. False otherwise.</returns>
        [DebuggerStepThrough]
        public static Boolean IsNotEmpty(this String target)
        {
            return IsEmpty(target) == false;
        }

        /// <summary>
        /// Returns empty string if target string is null or string itself.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <returns>Empty string if null or target string.</returns>
        [DebuggerStepThrough]
        public static String NullSafe(this String target)
        {
            return target == null ? String.Empty : target;
        }

        /// <summary>
        /// Converts the string to snake case style (HelloWorld -> hello_world). The string will have underscore (_) in front of each upper case letter.
        /// The function does not remove spaces and does not make string lower case.
        /// </summary>
        public static String ConvertToSnakeCase(this String target)
        {
#if !PORTABLE
            return Concat(target.Select((ch, index) => index > 0 && Char.IsUpper(ch) ? "_" + ch.ToString() : ch.ToString()));
#else
            StringBuilder sb = new StringBuilder(target.Length + 4);
            for (Int32 index = 0; index < target.Length; index++)
            {
                sb.Append(index > 0 && Char.IsUpper(target[index]) ? "_" + target[index].ToString() : target[index].ToString());
            }
            return sb.ToString();
#endif
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
            return StringExtensions.Join(separator, values.Where(x => x.IsNotEmpty()));
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
            return StringExtensions.Join(separator, values.Where(x => x.IsNotEmpty()));
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
    }
}
