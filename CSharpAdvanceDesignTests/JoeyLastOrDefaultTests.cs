using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyLastOrDefaultTests
    {
        [Test]
        public void get_last_employee()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLastOrDefault(employees);

            new Employee { FirstName = "Cash", LastName = "Li" }
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_employee_last_name_is_Chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLastOrDefault(employees, current => current?.LastName == "Chen");

            new Employee { FirstName = "David", LastName = "Chen" }
            .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();
            var actual = JoeyLastOrDefault(employees);
            Assert.IsNull(actual);
        }

        /// <summary>
        /// by YuChia
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        private Employee JoeyLastOrDefault(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();

            var result = default(Employee);

            while (enumerator.MoveNext())
            {
                result = enumerator.Current;
            }

            return result;
        }

        /// <summary>
        /// by 91
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private TSource JoeyLastOrDefault<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return default(TSource);
            }

            var last = enumerator.Current;
            while (enumerator.MoveNext())
            {
                last = enumerator.Current;
            }

            return last;
        }

        private TSource JoeyLastOrDefault<TSource>(IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var enumerator = sources.GetEnumerator();
            TSource employee = default(TSource);
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    employee = current;
                }
            }

            return employee;
        }
    }
}