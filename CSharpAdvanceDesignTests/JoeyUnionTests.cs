using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyUnionTests
    {
        [Test]
        public void union_numbers()
        {
            var first = new[] { 1, 3, 5, 3 };
            var second = new[] { 5, 3, 7, 7 };

            var actual = JoeyUnion(first, second);
            var expected = new[] { 1, 3, 5, 7 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            var set = new HashSet<int>();

            var firstEnumerator = first.GetEnumerator();

            while (firstEnumerator.MoveNext())
            {
                var current = firstEnumerator.Current;

                if (set.Add(current))
                {
                    yield return current;
                }
            }

            var secondEnumerator = second.GetEnumerator();

            while (secondEnumerator.MoveNext())
            {
                var current = secondEnumerator.Current;

                if (set.Add(current))
                {
                    yield return current;
                }
            }

            // 以下做法沒有延遲執行效果
            //var sortedSet = new SortedSet<int>(first);

            //var enumerator = second.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    sortedSet.Add(enumerator.Current);
            //}

            //return sortedSet;
        }
    }
}