using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyExceptTests
    {
        [Test]
        public void except_numbers()
        {
            var first = new[] { 1, 3, 5, 7, 3 };
            var second = new[] { 7, 1, 4, 1 };

            var actual = JoeyExcept(first, second);
            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyExcept(IEnumerable<int> first, IEnumerable<int> second)
        {
            var secondHashSet = new HashSet<int>(second);

            var enumerator = first.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (secondHashSet.Add(current))
                {
                    yield return current;
                }
            }
        }
    }
}