FlowsUtils
==========

Contains method to affect application flow. 

.. function:: T Retry<T>(Func<T> action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
.. function:: void Retry(Action action, Int32 numberOfTries = 3, TimeSpan? delay = null, params Type[] exceptionsTypes)
    
    Every call of action retries up to numberOfTries times if any subclass of exceptions occures. There is a delay between calls.

.. function:: void Raise<TEventArgs>(object sender, TEventArgs e, ref EventHandler<TEventArgs> eventDelegate)

    Helps to raise event handlers.

    If you develop your own class with events it is not handy to raise it. You should check whther it is null. Even in that case your code is not thread safe. This method makes these two checks and calls event. Example:

        .. code-block:: c#

            // without Candy, not thread safe
            if (TestEvent != null)
                TestEvent(sender, eventArgs);

            // with Candy
            FlowsUtils.Raise(eventArgs, sender, ref TestEvent);

.. function:: void RaiseAll<TEventArgs>(object sender, TEventArgs e, ref EventHandler<TEventArgs> eventDelegate)

    Helps to raise event for all handlers. If any exception would occure the `AggregateException` will be thrown. In case of .NET 3.5 only first exception will be thrown.
