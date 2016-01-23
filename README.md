Candy
=====

A collect of practical tools and extensions to make development easier. You can overview the library and read the docs. Works with .NET 3.5, .NET 4.0, .NET 4.5 and Mono.

Go to documentation page to see more!

https://candynet.readthedocs.org

Installation
------------

```
PM> Install-Package Candy
```

Overview
--------

Here are some examples to use. Calculate SHA256 hash for password:

```cs
Security.SHA256("mypassword");
```

Set of functions to parse or get value or default:

```cs
StringExtensions.ParseDefault("incorrect", 1); // returns 1
StringExtensions.ParseDefault("incorrect", false) // returns false
dict.GetValueDefault(5, "default") // default if dict has no 5 key
```

Format string:

```cs
"{0} + {1} = {2}".FormatWith(2, 2, 4)  // returns "2 + 2 = 4"
```

String handy extensions to check for empty/not empty that easier to read:

```cs
if (str.IsNotEmpty()) ...
if (str.IsEmpty()) ...
dbuser.name = user.name.NullSafe() ...
```

Chunk select:

```cs
foreach (var item in list.ChunkSelect(50)) ...  // returns items from source by 50
```
