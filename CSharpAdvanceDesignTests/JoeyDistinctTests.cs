using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

            var result = new HashSet<int>();

            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            return result;
        }
    }
}