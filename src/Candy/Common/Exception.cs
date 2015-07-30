//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Common
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Inherit from this class to have custom exception arguments.
    /// </summary>
    [Serializable]
    public abstract class ExceptionArgs
    {
        /// <summary>
        /// Message.
        /// </summary>
        public virtual String Message
        {
            get { return String.Empty; }
        }
    }

    /// <summary>
    /// The class makes it easier to create your own exception class. Usually you should inherit from Exception or other class
    /// and implement constructors and serialization. With this class you can just type
    /// public sealed class InvalidUserException : BaseExceptionArgs { }.
    /// </summary>
    /// <typeparam name="TExceptionArgs">Custom exception arguments type.</typeparam>
    [Serializable]
    public sealed class Exception<TExceptionArgs> : Exception, ISerializable where TExceptionArgs : ExceptionArgs
    {
        private const String CArgs = "Args"; // for deserialization
        private readonly TExceptionArgs args;

        /// <summary>
        /// Exception arguments.
        /// </summary>
        public TExceptionArgs Args
        {
            get { return this.args; }
        }

        /// <summary>
        /// Exception message.
        /// </summary>
        public override String Message
        {
            get
            {
                String baseMessage = base.Message;
                return this.args == null ? baseMessage : baseMessage + " (" + this.args.Message + ")";
            }
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public Exception(String message = null, Exception innerException = null) : this(null, message, innerException)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="args">Custom exception arguments.</param>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public Exception(TExceptionArgs args, String message = null, Exception innerException = null) : base(message, innerException)
        {
            this.args = args;
        }

        /// <summary>
        /// .ctor for serialization.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        private Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.args = (TExceptionArgs)info.GetValue(CArgs, typeof(TExceptionArgs));
        }

        /// <summary>
        /// .ctor for deserialization.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(CArgs, this.args);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Equals override.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <returns>Returns true if objects are equal. False otherwise.</returns>
        public override Boolean Equals(Object obj)
        {
            Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
            if (obj == null)
            {
                return false;
            }
            return Object.Equals(this.args, other.args) && base.Equals(obj);
        }

        /// <summary>
        /// Overrides hash code calculation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
