//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using NUnit.Framework;
    using Candy.Validation;
    
    [TestFixture]
    public class ValidationTest
    {
        [Test]
        public void TestEmails()
        {
            Assert.That(CheckConstants.EmailExpression.IsMatch("fwd2ivan@yandex.ru"), Is.True);
            Assert.That(CheckConstants.EmailExpression.IsMatch("fwd2ivan+label@yandex.ru"), Is.True);
            Assert.That(CheckConstants.EmailExpression.IsMatch("fwd2ivanyandex.ru"), Is.False);
            Assert.That(CheckConstants.EmailExpression.IsMatch("2fwd2ivan@yandex.ru"), Is.True);
            Assert.That(CheckConstants.EmailExpression.IsMatch("2fwd2ivan@yandex"), Is.False);
            Assert.That(CheckConstants.EmailExpression.IsMatch("@yandex.ru"), Is.False);
            Assert.That(CheckConstants.EmailExpression.IsMatch("fwd2ivan@"), Is.False);
            Assert.That(CheckConstants.EmailExpression.IsMatch("ivan+ivan@kras.saritas.local"), Is.True);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArgumentNullValidation()
        {
            object obj = null;
            Check.IsNotNull(obj, "obj");
        }
    }
}
