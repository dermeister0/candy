//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Validation
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Various constants for validation.
    /// </summary>
    public static class CheckConstants
    {
#if !PORTABLE
        internal const RegexOptions Options = RegexOptions.Singleline | RegexOptions.Compiled;
#else
        internal const RegexOptions Options = RegexOptions.Singleline;
#endif

        /// <summary>
        /// Email check regular expression.
        /// </summary>
        public static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", Options);
        
        /// <summary>
        /// Web url check regular expression.
        /// </summary>
        public static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", Options);

        /// <summary>
        /// Regular expression to strip html tags.
        /// </summary>
        public static readonly Regex StripHtmlExpression = new Regex("<\\S[^><]*>", Options | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);
    }
}
