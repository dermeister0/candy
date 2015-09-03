Common
======

The common namespace provides classes for exceptions handling and some other methods related to .NET framework.

EventRaiseHelpers
-----------------

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

Objects
-------

.. function:: static void Swap<T>(ref T item1, ref T item2)

    Swaps two variables by their referencies.
