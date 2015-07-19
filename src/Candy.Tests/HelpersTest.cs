//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using CandyHelpers = Candy.Helpers;

    [TestFixture]
    public class HelpersTest
    {
        [Test]
        public void TestSnakeCase()
        {
            Assert.That(Helpers.StringHelpers.ConvertToSnakeCase("MyTestMethod"), Is.EqualTo("My_Test_Method"));
        }

        private enum TestEnum
        {
            ValueA,
            ValueB,
            ValueC,
        }

        [Test]
        public void TestDefaultParse()
        {
            Assert.That(CandyHelpers.StringHelpers.TryParseBooleanDefault("incorrect", false), Is.False);
            Assert.That(CandyHelpers.StringHelpers.TryParseByteDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseCharDefault("incorrect", 'a'), Is.EqualTo('a'));
            Assert.That(CandyHelpers.StringHelpers.TryParseDateTimeDefault("incorrect", DateTime.MaxValue), Is.EqualTo(DateTime.MaxValue));
            Assert.That(CandyHelpers.StringHelpers.TryParseDecimalDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseDoubleDefault("incorrect", 1.2), Is.EqualTo(1.2));
            Assert.That(CandyHelpers.StringHelpers.TryParseEnumDefault<TestEnum>("incorrect", TestEnum.ValueA), Is.EqualTo(TestEnum.ValueA));
            Assert.That(CandyHelpers.StringHelpers.TryParseEnumDefault<TestEnum>("ValueC", TestEnum.ValueA), Is.EqualTo(TestEnum.ValueC));
            Assert.That(CandyHelpers.StringHelpers.TryParseInt16Default("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseInt32Default("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseInt64Default("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseSByteDefault("incorrect", -1), Is.EqualTo(-1));
            Assert.That(CandyHelpers.StringHelpers.TryParseSingleDefault("incorrect", 1.2f), Is.EqualTo(1.2f));
            Assert.That(CandyHelpers.StringHelpers.TryParseUInt16Default("incorrect", 2), Is.EqualTo(2));
            Assert.That(CandyHelpers.StringHelpers.TryParseUInt32Default("incorrect", 1), Is.EqualTo(1));
            Assert.That(CandyHelpers.StringHelpers.TryParseUInt64Default("incorrect", 1), Is.EqualTo(1));
        }

        [Test]
        public void TestDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int,string>();
            dict.Add(1, "abc");
            dict.Add(2, "bca");
            Assert.That(CandyHelpers.DictionaryHelpers.AsCommaSeparatedString(dict), Is.EqualTo("1=abc,2=bca"));
        }

        [Test]
        public void TestChunkSelectRange()
        {
            int capacity = 250; int sum = 0;
            IList<int> list = new List<int>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            foreach (var sublist in CandyHelpers.CollectionsHelpers.ChunkSelectRange(list, 45))
            {
                foreach (var item in sublist)
                {
                    sum += item;
                }
            }

            Assert.That(sum, Is.EqualTo(31125));
        }

        [Test]
        public void TestChunkSelect()
        {
            int capacity = 250; int sum = 0;
            IList<int> list = new List<int>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            foreach (var item in CandyHelpers.CollectionsHelpers.ChunkSelect(list, 45))
            {
                sum += item;
            }

            Assert.That(sum, Is.EqualTo(31125));
        }
    }
}
