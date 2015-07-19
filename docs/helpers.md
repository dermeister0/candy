Helpers
=======

Namespace contains helpers implemented as static methods. You can use them like this `using CandyHelpers = Candy.Helpers`.

CollectionsHelpers
------------------

* `static IEnumerable<IEnumerable<T>> ChunkSelectRange<T>(IEnumerable<T> source, int chunkSize = 1000)`

* `static IEnumerable<T> ChunkSelect<T>(IEnumerable<T> source, int chunkSize = 1000)`

* `void Walk<T>(IEnumerable<T> target, Action<T> action)` Implements foreach loop with Action. Action does something with each item of collection. Since there is a tacit agreement that linq extensions should not change collection items it is implemented as helper method. For example you can use it like this:

```cs
foreach (var user in Users) {
    user.FirstName = StringHelpers.Capitalize(user.FirstName);
}

// can be replaced...

Users.Walk(u => { u.FirstName = StringHelpers.Capitalize(u.FirstName) });
```

* `IEnumerable<T> Page<T>(IEnumerable<T> source, int page, int pageSize)`

DateTimeHelpers
---------------

* `Boolean IsHoliday(DateTime target)` Just checkes is this a Saturday or Sunday.

* `DateTime BeginOfMonth(DateTime target)` Returns begin of month for specified date.

* `DateTime EndOfMonth(DateTime target)` Returns end of month for specified date.

DictionaryHelpers
-----------------

* `String AsCommaSeparatedString<TKey, TValue>(IDictionary<TKey, TValue> target)` Converts dictionary key-value pairs to stirng. Example:
Input: Key=1, Value="abc"; Key=2, Value="bca"
Output: 1=abc,2=bca

MailHelpers
-----------

* `void Save(MailMessage message, string fileName)` Saves MailMessage to file.
There are no standard methods in .NET to save MailMessage to file. The only way to do that is to define `mailSettings` in config. This methods uses reflection to call internal methods to save message to file.

RandomHelpers
-------------

Thread-safe equivalent of System.Random, using just static methods.

* `int Next()`

* `int Next(int max)`

* `int Next(int min, int max)`

* `double NextDouble()`

* `void NextBytes(byte[] buffer)`

StringHelpers
-------------

* `String ConvertToSnakeCase(String target)` Converts string to snake case string style. Example: HelloWorld -> hello_world.

* `Boolean IsEmail(String target)` Returns true if strign is email address. Uses `CheckConstants.EmailExpression` regexp to check.

* `String Truncate(String target, int maxLength)` Truncates target string to max length. Useful to do not allow string to exceed specific amount of character.

* `String JoinIgnoreEmpty(String separator, params String[] values)`

* `String JoinIgnoreEmpty(String separator, IEnumerable<String> values)`

* `String WildcardToRegex(String pattern)` Converts wildcard characters to regexp string. For example `He*ll? -> He\*ll\?`.

* `bool IsNullOrWhiteSpace(String value)` This is equivalent of String.IsNullOrWhiteSpace for .NET 3.5 .

* `bool IsNullOrEmpty(String value)` This is equivalent of String.IsNullOrEmpty for .NET 3.5 .

StringHelpers - Parsing
-----------------------

Sometimes when we try to convert some type from string to another one (`int.Parse` for example) we don't need to know if is it possible to do that or not. Having default value in that case is good for us. This set of methods `TryParseXDefault` try to parse input value and if it is not possible return default one.

With standard library:

```cs
int val = 0;
if (!int.TryParse("1q", out val))
    val = 1;
```

With Candy:

```cs
Candy.Helpers.StringHelpers.TryParseInt32Default("1q", 1);
```

* `Boolean TryParseBooleanDefault(String target, Boolean defaultValue)`

* `Byte TryParseByteDefault(String target, Byte defaultValue)`

* `Byte TryParseByteDefault(String target, NumberStyles style, IFormatProvider provider, Byte defaultValue)`

* `Char TryParseCharDefault(String target, Char defaultValue)`

* `DateTime TryParseDateTimeDefault(String target, DateTime defaultValue)`

* `DateTime TryParseDateTimeDefault(String target, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)`

* `Decimal TryParseDecimalDefault(String target, Decimal defaultValue)`

* `Decimal TryParseDecimalDefault(String target, NumberStyles style, IFormatProvider provider, Decimal defaultValue)`

* `Double TryParseDoubleDefault(String target, Double defaultValue)`

* `Double TryParseDoubleDefault(String target, NumberStyles style, IFormatProvider provider, Double defaultValue)`

* `Int16 TryParseInt16Default(String target, Int16 defaultValue)`

* `Int16 TryParseInt16Default(String target, NumberStyles style, IFormatProvider provider, Int16 defaultValue)`

* `Int32 TryParseInt32Default(String target, Int32 defaultValue)`

* `Int32 TryParseInt64Default(String target, NumberStyles style, IFormatProvider provider, Int32 defaultValue)`

* `Int64 TryParseInt64Default(String target, Int64 defaultValue)`

* `Int64 TryParseInt64Default(String target, NumberStyles style, IFormatProvider provider, Int64 defaultValue)`

* `SByte TryParseSByteDefault(String target, SByte defaultValue)`

* `SByte TryParseSByteDefault(String target, NumberStyles style, IFormatProvider provider, SByte defaultValue)`

* `Single TryParseSingleDefault(String target, Single defaultValue)`

* `Double TryParseSingleDefault(String target, NumberStyles style, IFormatProvider provider, Single defaultValue)`

* `UInt16 TryParseUInt16Default(String target, UInt16 defaultValue)`

* `UInt16 TryParseUInt16Default(String target, NumberStyles style, IFormatProvider provider, UInt16 defaultValue)`

* `UInt32 TryParseUInt32Default(String target, UInt32 defaultValue)`

* `UInt32 TryParseUInt64Default(String target, NumberStyles style, IFormatProvider provider, UInt32 defaultValue)`

* `UInt64 TryParseUInt64Default(String target, UInt64 defaultValue)`

* `UInt64 TryParseUInt64Default(String target, NumberStyles style, IFormatProvider provider, UInt64 defaultValue)`

* `T TryParseEnumDefault<T>(String target, T defaultValue)` Convert string value to enum value or return default.

* `T TryParseEnumDefault<T>(String target, Boolean ignoreCase, T defaultValue)` Convert string value to enum value or return default.
