//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Candy.Extensions;
    using Candy.Helpers;

    /// <summary>
    /// Contains various check methods. If condition is false it generates exception.
    /// </summary>
    public static class Check
    {
        [DebuggerStepThrough]
        public static void IsNotEmpty(Guid argument, String argumentName)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException("\"{0}\" cannot be empty guid.".FormatWith(argumentName), argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotEmpty(String argument, String argumentName)
        {
            if (StringHelpers.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException("\"{0}\" cannot be empty string.".FormatWith(argumentName), argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotOutOfLength(String argument, Int32 length, String argumentName)
        {
            if (argument.Trim().Length > length)
            {
                throw new ArgumentException("\"{0}\" cannot be more than {1} character.".FormatWith(argumentName, length), argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNull(object argument, String argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(Int32 argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Int32 argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(Int64 argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Int64 argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(Single argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Single argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(Decimal argument, String argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(Decimal argument, String argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotInPast(DateTime argument, String argumentName)
        {
            if (argument < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotInPast(DateTime argument, String argumentName, DateTime date)
        {
            if (argument < date)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotInFuture(DateTime argument, String argumentName)
        {
            if (argument > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotInFuture(DateTime argument, String argumentName, DateTime date)
        {
            if (argument > date)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(TimeSpan argument, String argumentName)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(TimeSpan argument, String argumentName)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotEmpty<T>(ICollection<T> argument, String argumentName)
        {
            IsNotNull(argument, argumentName);

            if (argument.Count == 0)
            {
                throw new ArgumentException("Collection cannot be empty.", argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotOutOfRange(Int32 argument, Int32 min, Int32 max, String argumentName)
        {
            if ((argument < min) || (argument > max))
            {
                throw new ArgumentOutOfRangeException(argumentName, "{0} must be between \"{1}\"-\"{2}\".".FormatWith(argumentName, min, max));
            }
        }

        [DebuggerStepThrough]
        public static void IsNotInvalidEmail(String argument, String argumentName)
        {
            IsNotEmpty(argument, argumentName);

            if (CheckConstants.EmailExpression.IsMatch(argument))
            {
                throw new ArgumentException("\"{0}\" is not a valid email address.".FormatWith(argumentName), argumentName);
            }
        }
    }
}
