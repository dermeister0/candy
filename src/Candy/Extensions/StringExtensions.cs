//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// String class extensions.
    /// </summary>
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
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Boolean IsEmpty(this String target)
        {
            return String.IsNullOrEmpty(target);
        }

        /// <summary>
        /// Checks that target strign is not null or empty.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Boolean IsNotEmpty(this String target)
        {
            return IsEmpty(target) == false;
        }
    }
}
