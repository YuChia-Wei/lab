using System;
using System.Collections.Generic;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAllTests
    {
        [Test]
        public void girls_all_adult_false()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 17},
                new Girl{Age = 18},
                new Girl{Age = 30},
            };

            var actual = girls.JoeyAll(current => current.Age >= 18);
            Assert.IsFalse(actual);
        }

        [Test]
        public void girls_all_adult_true()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 18},
                new Girl{Age = 18},
                new Girl{Age = 30},
            };

            var actual = girls.JoeyAll(current => current.Age >= 18);
            Assert.IsTrue(actual);
        }
    }
}