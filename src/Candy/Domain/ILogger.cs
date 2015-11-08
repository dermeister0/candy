//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Logger abstraction.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Fatal(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log fatal message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Fatal(String message, Exception exception, [CallerFilePath] string sourceFilePath = null);

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Error(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Error(String message, Exception exception, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Warn(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Warn(String message, Exception exception, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Info(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Info(String message, Exception exception, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Debug(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Debug(String message, Exception exception, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        void Trace(String message, [CallerFilePath] String sourceFilePath = null);

        /// <summary>
        /// Log trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        void Trace(String message, Exception exception, [CallerFilePath] String sourceFilePath = null);
    }

#if !NET4_5 && !MONO
    /// Just fake implementation.
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerFilePathAttribute : Attribute
    {
        /// <summary>
        /// Allows you to obtain the full path of the source file that contains the caller.
        /// This is the file path at the time of compile.
        /// </summary>
        public CallerFilePathAttribute()
        {
        }
    }
#endif
}
