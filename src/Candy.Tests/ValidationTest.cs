//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class ValidationTest
    {
        [Test]
        public void TestEmails()
        {
            Assert.That(Check.EmailExpression.IsMatch("fwd2ivan@yandex.ru"), Is.True);
            Assert.That(Check.EmailExpression.IsMatch("fwd2ivan+label@yandex.ru"), Is.True);
            Assert.That(Check.EmailExpression.IsMatch("fwd2ivanyandex.ru"), Is.False);
            Assert.That(Check.EmailExpression.IsMatch("2fwd2ivan@yandex.ru"), Is.True);
            Assert.That(Check.EmailExpression.IsMatch("2fwd2ivan@yandex"), Is.False);
            Assert.That(Check.EmailExpression.IsMatch("@yandex.ru"), Is.False);
            Assert.That(Check.EmailExpression.IsMatch("fwd2ivan@"), Is.False);
            Assert.That(Check.EmailExpression.IsMatch("ivan+ivan@kras.saritas.local"), Is.True);
        }

        [Test]
        public void TestArgumentNullValidation()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Check.IsNotNull(obj, "obj");
            });
        }
    }
}
