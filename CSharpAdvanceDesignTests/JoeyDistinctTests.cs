﻿using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyDistinctTests
    {
        [Test]
        public void distinct_numbers()
        {
            var numbers = new[] { 91, 3, 91, -1 };
            var actual = Distinct(numbers);

            var expected = new[] { 91, 3, -1 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> Distinct(IEnumerable<int> numbers)
        {
            var enumerator = numbers.GetEnumerator();

            var result = new List<int>();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (!result.Contains(current))
                {
                    result.Add(current);
                }
            }

            return result;
        }
    }
}