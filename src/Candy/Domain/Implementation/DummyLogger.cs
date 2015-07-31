//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain.Implementation
{
    using System;

    /// <summary>
    /// Empty logger implementation. Can be used for testing.
    /// </summary>
    public class DummyLogger : ILogger
    {
        /// <summary>
        /// Log fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Fatal(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log fatal message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Fatal(string message, Exception exception, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Error(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Error(string message, Exception exception, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Warn(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Warn(string message, Exception exception, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Info(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Info(string message, Exception exception, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Debug(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Debug(string message, Exception exception, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sourceFilePath"></param>
        public void Trace(string message, string sourceFilePath = null)
        {
        }

        /// <summary>
        /// Log trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="sourceFilePath"></param>
        public void Trace(string message, Exception exception, string sourceFilePath = null)
        {
        }
    }
}
