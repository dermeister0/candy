//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;
    using System.Data;

    /// <summary>
    /// Session factory abstraction.
    /// </summary>
    public interface ISessionFactory
    {
        /// <summary>
        /// Creates session with specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">Isolation level.</param>
        /// <returns>Session.</returns>
        ISession Create(IsolationLevel isolationLevel);

        /// <summary>
        /// Creates session with default isolation level.
        /// </summary>
        /// <returns>Session.</returns>
        ISession Create();
    }
}
