//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Sort order enumeration.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Ascending order of sort.
        /// </summary>
        Asc = 0,

        /// <summary>
        /// Descending order of sort.
        /// </summary>
        Desc = 1,
    }

    /// <summary>
    /// Collections extensions.
    /// </summary>
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Sorts the elements of a sequence in ascending or descending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <returns>An System.Linq.IOrderedEnumerable whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Asc ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending or descending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">An System.Collections.Generic.IComparer to compare keys.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <returns>An System.Linq.IOrderedEnumerable whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Asc ? source.OrderBy(keySelector, comparer) : source.OrderByDescending(keySelector, comparer);
        }
    }
}
