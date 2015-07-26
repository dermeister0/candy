//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Unit of work and repository abstraction. Can be used if you need just an abstraction around database context.
    /// </summary>
    public interface ISession : IDisposable
    {
        /// <summary>
        /// Get all entities. Returns queryable object.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="include">What inner properties to include with query.</param>
        /// <returns>Entities.</returns>
        IQueryable<TEntity> GetAll<TEntity>(string include = "") where TEntity : class;
 
        /// <summary>
        /// Get entity by id. For value types there will be boxing.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity instance.</returns>
        TEntity Get<TEntity>(object id) where TEntity : class;
 
        /// <summary>
        /// Mark entity to add.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity instance.</param>
        void MarkAdded<TEntity>(TEntity entity) where TEntity : class;
 
        /// <summary>
        /// Mark entity to remove.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity instance.</param>
        void MarkRemoved<TEntity>(TEntity entity) where TEntity : class;
 
        /// <summary>
        /// Attach entity to current context. Utilizes ORM level implementation.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity instance.</param>
        void Attach<TEntity>(TEntity entity) where TEntity : class;
 
        /// <summary>
        /// Commit changes. If not called explicitly the changes will be 
        /// </summary>
        void Commit();
    }
}
