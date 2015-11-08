//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;
    using Common;
    using Extensions;

    [TestFixture]
    public class CommonTest
    {
        [Serializable]
        private class InvalidUserException : Common.ExceptionArgs
        {
        }

        private event EventHandler<EventArgs> TestEvent;

        [Test]
        [ExpectedException(typeof(Exception<InvalidUserException>), ExpectedMessage = "test")]
        public void TestExceptionHelperCreationAndThrowing()
        {
            throw new Exception<InvalidUserException>("test");
        }

        [Test]
        public void TestEventCall()
        {
            int sender = 10;
            EventArgs eventArgs = new EventArgs();
            Event.Raise(eventArgs, sender, ref TestEvent);

            if (TestEvent != null)
            {
                TestEvent(sender, eventArgs);
            }
        }

        [Test]
        public void TestSwap()
        {
            int a = 2;
            int b = 5;
            Objects.Swap(ref a, ref b);
            Assert.That(a, Is.EqualTo(5));
            Assert.That(b, Is.EqualTo(2));
        }

        [Test]
        public void TestPagedEnumerable()
        {
            int capacity = 250;
            IList<int> list = new List<int>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            var pagedList = new PagedEnumerable<int>(list, 10, 10);
            Assert.That(pagedList.TotalPages, Is.EqualTo(25), "pagedList - incorrect TotalPages");

            var pagedList2 = new PagedEnumerable<int>(list, 10, 10);
            Assert.That(pagedList2.Count(), Is.EqualTo(10), "pagedList2 - incorrect Count");

            var pagedList3 = list.GetPaged(13, 25);
            Assert.That(pagedList3.TotalPages, Is.EqualTo(10), "pagedList3 - incorrect TotalPages");
            Assert.That(pagedList3.CurrentPage, Is.EqualTo(13), "pagedList3 - incorrect CurrentPage");

            var pagedList4 = list.GetPaged(20, 13);
            Assert.That(pagedList4.TotalPages, Is.EqualTo(20), "pagedList4 - incorrect TotalPages");
            Assert.That(pagedList4.Count(), Is.EqualTo(3), "pagedList4 - incorrect Count");
        }

        /// <summary>
        /// Custom exception for tests only.
        /// </summary>
        private class CustomException : ApplicationException
        {
            public CustomException()
            {
            }
        }

        private void CustomMethodNoReturn()
        {
        }

        private Int32 CustomMethodReturn()
        {
            return 123;
        }

        private Int32 CustomMethodReturnWithCustomException()
        {
            throw new CustomException();
        }

        [Test]
        public void TestFlowRepeat()
        {
            Flow.Repeat<Int32>(CustomMethodReturn);
            Flow.Repeat<Int32>(CustomMethodReturn, Int32.MaxValue, TimeSpan.MaxValue);

            Assert.DoesNotThrow(() => Flow.Repeat<Int32>(CustomMethodReturnWithCustomException));
            Assert.Throws<CustomException>(() => Flow.Repeat<Int32>(CustomMethodReturnWithCustomException, 3, null,
                new[] { typeof(InvalidOperationException) }));
            Assert.DoesNotThrow(() => Flow.Repeat<Int32>(CustomMethodReturnWithCustomException, 3, null,
               new[] { typeof(CustomException) }));

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Flow.Repeat<Int32>(CustomMethodReturnWithCustomException, 3, TimeSpan.FromMilliseconds(50), new [] { typeof(CustomException) });
            stopwatch.Stop();
            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(150));
        }
    }
}
