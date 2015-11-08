//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Common
{
    using System;
    
    /// <summary>
    /// Provides methods to control execution flow.
    /// </summary>
    public class Flow
    {
        static internal Type[] AnyExcepton = new Type[] { typeof(Exception) };

        /// <summary>
        /// Every call of action retries up to numberOfTries times if any subclass of exceptions
        /// occures. There is a delay between calls.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <param name="numberOfTries">Number of tries. Default is 3.</param>
        /// <param name="exceptions">Set of exceptions on which repeat occures. If null retry will appear on any exception.</param>
        /// <returns>Specified user type.</returns>
        public static T Repeat<T>(Func<T> action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
        {
            if (exceptionsTypes == null || exceptionsTypes.Length == 0)
            {
                exceptionsTypes = Flow.AnyExcepton;
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
                        if (executedExceptionType.Equals(exceptionType) || executedExceptionType.IsSubclassOf(exceptionType))
                        {
                            isSubclass = true;
                            break;
                        }
                    }
                    if (isSubclass == false)
                        throw;
                    System.Threading.Thread.Sleep(delay.Value.Milliseconds);
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
        /// <param name="exceptions">Set of exceptions on which repeat occures. If null retry will appear on any exception.</param>
        public static void Repeat(Action action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
        {
            Flow.Repeat<object>(() =>
            {
                action();
                return null;
            });
        }
    }
}
