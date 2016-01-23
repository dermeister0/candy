﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain.Implementation
{
    using System.Net.Mail;
    using Domain.Interfaces;

    /// <summary>
    /// Empty email sender. Can be used for testing.
    /// </summary>
    public class DummyEmailSender : IEmailSender
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Send(MailMessage message)
        {
        }
    }
}
