Validation
==========

Provides common patterns to validate.

Check.Argument
--------------

Contains set of methods to write less code to defined method pre-conditions. Example:

    .. code-block:: csharp

        void CreateUser(User user, int score)
        {
            Check.IsNotNull(user, "user");
            Check.IsNotNegative(score, "score");
        }

There are methods implemented: ``IsNotEmpty``, ``IsNotOutOfLength``, ``IsNotNull``, ``IsNotNegative``, ``IsNotNegativeOrZero``, ``IsNotInPast``, ``IsNotInFuture``, ``IsNotInvalidEmail``.

CheckConstants
--------------

.. class:: CheckConstants

    Contains common validation regexp patterns.

    .. attribute:: EmailExpression (regexp)

        Email regular expression.

    .. attribute:: WebUrlExpression (regexp)

        Web url regular expression. Support http and https protocols.

    .. attribute:: StripHTMLExpression (regexp)

        Regular expression to remove html tags from string.
