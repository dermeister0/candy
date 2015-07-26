//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;
    using System.Linq;

    /// <summary>
    /// Unit of work abstraction.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Mark entity to add.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void MarkAdded<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Mark entity to remove.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void MarkRemoved<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Attach entity to current context. Utilizes ORM level implementation.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void Attach<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Commit changes. If not called explicitly the changes will be roll backed.
        /// </summary>
        void Commit();
    }
}
