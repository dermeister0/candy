Helpers
=======

Namespace contains helpers implemented as static methods. You can use them like this `using CandyHelpers = Candy.Helpers`.

CollectionsHelpers
------------------

.. class:: CollectionsHelpers

    Set of helpers related to collections (`IEnumerable`, `IList`, etc).

    .. function:: IEnumerable<IEnumerable<T>> ChunkSelectRange<T>(IEnumerable<T> source, int chunkSize)

    Breaks a list of items into chunks of a specific size and yeilds T items.

    .. function:: IEnumerable<T> ChunkSelect<T>(IEnumerable<T> source, int chunkSize)

    Breaks a list of items into chunks of a specific size and yeilds T items.

    .. function:: void Walk<T>(IEnumerable<T> target, Action<T> action)

        Implements foreach loop with Action. Action does something with each item of collection. Since there is a tacit agreement that linq extensions should not change collection items it is implemented as helper method. Default chunk size is 1000. For example you can use it like this:

            .. code-block:: csharp

                foreach (var user in Users) {
                    user.FirstName = StringHelpers.Capitalize(user.FirstName);
                }

                // can be replaced

                Users.Walk(u => { u.FirstName = StringHelpers.Capitalize(u.FirstName) });

DateTimeHelpers
---------------

.. class:: DateTimeHelpers

    .. function:: Boolean IsHoliday(DateTime target)

        Just checkes is this a Saturday or Sunday.

    .. function:: DateTime BeginOfMonth(DateTime target)

        Return begin of month for specified date.

    .. function:: DateTime EndOfMonth(DateTime target)

        Return end of month for specified date.

DictionaryHelpers
-----------------

.. class:: DictionaryHelpers

    .. function:: String AsCommaSeparatedString<TKey, TValue>(IDictionary<TKey, TValue> target)

        Converts dictionary key-value pairs to stirng. Example:

        Input: Key=1, Value="abc"; Key=2, Value="bca"
        Output: 1=abc,2=bca

MailHelpers
-----------

.. class:: MailHelpers

    .. function:: void Save(MailMessage message, string fileName)

        Saves MailMessage to file. There are no standard methods in .NET to save MailMessage to file. The only way to do that is to define ``mailSettings`` in config. This methods uses reflection to call internal methods to save message to file.

RandomHelpers
-------------

.. class:: RandomHelpers

    Thread-safe equivalent of System.Random, using just static methods.

    .. function:: int Next()

        Returns a nonnegative random number.

    .. function:: int Next(int max)

        Returns a nonnegative random number less than the specified maximum.

    .. function:: int Next(int min, int max)

        Returns a random number within a specified range.

    .. function:: double NextDouble()

        Returns a random number between 0.0 and 1.0.

    .. function:: void NextBytes(byte[] buffer)

        Fills the elements of a specified array of bytes with random numbers.

StringHelpers
-------------

.. class:: StringHelpers

    .. function:: string ConvertToSnakeCase(string target)

        Converts string to snake case string style. Example: HelloWorld -> hello_world.

    .. function:: bool IsEmail(string target)

        Returns true if strign is email address. Uses ``CheckConstants.EmailExpression`` regexp to check.

    .. function:: string Truncate(string target, int maxLength)

        Truncates target string to max length. Useful to do not allow string to exceed specific amount of character.

    .. function:: string JoinIgnoreEmpty(string separator, params string[] values)
                  string JoinIgnoreEmpty(string separator, IEnumerable<string> values)

    .. function:: string WildcardToRegex(sring pattern)

        Converts wildcard characters to regexp string. For example `He*ll? -> He\*ll\?`.

    .. function:: bool IsNullOrWhiteSpace(string value)

        This is equivalent of String.IsNullOrWhiteSpace for .NET 3.5 .

    .. function:: bool IsNullOrEmpty(string value)

        This is equivalent of String.IsNullOrEmpty for .NET 3.5 .

StringHelpers - Parsing
-----------------------

Sometimes when we try to convert some type from string to another one (`int.Parse` for example) we don't need to know if is it possible to do that or not. Having default value in that case is good for us. This set of methods `TryParseXDefault` try to parse input value and if it is not possible return default one.

    .. code-block:: csharp

        // with standard library:
        int val = 0;
        if (!int.TryParse("1q", out val))
            val = 1;

        // with Candy:
        Candy.Helpers.StringHelpers.TryParseInt32Default("1q", 1);

================================================ ============ ==========
Method Name                                      Output Type  Type Alias
================================================ ============ ==========
``TryParseBooleanDefault``                       Boolean      bool
``TryParseByteDefault``                          Byte         byte
``TryParseCharDefault``                          Char         char
``TryParseDateTimeDefault``                      DateTime
``TryParseDecimalDefault``                       Decimal      decimal
``TryParseDoubleDefault``                        Double       double
``TryParseInt16Default``                         Int16        short
``TryParseInt32Default``                         Int32        int
``TryParseInt64Default``                         Int64        long
``TryParseSByteDefault``                         SByte        sbyte
``TryParseSingleDefault``                        Single       float
``TryParseUInt16Default``                        UInt16       ushort
``TryParseUInt32Default``                        UInt32       uint
``TryParseUInt64Default``                        UInt64       ulong
``TryParseEnumDefault``                          Enum
================================================ ============ ==========

.. class:: StringHelpers

    .. function:: T TryParseEnumDefault<T>(string target, T defaultValue)

        Convert string value to enum value or return default

    .. function:: T TryParseEnumDefault<T>(string target, bool ignoreCase, T defaultValue)

        Convert string value to enum value or return default.
