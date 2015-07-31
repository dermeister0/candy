//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain
{
    using System;
    using System.Net.Mail;

    /// <summary>
    /// Email sender interface.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Send(MailMessage message);
    }
}
