using System.Collections.Generic;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySequenceEqualTests
    {
        [Test]
        public void compare_two_numbers_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_context_not_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 1, 2 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_member_2_empty()
        {
            var first = new List<int> { };
            var second = new List<int> { };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_member_1_empty()
        {
            var first = new List<int> { 1 };
            var second = new List<int> { };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_count_not_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 1 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        private bool JoeySequenceEqual(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                {
                    return false;
                }
            }

            return firstEnumerator.Current.Equals(secondEnumerator.Current);
        }
    }
}