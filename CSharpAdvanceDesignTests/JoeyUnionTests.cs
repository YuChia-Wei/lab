using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyUnionTests
    {
        [Test]
        public void union_numbers()
        {
            var first = new[] { 1, 3, 5 };
            var second = new[] { 5, 3, 7 };

            var actual = JoeyUnion(first, second);
            var expected = new[] { 1, 3, 5, 7 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            var sortedSet = new SortedSet<int>(first);

            var enumerator = second.GetEnumerator();

            while (enumerator.MoveNext())
            {
                sortedSet.Add(enumerator.Current);
            }

            return sortedSet;
        }
    }
}