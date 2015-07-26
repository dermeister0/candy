//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// Dictionary helpers.
    /// </summary>
    public static class DictionaryHelpers
    {
        /// <summary>
        /// Converts dictionary key-value pairs to string. Example:
        /// Input: Key=1, Value="abc"; Key=2, Value="bca"
        /// Output: 1=abc,2=bca
        /// </summary>
        /// <param name="target">Target dictionary.</param>
        /// <returns>Result string.</returns>
        public static String AsCommaSeparatedString<TKey, TValue>(IDictionary<TKey, TValue> target)
        {
            return StringHelpers.Join(",", target.Select(x => x.Key + "=" + x.Value));
        }
    }
}
