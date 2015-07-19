﻿//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;

    /// <summary>
    /// Exception occures in domain part of application. It can be logic or validation exception.
    /// </summary>
    [Serializable]
    public class DomainException : ApplicationException
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException() : base()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException(String message) : base(message)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException(String message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
