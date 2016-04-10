//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class StringTests
    {
        [Test]
        public void TestSnakeCase()
        {
            Assert.That(StringUtils.ConvertToSnakeCase("MyTestMethod"), Is.EqualTo("My_Test_Method"));
        }
    }
}
