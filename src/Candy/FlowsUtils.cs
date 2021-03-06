﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy
{
    using System;
    using System.Collections.Generic;
#if PORTABLE
    using System.Reflection;
#endif

    /// <summary>
    /// Provides methods to control execution flow.
    /// </summary>
    public class FlowsUtils
    {
        private static readonly Type[] AnyExcepton = new Type[] { typeof(Exception) };

        /// <summary>
        /// Every call of action retries up to numberOfTries times if any subclass of exceptions
        /// occures. There is a delay between calls.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <param name="numberOfTries">Number of tries. Default is 3.</param>
        /// <param name="delay">Delays between action calls. Default is none.</param>
        /// <param name="exceptionsTypes">Set of exceptions on which repeat occures. If null retry will appear on any exception.</param>
        /// <returns>Specified user type.</returns>
        public static T Retry<T>(Func<T> action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
        {
            if (exceptionsTypes == null || exceptionsTypes.Length == 0)
            {
                exceptionsTypes = FlowsUtils.AnyExcepton;
            }
            if (delay == null)
            {
                delay = TimeSpan.Zero;
            }

            for (Int32 retry = 0; retry < numberOfTries; retry++)
            {
                try
                {
                    return action();
                }
                catch (Exception executedException)
                {
                    Boolean isSubclass = false;
                    Type executedExceptionType = executedException.GetType();
                    foreach (var exceptionType in exceptionsTypes)
                    {
#if PORTABLE
                        if (executedExceptionType.Equals(exceptionType) || executedExceptionType.GetTypeInfo().IsSubclassOf(exceptionType))
#else
                        if (executedExceptionType.Equals(exceptionType) || executedExceptionType.IsSubclassOf(exceptionType))
#endif
                        {
                            isSubclass = true;
                            break;
                        }
                    }
                    if (isSubclass == false)
                    {
                        throw;
                    }
#if PORTABLE
                    System.Threading.Tasks.Task.Delay(delay.Value.Milliseconds).Wait();
#else
                    System.Threading.Thread.Sleep(delay.Value.Milliseconds);
#endif
                }
            }
            return default(T);
        }

        /// <summary>
        /// Every call of action retries up to numberOfTries times if any subclass of exceptions
        /// occures. There is a delay between calls.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <param name="numberOfTries">Number of tries. Default is 3.</param>
        /// <param name="delay">Delays between action calls. Default is none.</param>
        /// <param name="exceptionsTypes">Set of exceptions on which repeat occures. If null retry will appear on any exception.</param>
        public static void Retry(Action action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
        {
            FlowsUtils.Retry<object>(
                () =>
                {
                    action();
                    return null;
                },
                numberOfTries,
                delay,
                exceptionsTypes
            );
        }

        /// <summary>
        /// It is null-safe and thread-safe way to raise event.
        /// </summary>
        public static void Raise<TEventArgs>(object sender, TEventArgs e, ref EventHandler<TEventArgs> eventDelegate)
#if NET4_0 || NET3_5
            where TEventArgs : EventArgs
#endif
        {
#if NET4_5 || MONO
            var temp = System.Threading.Volatile.Read(ref eventDelegate);
#else
            var temp = eventDelegate;
    #if !PORTABLE
            System.Threading.Thread.MemoryBarrier();
    #endif
#endif
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        /// <summary>
        /// It is null-safe and thread-safe way to raise event. The method calls every handler related to event.
        /// If any handler throws an error the AggregateException will be thrown.
        /// </summary>
        public static void RaiseAll<TEventArgs>(object sender, TEventArgs e, ref EventHandler<TEventArgs> eventDelegate)
#if NET4_0 || NET3_5
            where TEventArgs : EventArgs
#endif
        {
#if NET4_5 || MONO
            var temp = System.Threading.Volatile.Read(ref eventDelegate);
#else
            var temp = eventDelegate;
    #if !PORTABLE
            System.Threading.Thread.MemoryBarrier();
    #endif
#endif
            if (temp == null)
            {
                return;
            }

            var exceptions = new List<Exception>();
            foreach (var handler in temp.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(sender, e);
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    exceptions.Add(ex.InnerException);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 0)
            {
#if !NET3_5
                throw new AggregateException(exceptions);
#else
                throw exceptions[0];
#endif
            }
        }
    }
}
