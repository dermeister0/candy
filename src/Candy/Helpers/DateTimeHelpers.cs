//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Helpers
{
    using System;

    /// <summary>
    /// Helper methods for DateTime class.
    /// </summary>
    public static class DateTimeHelpers
    {
        /// <summary>
        /// Just checks is this a Saturday or Sunday.
        /// </summary>
        /// <param name="target">DateTime to check.</param>
        /// <returns>Is holiday.</returns>
        public static Boolean IsHoliday(DateTime target)
        {
            return target.DayOfWeek == DayOfWeek.Saturday || target.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Returns begin of month for specified date.
        /// </summary>
        /// <param name="target">The date to get year and month.</param>
        /// <returns>Begin of month date.</returns>
        public static DateTime BeginOfMonth(DateTime target)
        {
            return new DateTime(target.Year, target.Month, 1);
        }

        /// <summary>
        /// Returns end of month for specified date.
        /// </summary>
        /// <param name="target">The date to get year and month.</param>
        /// <returns>End of month date.</returns>
        public static DateTime EndOfMonth(DateTime target)
        {
            return target.AddMonths(1).AddMilliseconds(-1);
        }
    }
}
