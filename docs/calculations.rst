Calculations
============

Hashes
------

.. class:: Hashes

    Contains set of methods based on standard library implementation to work with strings:

    .. function:: string MD5(string str)

        Produces 128-bit hash value of string. PHP-compliant. The security of the MD5 hash function is severely compromised. It is not recommended for password hashing and provided only for backward compatibility.

    .. function:: string SHA1(string str)

        Produces 160-bit hash value of string. The most widely used hasing algorithm. It is not recommended to use it for hashing now:

        .. https://community.qualys.com/blogs/securitylabs/2014/09/09/sha1-deprecation-what-you-need-to-know

    .. function:: string SHA256(string str)

        Produces 256-bit hash value of string. Variant of SHA-2. It provides good security for password hashing.

    .. function:: string SHA384(string str)

        Produces 384-bit hash value of string. Variant of SHA-2. It provides good security for password hashing.

    .. function:: string SHA512(string str)

        Produces 512-bit hash value of string. Variant of SHA-2. It provides very good security for password hashing.

    .. function:: UInt64 CRC32(string str)

        Returns CSC32 hash of string. A cyclic redundancy check (CRC) is an error-detecting code commonly used in digital networks and storage devices to detect accidental changes to raw data. Provides good hashing performance. Must not be used for sensitive data hashing (passwords, tokens, etc).

Passwords
---------

.. class:: PasswordGenerator

    The class is to generate and check passwords. Most of websites require new password on user registration, also it is useful to check that user's password is secure and ask him to change it in other case. Parameters:

    .. attribute:: PasswordLength

        Password length, default is 10.

    .. attribute:: CharacterClasses

        Is a flags set of `LowerLetters`, `UpperLetters`, `Digits`, `SpecialCharacters` and `Space`. Also `CharacterClasses` contains combinations:

            - ``AllLetters`` is a combination of `LowerLetter` and `UpperLetters`;
            - ``AlphaNumeric`` is a combination of `AllLetters` and `Digits`;
            - ``All`` is a combination of all values above, default value;

    .. attribute:: GeneratorFlags

        Contains following flags:

            - ``None`` none of flags will be used, default value;
            - ``ExcludeLookAlike`` exclude conflict characters, for example i and l, 0 and O, 1 and l;
            - ``ShuffleChars`` shuffles the whole characters pool before password generation;
            - ``MakeReadOnly`` the flag is itended to be used for SecureString only, make it read only;

    .. function:: void SetCharactersPool(string pool)

        Use custom characters pool instead of default one. If this parameter is set generation does not take into account ``CharacterClasses`` property.

    .. function:: void UseDefaultCharactersPool()

        Resets character pool. Custom characters pool will not be used.

    .. function:: string Generate()

        Generates new password based on defined parameters.

    .. function:: SecureString GenerateSecure()

        Generates new password as ``SecureString``.

    .. function:: static int EstimatePasswordStrength(string password)

        Estimates password strength. The value will be between 0 and 100. The algorithm has been copied from passwordmeter.com_ . It uses following rules to calculate total score (`n` is a password length):

        .. _passwordmeter.com: http://www.passwordmeter.com/

            - Number of characters ``+(n*4)``
            - Uppercase letters ``+((len-n)*2)``
            - Lowercase letters ``+((len-n)*2)``
            - Numbers ``+(n*4)``
            - Symbols ``+(n*6)``
            - Middle numbers or symbols ``+(n*2)``
            - Minimum 8 characters in length, contains 3/4 of the following items ``+(n*2)``:
                - Uppercase letters
                - Lowercase letters
                - Numbers
                - Symbols
            - Letters only ``-n``
            - Numbers only ``-n``
            - Repeat characters (case insensitive) ``-n``
            - Consecutive uppercase letters ``-(n*2)``
            - Consecutive lowercase letters ``-(n*2)``
            - Consecutive numbers ``-(n*2)``
            - Sequential letters (3+) ``-(n*3)``
            - Sequential numbers (3+) ``-(n*3)``
            - Sequential symbols (3+) ``-(n*3)``

        Here is a table to determine complexity based on score:

        ============= ==============
        Score Range   Description
        ============= ==============
         0 - 19       Very weak
        20 - 39       Weak
        40 - 59       Good
        60 - 79       Strong
        79 - 100      Very strong
        ============= ==============
