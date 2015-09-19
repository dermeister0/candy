//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Validation;

    /// <summary>
    /// Paged enumerable.
    /// </summary>
    /// <typeparam name="T">Source type.</typeparam>
    public class PagedEnumerable<T> : IEnumerable<T>
    {
        public const Int32 DefaultCurrentPage = 1;
        public const Int32 DefaultPageSize = 100;

        private readonly IEnumerable<T> source;
        private readonly Int32 totalPages;
        private readonly Int32 currentPage;
        private readonly Int32 pageSize;

        /// <summary>
        /// Total pages.
        /// </summary>
        public Int32 TotalPages
        {
            get { return this.totalPages; }
        }

        /// <summary>
        /// Current page. Starts from 1.
        /// </summary>
        public Int32 CurrentPage
        {
            get { return this.currentPage; }
        }

        /// <summary>
        /// Page size. Max number of items on page.
        /// </summary>
        public Int32 PageSize
        {
            get { return this.pageSize; }
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source">Enumerable.</param>
        /// <param name="page">Current page. Default is 1.</param>
        /// <param name="pageSize">Page size. Default is 100.</param>
        /// <param name="totalPages">Total pages. If below zero it will be calculated.</param>
        public PagedEnumerable(
            IEnumerable<T> source,
            Int32 page = DefaultCurrentPage,
            Int32 pageSize = DefaultPageSize,
            Int32 totalPages = -1)
        {
            Check.IsNotNull(source, "source");
            Check.IsNotNegativeOrZero(pageSize, "pageSize");
            Check.IsNotNegativeOrZero(page, "page");

            this.source = source;
            this.currentPage = page;
            this.pageSize = pageSize;
            this.totalPages = totalPages > 0 ? totalPages : GetTotalPages(source, PageSize);
        }

        /// <summary>
        /// Create paged enumerable from source and query source list by page and pageSize.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source">Enumerable.</param>
        /// <param name="page">Page to select. Default is first.</param>
        /// <param name="pageSize">Page size. Default is 100.</param>
        public static PagedEnumerable<T> Create(
            IEnumerable<T> source,
            Int32 page = DefaultCurrentPage,
            Int32 pageSize = DefaultPageSize)
        {
            var filteredSource = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new PagedEnumerable<T>(filteredSource, page, pageSize, GetTotalPages(source, pageSize));
        }

        private static Int32 GetTotalPages(IEnumerable<T> source, Int32 pageSize)
        {
            return (source.Count() + pageSize - 1) / pageSize;
        }

        /// <summary>
        /// Returns enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
