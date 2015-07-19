//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;

    /// <summary>
    /// Logger abstraction.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(String message);

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(String message);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(String message);

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(String message);

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(String message);

        /// <summary>
        /// Log trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Trace(String message);
    }
}
