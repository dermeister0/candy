Extensions
==========

The namespace contains extension methods for various classes.

CollectionsExtensions
---------------------

.. class:: CollectionsExtensions

    Set of extensions related to collections (`IEnumerable`, `IList`, etc).

    .. function:: static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortOrder sortOrder)

        Sort extension to order enumerable by asc or desc.

    .. function:: static Common.PagedEnumerable<T> GetPaged<T>(this IEnumerable<T> source, int page, int pageSize)

        Get paged enumeration. See `Common.PagedEnumerable` class for more reference.

DictionaryExtensions
--------------------

.. class:: DictionaryExtensions

    Set of extensions related to `IDictionary`.

    .. function:: TValue TryGetValueDefault<TKey, TValue>(IDictionary<TKey, TValue> target, TKey key, TValue defaultValue)

    Tried to get the value by key. If key is not presented to dictionary returns `defaultValue`.

EnumExtensions
--------------

.. class:: EnumExtensions

    .. function:: String GetDescription(Enum target)

        Returns the value of DescriptionAttribute attribute.

    .. function:: Boolean HasFlag(Enum target, Enum flag)

        Only for .NET 3.5 . Checks whether the flag for enum is specified.

StringExtensions
----------------

.. class:: StringExtensions

    These are extension methods that applied to String type.

    .. function:: String.FormatWith(params Object[] args)

        With this extension you can easly append parameters to any string.

            .. code-block:: c#

                // without Candy:
                Console.WriteLine(String.Format("The sum of {1} and {2} is {3}", a, b, sum));

                // with Candy:
                Console.WriteLine("The sum of {1} and {2} is {3}".FormatWith(a, b, sum));

    .. function:: Boolean String.IsEmpty()

        Returns true if string is empty. Without Candy you have to write ``String.IsNullOrEmpty(str)``.

    .. function:: Boolean String.IsNotEmpty()

        Returns true if string is not empty. Without Candy you have to write ``!String.IsNullOrEmpty(str)``.

    .. function:: String String.NullSafe()

        Returns empty string if target string is empty or string itself. It is the same as ``(mystring ?? "")``.
