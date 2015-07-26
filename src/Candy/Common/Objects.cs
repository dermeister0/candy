//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Common
{
    using System;
    
    /// <summary>
    /// Common helpers related to various classes of .NET .
    /// </summary>
    public static class Objects
    {
        /// <summary>
        /// Swaps two variables by references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">Variable 1.</param>
        /// <param name="item2">Variable 2.</param>
        public static void Swap<T>(ref T item1, ref T item2)
        {
            T tmp = item1;
            item1 = item2;
            item2 = tmp;
        }
    }
}
