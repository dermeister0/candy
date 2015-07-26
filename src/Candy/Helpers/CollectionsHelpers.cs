//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Collection helpers.
    /// </summary>
    public static class CollectionsHelpers
    {
        /// <summary>
        /// Breaks a list of items into chunks of a specific size.
        /// </summary>
        /// <param name="source">Source list.</param>
        /// <param name="chunkSize">Chunk size.</param>
        /// <returns>Enumeration of iterators.</returns>
        public static IEnumerable<IEnumerable<T>> ChunkSelectRange<T>(IEnumerable<T> source, int chunkSize = 1000)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }

        /// <summary>
        /// Breaks a list of items into chunks of a specific size. Be aware that this method generates one additional
        /// sql query to get total number of collection elements.
        /// </summary>
        /// <param name="source">Source list.</param>
        /// <param name="chunkSize">Chunk size.</param>
        /// <returns>Enumeration of queryables.</returns>
        public static IEnumerable<IQueryable<T>> ChunkSelectRange<T>(IQueryable<T> source, int chunkSize = 1000)
        {
            long totalNumberOfElements = source.LongCount();
            int currentPosition = 0;
            while (totalNumberOfElements > currentPosition)
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
                currentPosition += chunkSize;
            }
        }

        /// <summary>
        /// Breaks a list of items into chunks of a specific size and yeilds T items.
        /// </summary>
        /// <param name="source">Source list.</param>
        /// <param name="chunkSize">Chunk size.</param>
        /// <returns>Items of type T.</returns>
        public static IEnumerable<T> ChunkSelect<T>(IEnumerable<T> source, int chunkSize = 1000)
        {
            var currentPosition = 0;
            var subsource = source;
            Boolean hasRecords = false;
            do
            {
                subsource = source.Skip(currentPosition).Take(chunkSize);
                hasRecords = false;
                foreach (var item in subsource)
                {
                    hasRecords = true;
                    yield return item;
                }
                currentPosition += chunkSize;
            }
            while (hasRecords);
        }

        /// <summary>
        /// Breaks a list of items into chunks of a specific size and yeilds T items.
        /// </summary>
        /// <param name="source">Source list.</param>
        /// <param name="chunkSize">Chunk size.</param>
        /// <returns>Items of type T.</returns>
        public static IEnumerable<T> ChunkSelect<T>(IQueryable<T> source, int chunkSize = 1000)
        {
            var currentPosition = 0;
            var subsource = source;
            Boolean hasRecords = false;
            do
            {
                subsource = source.Skip(currentPosition).Take(chunkSize);
                hasRecords = false;
                // actual query is here
                foreach (var item in subsource)
                {
                    hasRecords = true;
                    yield return item;
                }
                currentPosition += chunkSize;
            }
            while (hasRecords);
        }

        /// <summary>
        /// ForEach extension for IEnumerable of T. It's equivalence to foreach loop.
        /// </summary>
        /// <param name="target">Target collection.</param>
        /// <param name="action">Action for execute on each item.</param>
        public static void Walk<T>(IEnumerable<T> target, Action<T> action)
        {
            foreach (T item in target)
            {
                action(item);
            }
        }

        /// <summary>
        /// Get paged result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Common.PagedEnumerable<T> GetPage<T>(IEnumerable<T> source, int page, int pageSize)
        {
            return new Common.PagedEnumerable<T>(source.Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}
