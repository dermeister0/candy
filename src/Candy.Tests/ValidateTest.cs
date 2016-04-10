//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class ValidateTest
    {
        [Test]
        public void TestEmails()
        {
            Assert.DoesNotThrow(() => { ValidateUtils.IsNotInvalidEmail("fwd2ivan@yandex.ru", "test"); });
            Assert.DoesNotThrow(() => { ValidateUtils.IsNotInvalidEmail("fwd2ivan+label@yandex.ru", "test"); });
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => { ValidateUtils.IsNotInvalidEmail("fwd2ivanyandex.ru", "test"); });
            Assert.DoesNotThrow(() => { ValidateUtils.IsNotInvalidEmail("2fwd2ivan@yandex.ru", "test"); });
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => { ValidateUtils.IsNotInvalidEmail("2fwd2ivan@yandex", "test"); });
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => { ValidateUtils.IsNotInvalidEmail("@yandex.ru", "test"); });
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => { ValidateUtils.IsNotInvalidEmail("fwd2ivan@", "test"); });
            Assert.DoesNotThrow(() => { ValidateUtils.IsNotInvalidEmail("ivan+ivan@kras.saritas.local", "test"); });
        }

        [Test]
        public void TestArgumentNullValidation()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                ValidateUtils.IsNotNull(obj, "obj");
            });
        }
    }
}
