//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Candy;
    
    [TestFixture]
    public class CommonTest
    {
        [Serializable]
        private class InvalidUserException : Common.ExceptionArgs { }

        private event EventHandler<EventArgs> TestEvent;

        [Test]
        [ExpectedException(typeof(Common.Exception<InvalidUserException>), ExpectedMessage = "test")]
        public void TestExceptionHelperCreationAndThrowing()
        {
            throw new Common.Exception<InvalidUserException>("test");
        }

        [Test]
        public void TestEventCall()
        {
            int sender = 10;
            EventArgs eventArgs = new EventArgs();
            Common.EventHelpers.Raise(eventArgs, sender, ref TestEvent);

            if (TestEvent != null)
                TestEvent(sender, eventArgs);
        }

        [Test]
        public void TestSwap()
        {
            int a = 2;
            int b = 5;
            Common.Objects.Swap(ref a, ref b);
            Assert.That(a, Is.EqualTo(5));
            Assert.That(b, Is.EqualTo(2));
        }

        [Test]
        public void TestPagedHelper()
        {
            int capacity = 250;
            IList<int> list = new List<int>();
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            var pagedList = new Common.PagedEnumerable<int>(list);
            Assert.That(pagedList.TotalCount, Is.EqualTo(capacity));
        }
    }
}
