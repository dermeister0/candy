SecurityUtils
=============

Contains set of methods based on standard library implementation to work with strings:

.. function:: string MD5(string str)

    Produces 128-bit hash value of string. PHP-compliant. The security of the MD5 hash function is severely compromised. It is not recommended for password hashing and provided only for backward compatibility.

.. function:: string Sha1(string str)

    Produces 160-bit hash value of string. The most widely used hasing algorithm. It is not recommended to use it for hashing now:

    .. https://community.qualys.com/blogs/securitylabs/2014/09/09/sha1-deprecation-what-you-need-to-know

.. function:: string Sha256(string str)

    Produces 256-bit hash value of string. Variant of SHA-2. It provides good security for password hashing.

.. function:: string Sha384(string str)

    Produces 384-bit hash value of string. Variant of SHA-2. It provides good security for password hashing.

.. function:: string Sha512(string str)

    Produces 512-bit hash value of string. Variant of SHA-2. It provides very good security for password hashing.

.. function:: UInt64 Crc32(string str)

    Returns CSC32 hash of string. A cyclic redundancy check (CRC) is an error-detecting code commonly used in digital networks and storage devices to detect accidental changes to raw data. Provides good hashing performance. Must not be used for sensitive data hashing (passwords, tokens, etc).
