﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    /// <summary>
    /// Common helpers related to various classes of .NET .
    /// </summary>
    public static class AtomicUtils
    {
        /// <summary>
        /// Swaps values of two variables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">Variable 1.</param>
        /// <param name="item2">Variable 2.</param>
#if !NET3_5 && !NET4_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Swap<T>(ref T item1, ref T item2)
        {
            T tmp = item1;
            item1 = item2;
            item2 = tmp;
        }

        private static readonly object LockObject = new object();

        /// <summary>
        /// Swaps values of two variables. Thread safe implementation.
        /// </summary>
        /// <typeparam name="T">Variables type.</typeparam>
        /// <param name="item1">Variable 1.</param>
        /// <param name="item2">Variable 2.</param>
#if !NET3_5 && !NET4_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void SafeSwap<T>(ref T item1, ref T item2)
        {
            lock (LockObject)
            {
                T tmp = item1;
                item1 = item2;
                item2 = tmp;
            }
        }

        #region CAS

        /// <summary>
        /// Thread safe implementation CAS (Compare-And-Swap).
        /// Get the location variable from memory, perform an action on it and replace.
        /// </summary>
        /// <typeparam name="T">Input and output variable type.</typeparam>
        /// <param name="location">Input and output variable.</param>
        /// <param name="func">Function to perform action on variable.</param>
        public static void DoWithCAS<T>(ref T location, Func<T, T> func)
            where T : class
        {
            T temp, replace;
            do
            {
                temp = location;
                replace = func(temp);
            }
            while (Interlocked.CompareExchange(ref location, replace, temp) != temp);
        }

        /// <summary>
        /// Thread safe implementation CAS (Compare-And-Swap).
        /// Get the location variable from memory, perform an action on it and replace.
        /// </summary>
        /// <param name="location">Input and output variable.</param>
        /// <param name="func">Function to perform action on variable.</param>
        public static void DoWithCAS(ref int location, Func<int, int> func)
        {
            int temp, replace;
            do
            {
                temp = location;
                replace = func(temp);
            }
            while (Interlocked.CompareExchange(ref location, replace, temp) != temp);
        }

        /// <summary>
        /// Thread safe implementation CAS (Compare-And-Swap).
        /// Get the location variable from memory, perform an action on it and replace.
        /// </summary>
        /// <param name="location">Input and output variable.</param>
        /// <param name="func">Function to perform action on variable.</param>
        public static void DoWithCAS(ref double location, Func<double, double> func)
        {
            double temp, replace;
            do
            {
                temp = location;
                replace = func(temp);
            }
            while (Interlocked.CompareExchange(ref location, replace, temp) != temp);
        }

        #endregion
    }
}
