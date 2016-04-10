//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class CommonTest
    {
        private event EventHandler<EventArgs> EventArgsTestEvent;

        private event EventHandler<EventArgs> TestEvent;

        [Test]
        public void EventArgsTestEventCall()
        {
            int a = 10;
            EventArgs eventArgs = new EventArgs();
            EventHandler<EventArgs> testDelegate = (sender, args) =>
            {
                a = 20;
            };

            try
            {
                EventArgsTestEvent += testDelegate;
                Assert.DoesNotThrow(() => { FlowsUtils.Raise(this, eventArgs, ref EventArgsTestEvent); });
                Assert.That(a == 20, Is.True, "TestEvent was not called");
            }
            finally
            {
                EventArgsTestEvent -= testDelegate;
            }
        }

        [Test]
        public void TestSwap()
        {
            int a = 2, b = 5;
            AtomicUtils.Swap(ref a, ref b);
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
        private class CustomException : Exception
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
            FlowsUtils.Retry<Int32>(CustomMethodReturn);
            FlowsUtils.Retry<Int32>(CustomMethodReturn, Int32.MaxValue, TimeSpan.MaxValue);

            Assert.DoesNotThrow(() => FlowsUtils.Retry<Int32>(CustomMethodReturnWithCustomException));
            Assert.Throws<CustomException>(() => FlowsUtils.Retry<Int32>(CustomMethodReturnWithCustomException, 3, null, new[] { typeof(InvalidOperationException) }));
            Assert.DoesNotThrow(() => FlowsUtils.Retry<Int32>(CustomMethodReturnWithCustomException, 3, null, new[] { typeof(CustomException) }));

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            FlowsUtils.Retry<Int32>(CustomMethodReturnWithCustomException, 3, TimeSpan.FromMilliseconds(50), new[] { typeof(CustomException) });
            stopwatch.Stop();
            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(150));
        }

        [Test]
        public void TestDoWithCAS()
        {
            int a = 5;
            AtomicUtils.DoWithCAS(ref a, v => v * 15);
            Assert.That(a, Is.EqualTo(75));
        }
    }
}
