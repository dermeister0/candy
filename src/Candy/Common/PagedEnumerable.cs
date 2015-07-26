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

    /// <summary>
    /// Paged enumerable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> inner;
        private readonly Int32 totalCount;

        /// <summary>
        /// Total items count.
        /// </summary>
        public Int32 TotalCount
        {
            get { return this.totalCount; }
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="inner">Enumerable.</param>
        /// <param name="totalCount">Total count. If below zero it will be calculated by inner.Count() call.</param>
        public PagedEnumerable(IEnumerable<T> inner, int totalCount = -1)
        {
            this.inner = inner;
            this.totalCount = totalCount > 0 ? totalCount : inner.Count();
        }

        /// <summary>
        /// Returns enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
