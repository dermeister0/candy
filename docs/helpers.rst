Helpers
=======

Namespace contains helpers implemented as static methods. You can use them like this `using CandyHelpers = Candy.Helpers`.

CollectionsHelpers
------------------

.. function:: static IEnumerable<IEnumerable<T>> ChunkSelectRange<T>(IEnumerable<T> source, int chunkSize = 1000)

.. function:: static IEnumerable<T> ChunkSelect<T>(IEnumerable<T> source, int chunkSize = 1000)

.. function:: void Walk<T>(IEnumerable<T> target, Action<T> action)

    Implements foreach loop with Action. Action does something with each item of collection. Since there is a tacit agreement that linq extensions should not change collection items it is implemented as helper method. For example you can use it like this:

        .. code-block:: csharp

            foreach (var user in Users) {
                user.FirstName = StringHelpers.Capitalize(user.FirstName);
            }

            // can be replaced

            Users.Walk(u => { u.FirstName = StringHelpers.Capitalize(u.FirstName) });

.. function:: IEnumerable<T> Page<T>(IEnumerable<T> source, int page, int pageSize)

DateTimeHelpers
---------------

.. function:: Boolean IsHoliday(DateTime target)

    Just checkes is this a Saturday or Sunday.

.. function:: DateTime BeginOfMonth(DateTime target)

    Returns begin of month for specified date.

.. function:: DateTime EndOfMonth(DateTime target)

    Returns end of month for specified date.

DictionaryHelpers
-----------------

.. function:: String AsCommaSeparatedString<TKey, TValue>(IDictionary<TKey, TValue> target)

    Converts dictionary key-value pairs to stirng. Example:

    Input: Key=1, Value="abc"; Key=2, Value="bca"
    Output: 1=abc,2=bca

MailHelpers
-----------

.. function:: void Save(MailMessage message, string fileName)

    Saves MailMessage to file. There are no standard methods in .NET to save MailMessage to file. The only way to do that is to define ``mailSettings`` in config. This methods uses reflection to call internal methods to save message to file.

RandomHelpers
-------------

Thread-safe equivalent of System.Random, using just static methods.

.. function:: int Next()

.. function:: int Next(int max)

.. function:: int Next(int min, int max)

.. function:: double NextDouble()

.. function:: void NextBytes(byte[] buffer)

StringHelpers
-------------

.. function:: String ConvertToSnakeCase(String target)

    Converts string to snake case string style. Example: HelloWorld -> hello_world.

.. function:: Boolean IsEmail(String target)

    Returns true if strign is email address. Uses ``CheckConstants.EmailExpression`` regexp to check.

.. function:: String Truncate(String target, int maxLength)

    Truncates target string to max length. Useful to do not allow string to exceed specific amount of character.

.. function:: String JoinIgnoreEmpty(String separator, params String[] values)
              String JoinIgnoreEmpty(String separator, IEnumerable<String> values)

.. function:: String WildcardToRegex(String pattern)

    Converts wildcard characters to regexp string. For example `He*ll? -> He\*ll\?`.

.. function:: bool IsNullOrWhiteSpace(String value)

    This is equivalent of String.IsNullOrWhiteSpace for .NET 3.5 .

.. function:: bool IsNullOrEmpty(String value)

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
Method Name                                      Input Type   Type Alias
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

.. function:: T TryParseEnumDefault<T>(String target, T defaultValue)

    Convert string value to enum value or return default

.. function:: T TryParseEnumDefault<T>(String target, Boolean ignoreCase, T defaultValue)

    Convert string value to enum value or return default.
