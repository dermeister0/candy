//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain.Exceptions
{
    using System;

    /// <summary>
    /// Validation exception.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class ValidationException : DomainException
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public ValidationException() : base()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public ValidationException(String message) : base(message)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public ValidationException(String message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
