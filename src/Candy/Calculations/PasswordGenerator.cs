//
// Copyright (c) 2015, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Candy.Calculations
{
    using System;
    using System.Collections.Generic;
    using System.Security;
    using System.Text;
    using Validation;
    using Extensions;

    /// <summary>
    /// Class to be used for password generation.
    /// </summary>
    public class PasswordGenerator
    {
        /// <summary>
        /// Enum specifies what characters to use for password generation.
        /// </summary>
        [Flags]
        public enum CharacterClass
        {
            /// <summary>
            /// Lower letters.
            /// </summary>
            LowerLetters = 0x1,

            /// <summary>
            /// Upper letters.
            /// </summary>
            UpperLetters = 0x2,

            /// <summary>
            /// Digits.
            /// </summary>
            Digits = 0x4,

            /// <summary>
            /// Special characters except space.
            /// </summary>
            SpecialCharacters = 0x8,

            /// <summary>
            /// Space character.
            /// </summary>
            Space = 0x16,

            /// <summary>
            /// Combination of LowerLetters and UpperLetters.
            /// </summary>
            AllLetters = LowerLetters | UpperLetters,

            /// <summary>
            /// Combination of AllLetters and Digits.
            /// </summary>
            AlphaNumeric = AllLetters | Digits,
           
            /// <summary>
            /// Combination of all elements.
            /// </summary>
            All = LowerLetters | UpperLetters | Digits | SpecialCharacters | Space,
        }

        /// <summary>
        /// Enums specifies special processing for password generation.
        /// </summary>
        [Flags]
        public enum GeneratorFlag
        {
            /// <summary>
            /// No special generation flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Exclude conflict characters.
            /// </summary>
            ExcludeLookAlike = 0x1,

            /// <summary>
            /// Shuffle pool characters before generation.
            /// </summary>
            ShuffleChars = 0x2,

            /// <summary>
            /// Makes secure string as read only.
            /// </summary>
            MakeReadOnly = 0x4,
        }

        /// <summary>
        /// Password length. Default is 10.
        /// </summary>
        public int PasswordLength { get; set; }

        /// <summary>
        /// Character classes for password generation. Default is All.
        /// </summary>
        public CharacterClass CharacterClasses { get; set; }

        /// <summary>
        /// Generator flags. Default is None.
        /// </summary>
        public GeneratorFlag GeneratorFlags { get; set; }

        /// <summary>
        /// Instance of random generation class.
        /// </summary>
        public static Random Random { get; protected set; }

        /// <summary>
        /// Characters pool that is use for password generation.
        /// </summary>
        private String CharactersPool { get; set; }

        /// <summary>
        /// Lower case characters pool.
        /// </summary>
        protected const String PoolLowerCase = "abcdefghjkmnpqrstuvwxyz";

        /// <summary>
        /// Lower case conflict characters pool.
        /// </summary>
        protected const String PoolLowerCaseConflict = "ilo";

        /// <summary>
        /// Upper case characters pool.
        /// </summary>
        protected const String PoolUpperCase = "ABCDEFGHJKLMNPQRSTUVWXYZ";

        /// <summary>
        /// Upper case characters conflict pool.
        /// </summary>
        protected const String PoolUpperCaseConflict = "OI";

        /// <summary>
        /// Digits characters pool.
        /// </summary>
        protected const String PoolDigits = "23456789";

        /// <summary>
        /// Digits conflict characters pool.
        /// </summary>
        protected const String PoolDigitsConflict = "10";

        /// <summary>
        /// Special characters pool.
        /// </summary>
        protected const String PoolSpecial = @"~@#$%^&*()_-+=[]|\:;""'<>.?/";

        /// <summary>
        /// Special characters conflict pool.
        /// </summary>
        protected const String PoolSpecialConflict = @"`{}!,";

        /// <summary>
        /// Space character.
        /// </summary>
        protected const String PoolSpace = " ";

        /// <summary>
        /// .ctor
        /// </summary>
        public PasswordGenerator()
        {
            this.PasswordLength = 10;
            this.CharacterClasses = CharacterClass.All;
            this.GeneratorFlags = GeneratorFlag.None;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="passwordLength">Password length to generate.</param>
        /// <param name="characterClasses">What characters classes to use.</param>
        /// <param name="generatorFlags">Special generator flags.</param>
        public PasswordGenerator(int passwordLength, CharacterClass characterClasses, GeneratorFlag generatorFlags) : this()
        {
            if (passwordLength < 2)
                throw new ArgumentException("Password length should be at least 2 characters");

            this.PasswordLength = passwordLength;
            this.CharacterClasses = characterClasses;
            this.GeneratorFlags = generatorFlags;
        }

        /// <summary>
        /// .cctor
        /// </summary>
        static PasswordGenerator()
        {
            Random = new Random();
        }

        /// <summary>
        /// Set characters pool for password generation. If set it will be used for password generation.
        /// Instead default characters pool will be generated.
        /// </summary>
        /// <param name="pool"></param>
        public void SetCharactersPool(String pool)
        {
            if (String.IsNullOrEmpty(pool))
                throw new ArgumentException("Characters pool cannot be empty");
            this.CharactersPool = pool; 
        }

        /// <summary>
        /// Generates custom characters pool. The pool set by SetCharactersPool will be ignored.
        /// </summary>
        public void UseDefaultCharactersPool()
        {
            this.CharactersPool = String.Empty;
        }

        /// <summary>
        /// Generates new password to String.
        /// </summary>
        /// <returns>Password.</returns>
        public String Generate()
        {
            var pool = String.IsNullOrEmpty(this.CharactersPool) ? CreateCharactersPool() : this.CharactersPool.ToCharArray();
            StringBuilder sb = new StringBuilder(PasswordLength);

            if (this.GeneratorFlags.HasFlag(GeneratorFlag.ShuffleChars))
            {
                ShuffleCharsArray(pool);
            }

            for (int i = 0; i < PasswordLength; i++)
            {
                int random = Random.Next(pool.Length);
                sb.Append(pool[random]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates new password to SecureString.
        /// </summary>
        /// <returns>Password.</returns>
        public SecureString GenerateSecure()
        {
            var pool = String.IsNullOrEmpty(this.CharactersPool) == false ? CreateCharactersPool() : this.CharactersPool.ToCharArray();
            var secureString = new SecureString();

            if (this.GeneratorFlags.HasFlag(GeneratorFlag.ShuffleChars))
            {
                ShuffleCharsArray(pool);
            }

            for (int i = 0; i < PasswordLength; i++)
            {
                int random = Random.Next(pool.Length);
                secureString.AppendChar(pool[random]);
            }

            if (GeneratorFlags.HasFlag(GeneratorFlag.MakeReadOnly))
            {
                secureString.MakeReadOnly();
            }

            return secureString;
        }

        /// <summary>
        /// Estimate password strength. See documentation for more details.
        /// </summary>
        /// <param name="password">Password to estimate.</param>
        /// <returns>Estimate score.</returns>
        public static Int32 EstimatePasswordStrength(String password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be empty");

            Int32 score = 0, uppercaseCount = 0, lowercaseCount = 0, numberCount = 0,
                specialSymbolCount = 0, middleNumberOrSymbolCount = 0;

            // number of characters
            score += password.Length * 4;

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                    uppercaseCount++;
                if (Char.IsLower(password[i]))
                    lowercaseCount++;
                if (Char.IsDigit(password[i]))
                    numberCount++;
                if (PoolSpecial.Contains(password[i].ToString()) || PoolSpecialConflict.Contains(password[i].ToString()))
                    specialSymbolCount++;
                if (Char.IsDigit(password[i]) && i > 0 && i + 1 < password.Length)
                    middleNumberOrSymbolCount++;
            }

            // minimum requirements
            var minRequirements = 0;
            if (uppercaseCount > 0)
                minRequirements++;
            if (lowercaseCount > 0)
                minRequirements++;
            if (numberCount > 0)
                minRequirements++;
            if (specialSymbolCount > 0)
                minRequirements++;
            if (password.Length < 9 || minRequirements <= 3)
                score = 0;

            return score;
        }

        /// <summary>
        /// Get password entropy.
        /// </summary>
        /// <returns>Password's entropy.</returns>
        public Double GetEntropy()
        {
            var pool = String.IsNullOrEmpty(this.CharactersPool) == false ? CreateCharactersPool() : this.CharactersPool.ToCharArray();
            return Math.Log(Math.Pow(this.PasswordLength, pool.Length), 2);
        }

        private Char[] CreateCharactersPool()
        {
            List<Char> chars = new List<Char>(65);
            
            if (CharacterClasses.HasFlag(CharacterClass.UpperLetters))
            {
                chars.AddRange(PoolUpperCase.ToCharArray());
                if (GeneratorFlags.HasFlag(GeneratorFlag.ExcludeLookAlike) == false)
                {
                    chars.AddRange(PoolUpperCaseConflict.ToCharArray());
                }
            }
            if (this.CharacterClasses.HasFlag(CharacterClass.LowerLetters))
            {
                chars.AddRange(PoolLowerCase.ToCharArray());
                if (GeneratorFlags.HasFlag(GeneratorFlag.ExcludeLookAlike) == false)
                {
                    chars.AddRange(PoolLowerCaseConflict.ToCharArray());
                }
            }
            if (this.CharacterClasses.HasFlag(CharacterClass.Digits))
            {
                chars.AddRange(PoolDigits.ToCharArray());
                if (GeneratorFlags.HasFlag(GeneratorFlag.ExcludeLookAlike) == false)
                {
                    chars.AddRange(PoolDigitsConflict.ToCharArray());
                }
            }
            if (this.CharacterClasses.HasFlag(CharacterClass.SpecialCharacters))
            {
                chars.AddRange(PoolSpecial.ToCharArray());
                if (GeneratorFlags.HasFlag(GeneratorFlag.ExcludeLookAlike) == false)
                {
                    chars.AddRange(PoolSpecialConflict.ToCharArray());
                }
            }
            if (CharacterClasses.HasFlag(CharacterClass.Space))
            {
                chars.AddRange(PoolSpace.ToCharArray());
            }

            return chars.ToArray();
        }

        private static void ShuffleCharsArray(Char[] chars)
        {
            for (int i = chars.Length - 1; i >= 1; i--)
            {
                int j = Random.Next(i + 1);
                Common.Objects.Swap(ref chars[i], ref chars[j]);
            }
        }
    }
}
