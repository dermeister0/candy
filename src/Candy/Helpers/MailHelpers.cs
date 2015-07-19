//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Helpers
{
    using System;
    using System.IO;
    using System.Net.Mail;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Mail helpers.
    /// </summary>
    public static class MailHelpers
    {
        /// <summary>
        /// Saves the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void Save(MailMessage message, string fileName)
        {
            Assembly assembly = typeof(SmtpClient).Assembly;
            Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                // get reflection info for MailWriter contructor
                ConstructorInfo mailWriterContructor =
                    mailWriterType.GetConstructor(
                        BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        new Type[] { typeof(Stream) }, 
                        null);

                // construct MailWriter object with our FileStream
                object mailWriter = mailWriterContructor.Invoke(new object[] { fileStream });

                // get reflection info for Send() method on MailMessage
                MethodInfo sendMethod =
                    typeof(MailMessage).GetMethod(
                        "Send",
                        BindingFlags.Instance | BindingFlags.NonPublic);

                // call method passing in MailWriter
                if (sendMethod.GetParameters().Length == 2)
                {
                    sendMethod.Invoke(
                        message,
                        BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        new object[] { mailWriter, true },
                        null);
                }
                else
                {
                    sendMethod.Invoke(
                        message,
                        BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        new object[] { mailWriter, true, true },
                        null);
                }

                // finally get reflection info for Close() method on our MailWriter
                MethodInfo closeMethod =
                    mailWriter.GetType().GetMethod(
                        "Close",
                        BindingFlags.Instance | BindingFlags.NonPublic);

                // call close method
                closeMethod.Invoke(
                    mailWriter,
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    new object[] { },
                    null);
            }
        }
    }
}
