//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Candy.Extensions;
    
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void FormatTest()
        {
            Assert.That("{0} + {1} = {2}".FormatWith(2, 2, 4), Is.EqualTo("2 + 2 = 4"));
        }

        [Test]
        public void TestDictionaryDefaultValue()
        {
            Dictionary<int, string> dict = new Dictionary<int,string>();
            dict.Add(1, "abc");
            dict.Add(2, "bca");
            Assert.That(dict.TryGetValueDefault(5, "default"), Is.EqualTo("default"));
            Assert.That(dict.TryGetValueDefault(1, "abc"), Is.EqualTo("abc"));
        }
    }
}
