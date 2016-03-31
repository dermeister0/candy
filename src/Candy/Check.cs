﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains various check methods. If condition is false it generates exception.
    /// </summary>
    public static class Check
    {
#if !PORTABLE
        internal const RegexOptions Options = RegexOptions.Singleline | RegexOptions.Compiled;
#else
        internal const RegexOptions Options = RegexOptions.Singleline;
#endif

        /// <summary>
        /// Email check regular expression.
        /// </summary>
        public static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", Options);
        
        /// <summary>
        /// Web url check regular expression.
        /// </summary>
        public static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", Options);

        /// <summary>
        /// Regular expression to strip html tags.
        /// </summary>
        public static readonly Regex StripHtmlExpression = new Regex("<\\S[^><]*>", Options | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);

        /// <summary>
        /// Is not empty check for guid. Generates ArgumentException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotEmpty(Guid argument, String argumentName)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException("\"{0}\" cannot be empty guid.".FormatWith(argumentName), argumentName);
            }
        }

        /// <summary>
        /// Is not empty check for string. Generates ArgumentException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotEmpty(String argument, String argumentName)
        {
            if (StringExtensions.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException("\"{0}\" cannot be empty string.".FormatWith(argumentName), argumentName);
            }
        }

        /// <summary>
        /// Is not out of length check. Generates ArgumentException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="length">Maximum length.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotOutOfLength(String argument, Int32 length, String argumentName)
        {
            if (argument.Trim().Length > length)
            {
                throw new ArgumentException("\"{0}\" cannot be more than {1} character.".FormatWith(argumentName, length), argumentName);
            }
        }

        /// <summary>
        /// Is not null check. Generates ArgumentNullException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNull(Object argument, String argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check for Int32. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegative(Int32 argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative or zero check. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Int32 argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check for Int64. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegative(Int64 argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check for Int64. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Int64 argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check for Single. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegative(Single argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative or zero check for Single. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Single argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check for Decimal. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegative(Decimal argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative or zero check for Decimal. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Decimal argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not in past check for DateTime. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotInPast(DateTime argument, String argumentName)
        {
            if (argument < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not in past check for DateTime according to specific date. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="date">Date to compare.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotInPast(DateTime argument, DateTime date, String argumentName)
        {
            if (argument < date)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not in future check for DateTime. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotInFuture(DateTime argument, String argumentName)
        {
            if (argument > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not in future check for DateTime according to specific date. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="date">Date to compare.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotInFuture(DateTime argument, String argumentName, DateTime date)
        {
            if (argument > date)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }
        
        /// <summary>
        /// Is not negative check for TimeSpan. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegative(TimeSpan argument, String argumentName)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not negative check or zero for TimeSpan. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(TimeSpan argument, String argumentName)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Is not empty check for collection of arguments. Generates ArgumentException.
        /// </summary>
        /// <param name="argument">Collection of arguments.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotEmpty<T>(ICollection<T> argument, String argumentName)
        {
            IsNotNull(argument, argumentName);

            if (argument.Count == 0)
            {
                throw new ArgumentException("Collection cannot be empty.", argumentName);
            }
        }

        /// <summary>
        /// Is in range check. Generates ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="argument">Collection of arguments.</param>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotOutOfRange(Int32 argument, Int32 min, Int32 max, String argumentName)
        {
            if ((argument < min) || (argument > max))
            {
                throw new ArgumentOutOfRangeException(argumentName, "{0} must be between \"{1}\"-\"{2}\".".FormatWith(argumentName, min, max));
            }
        }

        /// <summary>
        /// Is not invalid email check. Generates ArgumentException.
        /// </summary>
        /// <param name="argument">Email argument.</param>
        /// <param name="argumentName">Argument name.</param>
        [DebuggerStepThrough]
        public static void IsNotInvalidEmail(String argument, String argumentName)
        {
            IsNotEmpty(argument, argumentName);

            if (EmailExpression.IsMatch(argument))
            {
                throw new ArgumentException("\"{0}\" is not a valid email address.".FormatWith(argumentName), argumentName);
            }
        }
    }
}
