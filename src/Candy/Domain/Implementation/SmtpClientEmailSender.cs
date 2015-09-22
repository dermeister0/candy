//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Domain.Implementation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using Candy.Common;
    using Candy.Domain;
    using Candy.Extensions;
    using Candy.Helpers;
    using Candy.Validation;

    /// <summary>
    /// Send email using smtp protocol.
    /// </summary>
    public class SmtpClientEmailSender : IEmailSender
    {
        private Boolean async = false;
        private Boolean throwException = true;
        private List<String> approvedAddresses = new List<String>() { "*" };

        public class EmailSenderEventArgs : EventArgs
        {
            public MailMessage MailMessage { get; private set; }

            public EmailSenderEventArgs(MailMessage mailMessage)
            {
                this.MailMessage = mailMessage;
            }
        }

        public SmtpClientEmailSender(Boolean async = false)
        {
            this.async = async;
            this.Client = new SmtpClient();
            this.Client.SendCompleted += SendCompletedCallback;
        }

        public SmtpClientEmailSender(SmtpClient smtpClient, Boolean async = false, Boolean throwException = true)
        {
            Check.IsNotNull(smtpClient, "smtpClient");
            this.Client = smtpClient;
            this.async = async;
            this.throwException = throwException;
            this.Client.SendCompleted += SendCompletedCallback;
        }

        /// <summary>
        /// Gets approved addresses. Emails that do not match to these address patterns will not be sent.
        /// Default is * (all addresses approved).
        /// </summary>
        public IEnumerable<String> ApprovedAddresses
        {
            get { return approvedAddresses; }
        }

        /// <summary>
        /// Is asynchronous mode used.
        /// </summary>
        /// <value><c>true</c> if asynchronous mode is used; otherwise, <c>false</c>.</value>
        public Boolean IsAsync
        {
            get { return this.async; }
        }

        /// <summary>
        /// Whether throw exception during message send.
        /// </summary>
        /// <value><c>true</c> if throw exception; otherwise, <c>false</c>.</value>
        public Boolean ThrowException
        {
            get { return this.throwException; }
        }

        /// <summary>
        /// Gets instance of SmtpClient.
        /// </summary>
        public SmtpClient Client { get; private set; }

        /// <summary>
        /// Occurs before mail message send.
        /// </summary>
        public event EventHandler<EmailSenderEventArgs> OnBeforeSend;

        /// <summary>
        /// Occurs after mail message send.
        /// </summary>
        public event EventHandler<EmailSenderEventArgs> OnAfterSend;

        /// <summary>
        /// Occurs when SmtpException raised during mail message send.
        /// </summary>
        public event EventHandler<EmailSenderEventArgs> OnError;

        /// <summary>
        /// Adds approved emails. You can use ? and * symbols.
        /// </summary>
        public void AddApprovedEmails(String emails)
        {
            Check.IsNotEmpty(emails, "emails");
            var parsedEmails = emails.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var email in parsedEmails)
            {
                var item = email.ToLowerInvariant().Trim();
                if (item.IsEmpty())
                {
                    continue;
                }

                if (!approvedAddresses.Contains(item))
                {
                    approvedAddresses.Add(item);
                }
            }
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        public void Send(MailMessage mailMessage)
        {
            FilterAddress(mailMessage.To);
            FilterAddress(mailMessage.CC);
            FilterAddress(mailMessage.Bcc);

            if (mailMessage.To.Any() || mailMessage.CC.Any() || mailMessage.Bcc.Any())
            {
                Event.Raise(new EmailSenderEventArgs(mailMessage), this, ref OnBeforeSend);
                try
                {
                    if (async)
                    {
                        Client.SendAsync(mailMessage, null);
                    }
                    else
                    {
                        Client.Send(mailMessage);
                        Event.Raise(new EmailSenderEventArgs(mailMessage), this, ref OnAfterSend);
                    }
                }
                catch (SmtpException)
                {
                    Event.Raise(new EmailSenderEventArgs(mailMessage), this, ref OnError);
                    if (this.throwException)
                        throw;
                }
            }
        }

        /// <summary>
        /// Filters the collection of addresses by approved addresses.
        /// </summary>
        private void FilterAddress(MailAddressCollection addressCollection)
        {
            var badAddresses = new MailAddressCollection();

            foreach (var address in addressCollection)
            {
                bool match = false;
                foreach (var pattern in approvedAddresses)
                {
                    if (Regex.IsMatch(address.Address, StringHelpers.WildcardToRegex(pattern)))
                    {
                        match = true;
                    }
                }

                if (!match)
                {
                    badAddresses.Add(address);
                }
            }

            foreach (var badAddress in badAddresses)
            {
                addressCollection.Remove(badAddress);
            }
        }

        private void SendCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            MailMessage mailMessage = (MailMessage) e.UserState;

            if (e.Error != null)
            {
                Event.Raise(new EmailSenderEventArgs(mailMessage), this, ref OnError);
            }
            else
            {
                Event.Raise(new EmailSenderEventArgs(mailMessage), this, ref OnAfterSend);
            }
        }
    }
}
