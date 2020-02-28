using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyTakeTests
    {
        [Test]
        public void take_2_employees()
        {
            var employees = GetEmployees();

            var actual = JoeyTake(employees);

            var expected = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Mike", LastName = "Chang"},
                new Employee {FirstName = "Joseph", LastName = "Yao"},
            };
        }

        private IEnumerable<Employee> JoeyTake(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            var count = 2;
            while (enumerator.MoveNext())
            {
                if (index < count)
                {
                    yield return enumerator.Current;
                }
                else
                {
                    break;
                }

                index++;
            }
        }
    }
}