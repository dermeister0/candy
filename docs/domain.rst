Domain
======

The namespace contains set of classes and interfaces that can be used as infrastructure for your project. You can use these abstractions if you follow Domain Driver Design approach and want to keep Persistence Ignorance.

DomainException
---------------

Inherit form this class your exceptions related to business logic of your application.

ValidationException
-------------------

Inherit from this class all your exceptions related to business logic validation of your application. These messages can be shown to user. ValidationException is a child of ``DomainException``.

ILogger
-------

Logging abstraction to separate your logging infrastructure. For implementation you can use NLog or log4net. The interface is pretty simple and contains following methods:

.. function:: void Fatal(string message)

.. function:: void Error(string message)

.. function:: void Warn(string message)

.. function:: void Info(string message)

.. function:: void Debug(string message)

.. function:: void Trace(string message)

IRepository
-----------

Common repository pattern abstraction. A Repository mediates between the domain and data mapping layers, acting like an in-memory domain object collection.

.. function:: IEnumerable<TEntity> GetAll<TEntity>()

    Returns all entities of specified type.

.. function:: TEntity Get<TEntity>(object id)

    Returns specific object by id or null.

.. function:: void Add<TEntity>(TEntity entity)

    Add entity to data storage.

.. function:: void Remove<TEntity>(TEntity entity)

    Remove entity from data storage.

ISession
--------

Session is an unit of work and repository abstraction.

.. function:: IQueryable<TEntity> GetAll<TEntity>(string include)

    Return queriable list of specified entities. ``include`` is a set of properties that needs to be autoloaded with query (for example with join sql). You can use comma to specify several properties.

.. function:: TEntity Get<TEntity>(object id)

    Return entity by id or null.

.. function:: void MarkAdded<TEntity>(TEntity entity)

    Mark entity as added to unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void MarkRemoved<TEntity>(TEntity entity)

    Math entity as removed from unit of work. Call `Commit` to send changes to data storage.

.. function:: void Attach<TEntity>(TEntity entity)

    Attach entity to unit of work. Usually it is the same as attach object to data context.

.. function:: void Commit()

    Send changes to data storage.

ISessionFactory
---------------

To create ``ISession`` there should be specific session factory.

.. function:: ISession Create(IsolationLevel isolationLevel)

    Creates session with specified isolation level.

.. function:: ISession Create()

    Creates session with default isolation level. Usually read commited.

IUnitOfWork
-----------

Unit of work abstraction. Can be used to implement Entity Framwork or NHibernate implementations. The inherit class must implement:

.. function:: void MarkAdded<TEntity>(TEntity entity)

    Mark entity as added to unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void MarkRemoved<T>(TEntity entity)

    Mark entity as removed from unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void Attach<TEntity>(TEntity entity)

    Attach entity to unit of work. Usually it is the same as attach object to data context.

.. function:: void Commit()

    Save changes to data storage.

IUnitOfWorkFactory
------------------

``IUnitOfWork`` should be instantiated by this class 

.. function:: IUnitOfWork Create(IsolationLevel isolationLevel)

    Creates unit of work with specified isolation level.

.. function:: IUnitOfWork Create()

    Creates unit of work with default isolation level. Usually read commited.
