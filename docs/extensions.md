Extensions
==========

The namespace contains extension methods for various classes.

CollectionsExtensions
---------------------
* `static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortOrder sortOrder)`
Sort extension to order enumerable by asc or desc.

DictionaryExtensions
--------------------

* `TValue TryGetValueDefault<TKey, TValue>(IDictionary<TKey, TValue> target, TKey key, TValue defaultValue)`

EnumExtensions
--------------

* `String GetDescription(Enum target)` Returns the value of DescriptionAttribute attribute.

* `Boolean HasFlag(Enum target, Enum flag)` Only for .NET 3.5 . Checked whether the flag for enum is specified.

StringExtensions
----------------

These are extension methods that applied to String type.

* `String.FormatWith(params Object[] args)` With this extension you can easly append parameters to any string.

Without Candy:

```cs
Console.WriteLine(String.Format("The sum of {1} and {2} is {3}", a, b, sum));
```

With Candy:

```cs
Console.WriteLine("The sum of {1} and {2} is {3}".FormatWith(a, b, sum));
```

* `Boolean String.IsEmpty()` Returns true if string empty. Without Candy you have to write `String.IsNullOrEmpty(str)`.

* `Boolean String.IsNotEmpty()` Returns true if string not empty. Without Candy you have to write `!String.IsNullOrEmpty(str)`.
