Objects
=======

Methods to work with plain CLR objects.

.. function:: static void Swap<T>(ref T item1, ref T item2)

    Swaps two variables by their referencies.

    .. code-block:: c#

        // without Candy, new variable needed
        int a = 2, b = 5;
        int tmp = a;
        a = b;
        b = tmp;

        // with Candy
        int a = 2, b = 5;
        Objects.Swap(ref a, ref b);
