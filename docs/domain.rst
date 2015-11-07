Domain
======

The namespace contains set of classes and interfaces that can be used as infrastructure for your project. You can use these abstractions if you follow Domain Driver Design approach and want to keep Persistence Ignorance.

DomainException
---------------

.. class:: DomainException

    Inherit form this class your exceptions related to business logic of your application.

ValidationException
-------------------

.. class:: ValidationException

    Inherit from this class all your exceptions related to business logic validation of your application. These messages can be shown to user. ValidationException is a child of ``DomainException``.

ILogger
-------

.. class:: ILogger

    Logging abstraction to separate your logging infrastructure. For implementation you can use NLog or log4net. The interface is pretty simple and contains following methods:

    .. function:: void Fatal(string message)

        Logs fatal message. Usually after that message application cannot run correctly anymore.

    .. function:: void Error(string message)

        Logs error message.

    .. function:: void Warn(string message)

        Logs warning message. Application may run well but unusual action happened.

    .. function:: void Info(string message)

        Logs info message.

    .. function:: void Debug(string message)

        Logs debug message. These messages usually available in debug mode.

    .. function:: void Trace(string message)

        Logs trace message.

.. class:: DummyLogger

    The class is in `Candy.Domain.Implementation` namespace. Provides empty implementation for debug purposes.

.. class:: SmtpClientEmailSender

    The class is in `Candy.Domain.Implementation` namespace. Uses `SmtpClient` to send messages with additional functionality.

    .. attribute:: bool IsAsync

        Is async mode is used.

    .. attribute:: bool ThrowException

        Throw exception outside the class if it occurs during message send.

    .. attribute:: Client

        Current `SmtpClient`.

    .. attribute:: event OnBeforeSend

    Occurs before mail message send.

    .. attribute:: event OnAfterSend

    Occurs after mail message send.

    .. attribute:: event OnError

    Occurs when SmtpException raised during mail message send.

    ..attribute:: IEnumerable<String> ApprovedAddresses

    Gets approved addresses. Emails that do not match to these address patterns will not be sent. All email address are approved by default.

    ..function:: void AddApprovedEmails(String emails)

    Add email address patterns to approve list. `*` can be used. Example:

        .. code-block:: c#

            // add my personal email and all emails from saritasa domain
            EmailSender.AddApprovedEmails('personal@gmail.com *@saritasa.com');

IRepository
-----------

.. class:: IRepository

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

.. class:: ISession

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

.. class:: ISessionFactory

    To create ``ISession`` there should be specific session factory.

    .. function:: ISession Create(IsolationLevel isolationLevel)

        Creates session with specified isolation level.

    .. function:: ISession Create()

        Creates session with default isolation level. Usually read commited.

IUnitOfWork
-----------

.. class:: IUnitOfWork

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

.. class:: IUnitOfWorkFactory

    ``IUnitOfWork`` should be instantiated by this class 

    .. function:: IUnitOfWork Create(IsolationLevel isolationLevel)

        Creates unit of work with specified isolation level.

    .. function:: IUnitOfWork Create()

        Creates unit of work with default isolation level. Usually read commited.
