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

.. function:: void Fatal(String message)

.. function:: void Error(String message)

.. function:: void Warn(String message)

.. function:: void Info(String message)

.. function:: void Debug(String message)

.. function:: void Trace(String message)

IRepository
-----------

.. function:: IEnumerable<TEntity> GetAll<TEntity>()

.. function:: TEntity Get<TEntity>(object id)

.. function:: void Add<TEntity>(TEntity entity)

.. function:: void Remove<TEntity>(TEntity entity)

ISession
--------

Session is an unit of work and repository abstraction.

.. function:: IQueryable<T> GetAll<T>(string include)

    Gets queriable list of specified entities.

.. function:: T Get<T>(object id)

    Get entity by id.

.. function:: void MarkAdded<T>(T entity)

    Mark entity as added to unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void MarkRemoved<T>(T entity)

    Math entity as removed to unit of work. Call `Commit` to send changes to data storage.

.. function:: void Attach<T>(T entity)

    Attach entity to unit of work. Usually it is the same as attach object to data context.

.. function:: void Commit()

    Send changes to data storage.

ISessionFactory
---------------

To create session the factory should be used.

.. function:: ISession Create(IsolationLevel isolationLevel)

    Creates session with specified isolation level.

.. function:: ISession Create()

    Creates session with default isolation level. Usually read commited.

IUnitOfWork
-----------

Unit of work abstraction. Can be used to implement Entity Framwork or NHibernate implementations. The inherit class must implement:

.. function:: void MarkAdded<T>(T entity)

    Mark entity as added to unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void MarkRemoved<T>(T entity)

    Math entity as removed to unit of work. Call ``Commit`` to send changes to data storage.

.. function:: void Attach<T>(T entity)

    Attach entity to unit of work. Usually it is the same as attach object to data context.

.. function:: void Commit()

    Send changes to data storage.

IUnitOfWorkFactory
------------------

To create unit of work factory should be used.

.. function:: IUnitOfWork Create(IsolationLevel isolationLevel)

    Creates unit of work with specified isolation level.

.. function:: IUnitOfWork Create()

    Creates unit of work with default isolation level. Usually read commited.
