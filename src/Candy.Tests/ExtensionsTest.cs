//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void TestFormat()
        {
            Assert.That("{0} + {1} = {2}".FormatWith(2, 2, 4), Is.EqualTo("2 + 2 = 4"));
        }

        [Test]
        public void TestDictionaryDefaultValue()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "abc");
            dict.Add(2, "bca");
            Assert.That(dict.GetValueDefault(5, "default"), Is.EqualTo("default"));
            Assert.That(dict.GetValueDefault(1, "abc"), Is.EqualTo("abc"));
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
            Assert.That(StringUtils.ParseDefault("incorrect", false), Is.False);
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", 'a'), Is.EqualTo('a'));
            Assert.That(StringUtils.ParseDefault("incorrect", DateTime.MaxValue), Is.EqualTo(DateTime.MaxValue));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", 1.2), Is.EqualTo(1.2));
            Assert.That(StringUtils.ParseDefault<TestEnum>("incorrect", TestEnum.ValueA), Is.EqualTo(TestEnum.ValueA));
            Assert.That(StringUtils.ParseDefault<TestEnum>("ValueC", TestEnum.ValueA), Is.EqualTo(TestEnum.ValueC));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", -1), Is.EqualTo(-1));
            Assert.That(StringUtils.ParseDefault("incorrect", 1.2f), Is.EqualTo(1.2f));
            Assert.That(StringUtils.ParseDefault("incorrect", 2), Is.EqualTo(2));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
            Assert.That(StringUtils.ParseDefault("incorrect", 1), Is.EqualTo(1));
        }

        [Test]
        public void TestStringSafeSubstring()
        {
            Assert.That(StringUtils.SafeSubstring("123", 1, 3), Is.EqualTo("23"));
            Assert.That(StringUtils.SafeSubstring("123", 1, 6), Is.EqualTo("23"));
        }

        [Test]
        public void TestChunkSelectRange()
        {
            int capacity = 250;
            int sum = 0;
            IList<int> list = new List<int>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            foreach (var sublist in CollectionsExtensions.ChunkSelectRange(list, 45))
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
            int capacity = 250;
            int sum = 0;
            IList<int> list = new List<int>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                list.Add(i);
            }
            foreach (var item in CollectionsExtensions.ChunkSelect(list, 45))
            {
                sum += item;
            }

            Assert.That(sum, Is.EqualTo(31125));
        }
    }
}
