using System.Collections.Generic;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAnyTests
    {
        [Test]
        public void three_employees()
        {
            var emptyEmployees = new Employee[]
            {
                new Employee(),
                new Employee(),
                new Employee(),
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsTrue(actual);
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsFalse(actual);
        }

        [Test]
        public void any_member_greater_than_91()
        {
            var numbers = new[] { 87, 88, 91, 93, 0 };
            var actual = JoeyAnyWithCondition(numbers);
            Assert.IsTrue(actual);
        }

        private bool JoeyAnyWithCondition(IEnumerable<int> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current > 91)
                {
                    return true;
                }
            }

            return false;
        }

        private bool JoeyAny(IEnumerable<Employee> employees)
        {
            return employees.GetEnumerator().MoveNext();
        }
    }
}