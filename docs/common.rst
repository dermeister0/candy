Common
======

The common namespace provides classes for exceptions handling and some other methods related to .NET framework.

.. class:: Event

    Event helpers.

    .. function:: void Raise<TEventArgs>(TEventArgs e, object sender, ref EventHandler<TEventArgs> eventDelegate)

        Helps to raise event handlers.

        If you develop your own class with events it is not handy to raise it. You should check whther it is null. Even in that case your code is not thread safe. This method makes these two checks and calls event. Example:

            .. code-block:: csharp

                // without Candy, not thread safe
                if (TestEvent != null)
                    TestEvent(sender, eventArgs);

                // with Candy
                EventHelpers.Raise(eventArgs, sender, ref TestEvent);

.. class:: Exception

    Usually it is not easy to create custom Exception. You should implement at least 3 default constructors, take care of serialization and custom arguments. Exception makes it easier to do:

        .. code-block:: csharp
        
            [Serializable]
            private class InvalidUserException : Common.ExceptionArgs { }

            throw new Candy.Common.Exception<InvalidUserException>("test message", innerException);

.. class:: Objects

    Set of helpers related to objects manipulations.

    .. function:: static void Swap<T>(ref T item1, ref T item2)

        Swaps two variables by their referencies.

PagedEnumerable
---------------

.. class:: PagedEnumerable

    The class helps to make paged enumerables. It wraps current page and page size. If not specified default page is first and default page size is 100. If total pages parameter is below or equal 0 it will be automatically populated with `Count()` method.

    .. function:: PagedEnumerable(IEnumerable<T> source, int page, int pageSize, int totalPages)

        Creates instance of class. There are two examples of usage:

            .. code-block:: csharp

                IEnumerable<string> list = ...
                // creates a paged list on page 2 where page size is 20
                PageEnumerable<string> pagedList = new PagedEnumerable<string>(list, 2, 20);
                // another way with extension method
                pagedList = list.GetPaged(2, 20);
                Grid.DataSource = pagedList;

    .. function:: PagedEnumerable<T> Create(IEnumerable<T> pagedSource, int page, int pageSize, int totalPages)

        Creates the instance without any queries. It only fills internal properies.
