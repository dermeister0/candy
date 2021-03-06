﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// System.Enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
#if !PORTABLE
        /// <summary>
        /// Gets the value of Description attribute.
        /// </summary>
        /// <param name="target">Enum.</param>
        /// <returns>Description text.</returns>
        public static String GetDescription(this Enum target)
        {
            if (target.GetType().IsEnum == false)
            {
                throw new ArgumentOutOfRangeException("target", "Target is not enum");
            }

            FieldInfo fieldInfo = target.GetType().GetField(target.ToString());
            if (fieldInfo == null)
            {
                return null;
            }
#if NET4_5 || MONO
            IEnumerable<DescriptionAttribute> attributes = fieldInfo.GetCustomAttributes<DescriptionAttribute>(false);
#else
            IEnumerable<DescriptionAttribute> attributes = (IEnumerable<DescriptionAttribute>)
                fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
#endif

            return attributes.Any() ? attributes.First().Description : target.ToString();
        }
#endif

#if NET3_5
        /// <summary>
        /// Determines whether one or more bit fields are set in the current instance.
        /// <param name="target">Enum.</param>
        /// <param name="flag">An enumeration value.</param>
        /// </summary>
        public static Boolean HasFlag(this Enum target, Enum flag)
        {
            if (flag == null)
            {
                throw new ArgumentNullException("flag");
            }
            
            if (target.GetType() != flag.GetType())
            {
                throw new ArgumentException(
                    String.Format("The argument type, '{0}', is not the same as the enum type '{1}'.", flag.GetType(), target.GetType())
                );
            }

            ulong uflag = Convert.ToUInt64(flag);
            ulong utarget = Convert.ToUInt64(target);
            return (utarget & uflag) == uflag;
        }
#endif
    }
}
