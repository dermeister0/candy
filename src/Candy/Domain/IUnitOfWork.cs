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
        /// Get all entities. Returns queryable object.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <returns>Entities.</returns>
        IQueryable<T> GetAll<T>() where T: class;

        /// <summary>
        /// Get entity by id. For value types there will be boxing.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="id">Entity id.</param>
        /// <returns></returns>
        T Get<T>(object id) where T: class;

        /// <summary>
        /// Mark entity to add.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void Add<T>(T entity) where T: class;

        /// <summary>
        /// Mark entity to remove.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void Remove<T>(T entity) where T: class;

        /// <summary>
        /// Attach entity to current context. Utilizes ORM level implementation.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        void Attach<T>(T entity) where T: class;

        /// <summary>
        /// Commit changes. If not called explicity the changes will be 
        /// </summary>
        void Commit();
    }
}
