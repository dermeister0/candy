//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Common
{
    using System;
#if NET4_5
    using System.Threading;
#endif
    
    /// <summary>
    /// Event helpers.
    /// </summary>
    public static class EventHelpers
    {
        /// <summary>
        /// It is null-safe and thread-safe way to raise event.
        /// </summary>
        public static void Raise<TEventArgs>(TEventArgs e, object sender, ref EventHandler<TEventArgs> eventDelegate)
            where TEventArgs : EventArgs
        {
#if NET4_5
            var temp = Volatile.Read(ref eventDelegate);
#else
            var temp = eventDelegate;
#endif
            if (temp != null)
                temp(sender, e);
        }
    }
}
