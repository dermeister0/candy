Extensions
==========

The Candy namespace contains extension methods for various classes.

CollectionsExtensions
---------------------

.. class:: CollectionsExtensions

    Set of extensions related to collections (`IEnumerable`, `IList`, etc).

    .. function:: static IOrderedEnumerable<TSource> Order<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortOrder sortOrder)

        Extension to order enumerable by asc or desc order. ``Ask`` and ``Desc`` are ``SortOrder`` enum members.

    .. function:: static Common.PagedEnumerable<T> GetPaged<T>(IEnumerable<T> source, int page, int pageSize)

        Get paged enumeration. See ``PagedEnumerable`` class for more reference.

    .. function:: IEnumerable<IEnumerable<T>> ChunkSelectRange<T>(IEnumerable<T> source, int chunkSize)

        Breaks a list of items into chunks of a specific size and yeilds T items. Default ``chunkSize`` is 1000.

    .. function:: IEnumerable<T> ChunkSelect<T>(IEnumerable<T> source, int chunkSize)

        Breaks a list of items into chunks of a specific size and yeilds T items. Default ``chunkSize`` is 1000.

    .. function:: void Walk<T>(IEnumerable<T> target, Action<T> action)

        Implements foreach loop with Action. Action does something with each item of collection. Since there is a tacit agreement that linq extensions should not change collection items it is implemented as helper method. Default chunk size is 1000. For example you can use it like this:

            .. code-block:: c#

                foreach (var user in Users) {
                    user.FirstName = StringExtensions.Capitalize(user.FirstName);
                }

                // can be replaced

                Users.Walk(u => { u.FirstName = StringExtensions.Capitalize(u.FirstName) });

DictionaryExtensions
--------------------

.. class:: DictionaryExtensions

    Set of extensions related to `IDictionary`.

    .. function:: TValue GetValueDefault<TKey, TValue>(IDictionary<TKey, TValue> target, TKey key, TValue defaultValue)

    Tries to get the value by key. If key is not presented to dictionary returns ``defaultValue``.

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

MailExtensions
--------------

.. class:: MailExtensions

    .. function:: void Save(MailMessage message, string fileName)

        Saves MailMessage to file. There are no standard methods in .NET to save MailMessage to file. The only way to do that is to define ``mailSettings`` in config. This methods uses reflection to call internal methods to save message to file.

DateTimeExtensions
------------------

.. class:: DateTimeExtensions

    .. function:: Boolean IsHoliday(DateTime target)

        Just checkes is this a Saturday or Sunday.

    .. function:: DateTime BeginOfMonth(DateTime target)

        Returns begin of month for specified date.

    .. function:: DateTime EndOfMonth(DateTime target)

        Returns end of month for specified date.
