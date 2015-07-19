Calculations
============

Hashes
------

Contains set of methods based on standard library implementation to work with strings:

* `String MD5(String str)` Returns MD5 hash of string. PHP-compliant. Useful for passwords hashing.

* `String SHA1(String str)` Returns SHA1 hash of string. Useful for passwords hashing.

* `String SHA256(String str)` Returns SHA256 hash of string. Useful for passwords hashing.

* `String SHA384(String str)` Returns SHA384 hash of string. Useful for passwords hashing.

* `String SHA512(String str)` Returns SHA512 hash of string. Useful for passwords hashing.

* `UInt64 CRC32(String str)` Returns CSC32 hash of string. Useful for integrity check.

PasswordGenerator
-----------------

The class is to generate and check passwords. Most of websites require new password on register, also it is useful to check that user's password is secure and ask him to change it in other case. Parameters:

* `PasswordLength` Password length, default is 10.

* `CharacterClasses` Is a flags set of `LowerLetters`, `UpperLetters`, `Digits`, `SpecialCharacters` and `Space`. Also `CharacterClasses` contains combinations:

    - `AllLetters` is a combination of `LowerLetter` and `UpperLetters`;
    - `AlphaNumeric` is a combination of `AllLetters` and `Digits`;
    - `All` is a combination of all values above, default value;

* `GeneratorFlags` Contains following flags:

    - `None` none of flags will be used, default value;
    - `ExcludeLookAlike` exclude conflict characters, for example i and l, 0 and O, 1 and l;
    - `ShuffleChars` shuffles the whole characters pool before password generation;
    - `MakeReadOnly` the flag is itended to be used for SecureString only, make it read only;

* `void SetCharactersPool(String pool)` Use custom characters pool instead of default one. If this parameter is set generation does not take into account `CharacterClasses` property.

* `void UseDefaultCharactersPool()` Resets character pool. Custom characters pool will not be used.

* `String Generate()` Generates new password based on defined parameters.

* `SecureString GenerateSecure()` Generates new password as `SecureString`.

* `static Int32 EstimatePasswordStrength(String password)` Estimates password strength. The algorithm has been copied from www.passwordmeter.com. It uses following rules to calculate total score (`n` is a password length):

    - Number of characters `+(n*4)`
    - Uppercase letters `+((len-n)*2)`
    - Lowercase letters `+((len-n)*2)`
    - Numbers `+(n*4)`
    - Symbols `+(n*6)`
    - Middle numbers or symbols `+(n*2)`
    - Minimum 8 characters in length, contains 3/4 of the following items `+(n*2)`:
        - Uppercase letters
        - Lowercase letters
        - Numbers
        - Symbols
    - Letters only `-n`
    - Numbers only `-n`
    - Repeat characters (case insensitive) `-n`
    - Consecutive uppercase letters `-(n*2)`
    - Consecutive lowercase letters `-(n*2)`
    - Consecutive numbers `-(n*2)`
    - Sequential letters (3+) `-(n*3)`
    - Sequential numbers (3+) `-(n*3)`
    - Sequential symbols (3+) `-(n*3)`
