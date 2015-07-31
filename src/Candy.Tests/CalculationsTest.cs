//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Tests
{
    using System;
    using NUnit.Framework;
    using Candy;
    
    [TestFixture]
    public class CalculationsTest
    {
        [Test]
        public void TestSecurityHashes()
        {
            Assert.That(
                Calculations.Hashes.MD5("mypassword"), Is.EqualTo("34819d7beeabb9260a5c854bc85b3e44"));
            Assert.That(
                Calculations.Hashes.SHA1("mypassword"), Is.EqualTo("91dfd9ddb4198affc5c194cd8ce6d338fde470e2".ToUpper()));
            Assert.That(
                Calculations.Hashes.SHA256("mypassword"),
                Is.EqualTo("89e01536ac207279409d4de1e5253e01f4a1769e696db0d6062ca9b8f56767c8".ToUpper()));
            Assert.That(
                Calculations.Hashes.SHA384("mypassword"),
                Is.EqualTo("95b2d3b2ad7c2759bf3daa53424e2a472bc932798dae30b982621833a449492883b7ae9d31d30d32372f98abdbb256ae".ToUpper()));
            Assert.That(
                Calculations.Hashes.SHA512("mypassword"),
                Is.EqualTo("a336f671080fbf4f2a230f313560ddf0d0c12dfcf1741e49e8722a234673037dc493caa8d291d8025f71089d63cea809cc8ae53e5b17054806837dbe4099c4ca".ToUpper()));
            Assert.That(Calculations.Hashes.CRC32(@"This is test string."), Is.EqualTo(0xab6a9ba9));
        }

        [Test]
        public void TestPasswordGenerations()
        {
            Calculations.PasswordGenerator passwordGenerator = new Calculations.PasswordGenerator(
                25,
                Calculations.PasswordGenerator.CharacterClass.Digits,
                Calculations.PasswordGenerator.GeneratorFlag.ShuffleChars
            );
            var password = passwordGenerator.Generate();
            Assert.That(password.Length, Is.EqualTo(25));
        }

        [Test]
        public void TestPasswordStrength()
        {
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("1111"), Is.EqualTo(0));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("2222222222"), Is.EqualTo(0));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("123456789"), Is.EqualTo(4));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("123456789A"), Is.EqualTo(73));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("123456789A"), Is.EqualTo(75));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("CCCCCCCCC"), Is.EqualTo(0));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("8m6y2L2WhalkPDa"), Is.EqualTo(100));
            Assert.That(Calculations.PasswordGenerator.EstimatePasswordStrength("AA11bb00__"), Is.EqualTo(68));
        }
    }
}
